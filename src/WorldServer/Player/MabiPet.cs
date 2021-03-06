﻿// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see licence.txt in the main folder

using System;
using Aura.World.World;

namespace Aura.World.Player
{
	public class MabiPet : MabiPC
	{
		public MabiPet()
		{
			this.CreationTime = DateTime.Now;
			this.LevelingEnabled = true;
		}

		public override EntityType EntityType
		{
			get { return EntityType.Pet; }
		}

		public override void CalculateBaseStats()
		{
			base.CalculateBaseStats();

			this.Height = 0.7f;
		}
	}
}
