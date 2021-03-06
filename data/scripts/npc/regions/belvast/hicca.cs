using Aura.Shared.Const;
using System;
using Aura.World.Network;
using Aura.World.Scripting;
using Aura.World.World;

public class HiccaScript : NPCScript
{
	public override void OnLoad()
	{
		base.OnLoad();
		SetName("_hicca");
		SetRace(10002);
		SetBody(height: 0.6999999f, fat: 1f, upper: 1f, lower: 1f);
		SetFace(skin: 19, eye: 31, eyeColor: 134, lip: 2);

		SetColor(0x808080, 0x808080, 0x808080);

		EquipItem(Pocket.Face, 0x1324, 0x8365AC, 0xB3B07F, 0xEFF7E4);
		EquipItem(Pocket.Hair, 0xFC7, 0x70B28F, 0x70B28F, 0x70B28F);
		EquipItem(Pocket.Armor, 0x36B2, 0xBDDFF6, 0x2A4058, 0x166487);
		EquipItem(Pocket.Glove, 0x3EC0, 0x1C2024, 0x424B, 0x399FF2);
		EquipItem(Pocket.Shoe, 0x4337, 0x2B2C35, 0x62404D, 0x66685A);
		EquipItem(Pocket.RightHand1, 0x9C43, 0x996600, 0x225BC3, 0x4A2FB0);
		EquipItem(Pocket.RightHand2, 0xAFC9, 0x464646, 0x37727F, 0x4E1EF4);

		SetLocation(region: 4005, x: 39157, y: 35723);

		SetDirection(200);
		SetStand("");

		Phrases.Add("Admiral Owen is a really great man!");
		Phrases.Add("I want my dream to come true!");
		Phrases.Add("I want to go on an adventure.");
		Phrases.Add("I'm going to become a great hero!");
		Phrases.Add("I'm going to grow up to be just like Admiral Owen!");
		Phrases.Add("Mom, help me fulfill my dream!");
	}
}
