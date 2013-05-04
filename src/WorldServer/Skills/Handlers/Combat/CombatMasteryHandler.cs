﻿// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see licence.txt in the main folder

using Aura.Shared.Const;
using Aura.Shared.Util;
using Aura.World.World;
using Aura.World.Events;
using System;

namespace Aura.World.Skills
{
	public class CombatMasteryHandler : SkillHandler
	{
		public override SkillResults Use(MabiCreature creature, MabiCreature target, MabiSkill skillfoo)
		{
			if (creature.IsStunned)
				return SkillResults.AttackStunned;

			if (!WorldManager.InRange(creature, target, (uint)(creature.RaceInfo.AttackRange + 50)))
				return SkillResults.OutOfRange;

			MabiSkill skill;
			SkillHandler handler;
			if (creature.ActiveSkillId != 0)
			{
				skill = creature.GetSkill(creature.ActiveSkillId);
				handler = SkillManager.GetHandler(skill.Id);
			}
			else
			{
				skill = creature.GetSkill(SkillConst.MeleeCombatMastery);
				handler = this;
			}

			if (handler == null)
				return SkillResults.Unimplemented;

			var sourceAction = new CombatAction();
			sourceAction.ActionType = CombatActionType.Hit;
			sourceAction.SkillId = (SkillConst)skill.Info.Id;
			sourceAction.Creature = creature;
			sourceAction.TargetId = (target != null ? target.Id : 0);

			return handler.UseCombat(creature, target, sourceAction, skill);
		}

		public override SkillResults UseCombat(MabiCreature creature, MabiCreature target, CombatAction sourceAction, MabiSkill skill)
		{
			if (!WorldManager.InRange(creature, target, (uint)(creature.RaceInfo.AttackRange + 50)))
				return SkillResults.OutOfRange;

			if (creature.IsStunned)
				return SkillResults.AttackStunned;

			uint prevCombatActionId = 0;
			var rnd = RandomProvider.Get();

			creature.StopMove();
			target.StopMove();

			this.SetAggro(creature, target);

			var rightHand = creature.RightHand;
			var leftHand = creature.LeftHand;
			if (leftHand != null && !leftHand.IsOneHandWeapon)
				leftHand = null;

			sourceAction.DualWield = (rightHand != null && leftHand != null);

			// Do this for two weapons, break if there is no second hit.
			for (byte i = 1; i <= 2; ++i)
			{
				var combatArgs = new CombatEventArgs();
				combatArgs.CombatActionId = CombatHelper.ActionId;
				combatArgs.PrevCombatActionId = prevCombatActionId;
				combatArgs.Hit = i;
				combatArgs.HitsMax = (byte)(sourceAction.DualWield ? 2 : 1);

				var targetAction = new CombatAction();
				targetAction.Creature = target;
				targetAction.Target = creature;
				targetAction.ActionType = CombatActionType.TakeDamage;
				targetAction.SkillId = sourceAction.SkillId;

				var weapon = (i == 1 ? rightHand : leftHand);
				var damage = creature.GetRndDamage(weapon);

				damage -= target.Defense;
				damage -= (damage * target.Protection);

				// Crit (temp)
				if (rnd.NextDouble() < creature.CriticalChance)
				{
					damage *= 1.5f; // R1
					targetAction.Critical = true;
				}

				// Def (temp)
				if (target.ActiveSkillId == (ushort)SkillConst.Defense)
				{
					damage *= 0.1f;
					targetAction.ActionType |= CombatActionType.Defense;
				}

				// Counter
				if (target.ActiveSkillId == (ushort)SkillConst.MeleeCounterattack)
				{
					sourceAction.ActionType = CombatActionType.TakeDamage;
					targetAction.ActionType = CombatActionType.Counter;
				}

				damage = Math.Max(1f, damage);

				targetAction.CombatDamage = damage;
				target.TakeDamage(damage);
				targetAction.Finish = target.IsDead;
				sourceAction.Finish = targetAction.Finish;

				// Stuns
				if (!targetAction.ActionType.HasFlag(CombatActionType.Defense))
				{
					var atkSpeed = (weapon == null ? creature.RaceInfo.AttackSpeed : weapon.OptionInfo.AttackSpeed);
					var downHitCount = (weapon == null ? creature.RaceInfo.KnockCount : weapon.OptionInfo.KnockCount);
					var targetStunTime = CombatHelper.CalculateStunTarget(atkSpeed, targetAction.IsKnock());

					sourceAction.StunTime = CombatHelper.CalculateStunSource(atkSpeed, targetAction.IsKnock());
					targetAction.StunTime = targetStunTime;

					creature.AddStun(sourceAction.StunTime, true);
					target.AddStun(targetAction.StunTime, false);

					// Knockback/down
					if (target.Stun > (downHitCount * targetStunTime))
					{
						targetAction.Knockback = true;
						sourceAction.Knockback = true;
						sourceAction.StunTime = CombatHelper.CalculateStunSource(atkSpeed, true);
						targetAction.StunTime = CombatHelper.CalculateStunTarget(atkSpeed, true);
						creature.AddStun(sourceAction.StunTime, true);
						target.AddStun(targetAction.StunTime, true);
					}
				}
				else
				{
					sourceAction.StunTime = 2500;
					targetAction.StunTime = 1000;
					creature.AddStun(sourceAction.StunTime, true);
					target.AddStun(targetAction.StunTime, true);
					targetAction.SkillId = SkillConst.Defense;
				}

				if (targetAction.IsKnock())
				{
					targetAction.OldPosition = target.GetPosition().Copy();
					var pos = WorldManager.CalculatePosOnLine(creature, target, 375);
					target.SetPosition(pos.X, pos.Y);
					targetAction.ActionType &= ~CombatActionType.Defense;
				}

				combatArgs.CombatActions.Add(sourceAction);
				combatArgs.CombatActions.Add(targetAction);

				if (targetAction.IsKnock())
				{
					combatArgs.HitsMax = combatArgs.Hit;
				}

				WorldManager.Instance.CreatureCombatAction(creature, target, combatArgs);
				WorldManager.Instance.CreatureCombatSubmit(creature, combatArgs.CombatActionId);

				WorldManager.Instance.CreatureStatsUpdate(creature);
				WorldManager.Instance.CreatureStatsUpdate(target);

				if (combatArgs.Hit == combatArgs.HitsMax)
					break;

				prevCombatActionId = combatArgs.CombatActionId;
			}

			this.GiveSkillExp(creature, skill, 20);

			return SkillResults.Okay;
		}
	}
}
