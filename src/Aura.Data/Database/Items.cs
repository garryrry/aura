﻿// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see licence.txt in the main folder

using System.Collections.Generic;
using System.Linq;

namespace Aura.Data
{
	public class ItemInfo
	{
		public uint Id;
		public uint Version;
		public string Name, KorName;
		public ushort Type;
		public byte Width, Height;
		public byte ColorMap1, ColorMap2, ColorMap3, ColorMode;
		public ushort StackType;
		public ushort StackMax;
		public uint StackItem;
		public uint Price, SellingPrice;
		public uint Durability;
		public uint Defense;
		public short Protection;
		public byte WeaponType;
		public ushort Range;
		public ushort AttackMin, AttackMax;
		public byte Critical;
		public byte Balance;
		public byte AttackSpeed;
		public byte KnockCount;
		public short UsableType, UsableVar, UsablePerc, UsableStr, UsableInt, UsableDex, UsableWill, UsableLuck, UsableLife, UsableMana, UsableStamina, UsableFat, UsableUpper, UsableLower;
		public float UsableToxic;
	}

	/// <summary>
	/// Item database, indexed by item id.
	/// </summary>
	public class ItemDb : DatabaseCSVIndexed<uint, ItemInfo>
	{
		public ItemInfo Find(string name)
		{
			name = name.ToLower();
			return this.Entries.FirstOrDefault(a => a.Value.Name.ToLower() == name).Value;
		}

		public List<ItemInfo> FindAll(string name)
		{
			name = name.ToLower();
			return this.Entries.FindAll(a => a.Value.Name.ToLower().Contains(name));
		}

		protected override void ReadEntry(CSVEntry entry)
		{
			if (entry.Count < 25)
				throw new FieldCountException(25);

			var info = new ItemInfo();
			info.Id = entry.ReadUInt();
			info.Version = entry.ReadUInt();

			info.Name = entry.ReadString();
			info.KorName = entry.ReadString();
			info.Type = entry.ReadUShort();
			info.StackType = entry.ReadUShort();
			info.StackMax = entry.ReadUShort();

			if (info.StackMax < 1)
				info.StackMax = 1;

			info.StackItem = entry.ReadUInt();

			info.Width = entry.ReadUByte();
			info.Height = entry.ReadUByte();
			info.ColorMap1 = entry.ReadUByte();
			info.ColorMap2 = entry.ReadUByte();
			info.ColorMap3 = entry.ReadUByte();
			info.Price = entry.ReadUInt();
			info.SellingPrice = (info.Id != 2000 ? (uint)(info.Price * 0.1f) : 1000);
			info.Durability = entry.ReadUInt();
			info.Defense = entry.ReadUInt();
			info.Protection = entry.ReadSShort();
			info.WeaponType = entry.ReadUByte();
			if (info.WeaponType == 0)
			{
				entry.Skip(7);
			}
			else
			{
				info.Range = entry.ReadUShort();
				info.AttackMin = entry.ReadUShort();
				info.AttackMax = entry.ReadUShort();
				info.Critical = entry.ReadUByte();
				info.Balance = entry.ReadUByte();
				info.AttackSpeed = entry.ReadUByte();
				info.KnockCount = entry.ReadUByte();
			}
			if ((info.Type < 400 || info.Type > 503) || info.Type == 502)
			{
				entry.Skip(15);
			}
			else
			{
				info.UsableType = entry.ReadSShort();
				info.UsableVar = entry.ReadSShort();
				info.UsablePerc = entry.ReadSShort();
				info.UsableStr = entry.ReadSShort();
				info.UsableInt = entry.ReadSShort();
				info.UsableDex = entry.ReadSShort();
				info.UsableWill = entry.ReadSShort();
				info.UsableLuck = entry.ReadSShort();
				info.UsableLife = entry.ReadSShort();
				info.UsableMana = entry.ReadSShort();
				info.UsableStamina = entry.ReadSShort();
				info.UsableFat = entry.ReadSShort();
				info.UsableUpper = entry.ReadSShort();
				info.UsableLower = entry.ReadSShort();
				info.UsableToxic = entry.ReadFloat();
			}

			this.Entries.Add(info.Id, info);
		}
	}
}