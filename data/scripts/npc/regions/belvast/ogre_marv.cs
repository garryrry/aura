using Aura.Shared.Const;
using System;
using Aura.World.Network;
using Aura.World.Scripting;
using Aura.World.World;

public class Ogre_marvScript : NPCScript
{
	public override void OnLoad()
	{
		base.OnLoad();
		SetName("_ogre_marv");
		SetRace(323);
		SetBody(height: 0.8f, fat: 1f, upper: 1f, lower: 1f);
		SetFace(skin: 205, eye: 0, eyeColor: 0, lip: 0);

		SetColor(0x727249, 0x666666, 0x806034);



		SetLocation(region: 4005, x: 37734, y: 29827);

		SetDirection(181);
		SetStand("chapter4/monster/anim/ogre/ogre_c4_npc_health");

		Phrases.Add("I lost a little weight");
		Phrases.Add("I'm getting more popular.");
		Phrases.Add("I'm hungry, but I will be strong.");
		Phrases.Add("Muscles. Awesome.");
		Phrases.Add("Must eat vegetables.");
		Phrases.Add("My stomach went in.");
	}
}
