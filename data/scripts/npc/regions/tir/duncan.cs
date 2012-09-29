using System;
using Common.World;
using World.Network;
using World.Scripting;
using World.World;
using Common.Constants;

public class DuncanScript : NPCScript
{
	public override void OnLoad()
	{
		SetName("_duncan");
		SetRace(10002);
		SetBody(height: 1.3f);
		SetFace(skin: 20, eye: 17, eyeColor: 0, lip: 0);

		EquipItem(Pocket.Face, 4950, 9633884, 16361044, 5138520);
		EquipItem(Pocket.Hair, 4083, 12234138, 12234138, 12234138);
		EquipItem(Pocket.Armor, 15004, 6176328, 13932380, 4011589);
		EquipItem(Pocket.Shoe, 17021, 13351853);

		SetLocation(region: 1, x: 15409, y: 38310);

		SetDirection(122);
		SetStand("human/male/anim/male_natural_stand_npc_duncan_new");

		Shop.AddTabs("Quests");

		Phrases.Add("Ah, that bird in the tree is still sleeping.");
		Phrases.Add("Ah, who knows how many days are left in these old bones?");
		Phrases.Add("Everything appears to be fine, but something feels off.");
		Phrases.Add("Hmm....");
		Phrases.Add("It's quite warm today.");
		Phrases.Add("Sometimes, my memories sneak up on me and steal my breath away.");
		Phrases.Add("That tree has been there for quite a long time, now that I think about it.");
		Phrases.Add("The graveyard has been left unattended far too long.");
		Phrases.Add("Watch your language.");

	}

	public override void OnTalk(WorldClient c)
	{
		Msg(c, false, false, "An elderly man gazes softly at the world around him with a calm air of confidence.",
			"Although his face appears weather-beaten, and his hair and beard are gray, his large beaming eyes make him look youthful somehow.",
			"As he speaks, his voice resonates with a kind of gentle authority.");
		MsgSelect(c, "Please let me know if you need anything.", "Start Conversation", "@talk", "Shop", "@shop", "Retrive Lost Items", "@lostandfound");
	}

	public override void OnSelect(WorldClient c, string r)
	{
		switch (r)
		{
			case "@talk":
				Msg(c, "What did you say your name was?", "Anyway, welcome.");
				Msg(c, true, false, "(Duncan is waiting for me to say something.)");
				ShowKeywords(c);
				break;

			case "@shop":
				Msg(c, "Choose a quest you would like to do.");
				OpenShop(c);
				break;

			case "@lostandfound":
				Msg(c, "If you are knocked unconcious in a dungeon or field, any item you've dropped will be lost unless you get resurrected right at the spot.",
					"Lost items can usually be recovered from a Town Office or a Lost-and-Found.");
				Msg(c, "Unfortunatly, Tir Chonaill does not have a Town Office, so I run the Lost-and-Found myself.",
					"The lost items are recovered with magic,",
					"so unless you've dropped them on purpose, you can recover those items with their blessings intact.",
					"You will, however, need to pay a fee.");
				Msg(c, "As you can see, I have limited space in my home. So I can only keep 20 items for you.",
					"If there are more than 20 lost items, I'll have to throw out the oldest items to make room.",
					"I strongly suggest you retrieve any lost items you don't want to lose as soon as possible.");
				break;

			default:
				Msg(c, "Oh, is that so?");
				ShowKeywords(c);
				break;
		}
	}
}