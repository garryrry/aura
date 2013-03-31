// --- Aura Script ----------------------------------------------------------
//  Telephant
// --- Description ----------------------------------------------------------
//  Warper NPC
// --- By -------------------------------------------------------------------
//  Miro, exec
// --------------------------------------------------------------------------

using System;
using System.Collections;
using Aura.Shared.Const;
using Aura.World.Network;
using Aura.World.Scripting;
using Aura.World.World;

public class _TelephantBaseScript : NPCScript
{
	public override void OnLoad()
	{
		SetName("_<mini>NPC</mini>Telephant");
		SetDialogName("Telephant");
		SetRace(550001);
	}
	
	public override IEnumerable OnTalk(WorldClient c)
	{
		Msg(c, "Hello! I am Telephant, and I'm here to carry you all over the world!");
	
	L_Selection:
		MsgSelect(c,
			"Where do you want to go?",
			"Events / Customized", "@custom",
			"Uladh", "@uladh",
			"Iria", "@iria",
			"Belvast", "@belvast",
			"Avon", "@avon",
			"Falias", "@falias",
			"Another World", "@a_world",
			"Never Mind", "@end"
		);
		
		var r = Wait();
		switch(r)
		{
			case "@custom":
			{
				MsgSelect(c,
					"What custom location do you want to go to?",
					"Nekojima", "@neko",
					"The Moon", "@moon",
					"Soul Stream", "@soul",
					"Back", "@startingpoint"
				);
				
				r = Wait();
				if(r == "@startingpoint")
					goto L_Selection;
					
				switch(r)
				{
					case "@neko":
						c.Warp(600, 93757, 88234);
						MsgSelect(c, "You will be teleported to Nekojima soon.", "Okay", "@end");
						End();
					case "@moon":
						c.Warp(1003, 7058, 6724);
						MsgSelect(c, "You will be teleported to the moon soon.", "Okay", "@end");
						End();
					case "@soul":
						c.Warp(1000, 6368, 7150);
						MsgSelect(c, "You will be teleported to the soul stream soon.", "Okay", "@end");
						End();
				}
				
				break;
			}
			
			case "@uladh":
			{
				MsgSelect(c,
					"What location in Uladh do you want to go to?",
					"Tir Chonaill", "@tir", 
					"Dunbarton", "@dun",
					"Bangor", "@bangor", 
					"Emain Macha", "@emain", 
					"Taillteann", "@tail", 
					"Tara", "@tara", 
					"Port Cobh", "@cobh", 
					"Ceo Island", "@ceo", 
					"Back", "@startingpoint"
				);
				
				r = Wait();
				if(r == "@startingpoint")
					goto L_Selection;
					
				switch(r)
				{
					case "@tir":
						c.Warp(1, 12991, 38549);
						MsgSelect(c, "You will be teleported to Tir Chonaill soon.", "Okay", "@end");
						End();
					case "@dun":
						c.Warp(14, 38001, 38802);
						MsgSelect(c, "You will be teleported to Dunbarton soon.", "Okay", "@end");
						End();
					case "@bangor":
						c.Warp(31, 12904, 12200);
						MsgSelect(c, "You will be teleported to Bangor soon.", "Okay", "@end");
						End();
					case "@emain":
						c.Warp(52, 39818, 41621);
						MsgSelect(c, "You will be teleported to Emain Macha soon.", "Okay", "@end");
						End();
					case "@tail":
						c.Warp(300, 212749, 192720);
						MsgSelect(c, "You will be teleported to Taillteann soon.", "Okay", "@end");
						End();
					case "@tara":
						c.Warp(401, 99793, 91209);
						MsgSelect(c, "You will be teleported to Tara soon.", "Okay", "@end");
						End();
					case "@cobh":
						c.Warp(23, 28559, 37693);
						MsgSelect(c, "You will be teleported to Port Cobh soon.", "Okay", "@end");
						End();
					case "@ceo":
						c.Warp(56, 8743, 9299);
						MsgSelect(c, "You will be teleported to Ceo Island soon.", "Okay", "@end");
						End();
				}
				
				break;
			}
			
			case "@iria":
			{
				MsgSelect(c,
					"What location in Iria do you want to go to?",
					"Quilla Base Camp", "@quilla",
					"Filia", "@filia",
					"Vales", "@vales",
					"Cor", "@cor",
					"Calida", "@calida",
					"Back", "@startingpoint"
				);
				
				r = Wait();
				if(r == "@startingpoint")
					goto L_Selection;
					
				switch(r)
				{
					case "@quilla":
						c.Warp(3001, 166562, 168930);
						MsgSelect(c, "You will be teleported to Quilla Base Camp soon.", "Okay", "@end");
						End();
					case "@filia":
						c.Warp(3100, 373654, 424901);
						MsgSelect(c, "You will be teleported to Filia soon.", "Okay", "@end");
						End();
					case "@vales":
						c.Warp(3200, 289556, 211936);
						MsgSelect(c, "You will be teleported to Vales soon.", "Okay", "@end");
						End();
					case "@cor":
						c.Warp(3300, 254233, 186929);
						MsgSelect(c, "You will be teleported to Cor soon.", "Okay", "@end");
						End();
					case "@calida":
						c.Warp(3400, 328825, 176094);
						MsgSelect(c, "You will be teleported to Calida Lake soon.", "Okay", "@end");
						End();
				}
				
				break;
			}
			
			case "@a_world":
			{
				MsgSelect(c,
					"What location in Another World do you want to go to?",
					"Crossroads", "@cross",
					"Bangor (A)", "@bangor_a",
					"Gairech Hills (A)", "@gairech_a",
					"Tir Chonaill (A)", "@tir_a",
					"Back", "@startingpoint"
				);
				
				r = Wait();
				if(r == "@startingpoint")
					goto L_Selection;
					
				switch(r)
				{
					case "@cross":
						c.Warp(51, 10410, 10371);
						MsgSelect(c, "You will be teleported to Crossroads soon.", "Okay", "@end");
						End();
					case "@tir_a":
						c.Warp(35, 12801, 38380);
						MsgSelect(c, "You will be teleported to Tir Chonaill (A) soon.", "Okay", "@end");
						End();
					case "@bangor_a":
						c.Warp(84, 12888, 7986);
						MsgSelect(c, "You will be teleported to Bangor (A) soon.", "Okay", "@end");
						End();
					case "@gairech_a":
						c.Warp(83, 38405, 47366);
						MsgSelect(c, "You will be teleported to Gairech Hills (A) soon.", "Okay", "@end");
						End();
				}
				
				break;
			}
			
			case "@belvast":
			{
				c.Warp(4005, 63373, 26475);
				MsgSelect(c, "You will be teleported to Belvast soon.", "Okay", "@end");
				End();
			}

			case "@avon":
			{
				c.Warp(501, 64195, 63211);
				MsgSelect(c, "You will be teleported to Avon soon.", "Okay", "@end");
				End();
			}

			case "@falias":
			{
				c.Warp(500, 11839, 23832);
				MsgSelect(c, "You will be teleported to Falias soon.", "Okay", "@end");
				End();
			}
		}
	}
}

public class TelephantAvonScript : _TelephantBaseScript { public override void OnLoad() { base.OnLoad(); SetLocation(501, 65355, 63105, 125); } }
public class TelephantBangorScript : _TelephantBaseScript { public override void OnLoad() { base.OnLoad(); SetLocation(31, 11634, 12285, 0); } } 
public class TelephantBangorAScript : _TelephantBaseScript { public override void OnLoad() { base.OnLoad(); SetLocation(84, 12887, 7657, 60); } }
public class TelephantBelvastScript : _TelephantBaseScript { public override void OnLoad() { base.OnLoad(); SetLocation(4005, 63661, 25973, 80); } }
public class TelephantCalidaScript : _TelephantBaseScript { public override void OnLoad() { base.OnLoad(); SetLocation(3400, 328767, 176263, 210); } }
public class TelephantCeoScript : _TelephantBaseScript { public override void OnLoad() { base.OnLoad(); SetLocation(56, 8250, 9340, 0); } }
public class TelephantCobhScript : _TelephantBaseScript { public override void OnLoad() { base.OnLoad(); SetLocation(23, 28773, 37705, 130); } }
public class TelephantCorScript : _TelephantBaseScript { public override void OnLoad() { base.OnLoad(); SetLocation(3300, 254100, 187111, 215); } }
public class TelephantCrossroadScript : _TelephantBaseScript { public override void OnLoad() { base.OnLoad(); SetLocation(51, 10040, 10317, 0); } }
public class TelephantDunScript : _TelephantBaseScript { public override void OnLoad() { base.OnLoad(); SetLocation(14, 38000, 39629, 190); } }
public class TelephantEmainScript : _TelephantBaseScript { public override void OnLoad() { base.OnLoad(); SetLocation(52, 39948, 41431, 80); } }
public class TelephantFaliasScript : _TelephantBaseScript { public override void OnLoad() { base.OnLoad(); SetLocation(500, 11770, 23458, 50); } }
public class TelephantFiliaScript : _TelephantBaseScript { public override void OnLoad() { base.OnLoad(); SetLocation(3100, 374015, 424585, 95); } }
public class TelephantGairechAScript : _TelephantBaseScript { public override void OnLoad() { base.OnLoad(); SetLocation(83, 38366, 47743, 190); } }
public class TelephantMoonScript : _TelephantBaseScript { public override void OnLoad() { base.OnLoad(); SetLocation(1003, 6868, 7008, 220); } }
public class TelephantMoon2Script : _TelephantBaseScript { public override void OnLoad() { base.OnLoad(); SetLocation(1003, 20843, 20083, 100); } }
public class TelephantNekoScript : _TelephantBaseScript { public override void OnLoad() { base.OnLoad(); SetLocation(600, 93654, 88089, 30); } }
public class TelephantQuillaScript : _TelephantBaseScript { public override void OnLoad() { base.OnLoad(); SetLocation(3001, 166788, 168716, 95); } }
public class TelephantSoulStreamScript : _TelephantBaseScript { public override void OnLoad() { base.OnLoad(); SetLocation(1000, 5678, 7193, 0); } }
public class TelephantTailScript : _TelephantBaseScript { public override void OnLoad() { base.OnLoad(); SetLocation(300, 212336, 194269, 200); } }
public class TelephantTaraScript : _TelephantBaseScript { public override void OnLoad() { base.OnLoad(); SetLocation(401, 100092, 91201, 125); } }
public class TelephantTirScript : _TelephantBaseScript { public override void OnLoad() { base.OnLoad(); SetLocation(1, 13189, 38776, 160); } }
public class TelephantTirAScript : _TelephantBaseScript { public override void OnLoad() { base.OnLoad(); SetLocation(35, 13585, 38385, 125); } }
public class TelephantValesScript : _TelephantBaseScript { public override void OnLoad() { base.OnLoad(); SetLocation(3200, 289848, 212069, 140); } }