﻿// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see licence.txt in the main folder

using System;

namespace Common.Constants
{
	[Flags]
	public enum SkillFlags : ushort
	{
		Shown = 0x01,
		CountType = 0x02,
		InUse = 0x04,
		Rankable = 0x08,
		PassiveApplied = 0x10,
		Default = 0xFF80,
	}

	// The client calculates the Dan based on the rank id.
	// 19 = Dan4, 30 = Dan15, etc.
	public enum SkillRank : byte
	{
		Novice = 0, RF = 1, RE = 2, RD = 3, RC = 4, RB = 5, RA = 6, R9 = 7, R8 = 8, R7 = 9, R6 = 10, R5 = 11, R4 = 12, R3 = 13, R2 = 14, R1 = 15, Dan1 = 16, Dan2 = 17, Dan3 = 18
	}

	public enum SkillConst : ushort
	{
		// Life
		Tailoring = 10001,
		AdvancedBookReading = 10002,
		PlayingInstrument = 10003,
		Rest = 10004,
		Compose = 10005,
		MusicalKnowledge = 10006,
		TownCry = 10007,
		CampFire = 10008,
		FirstAid = 10009,
		Collecting = 10010,
		Weaving = 10011,
		Milling = 10012,
		Handicraft = 10013,
		Weaving2 = 10014,
		Refine = 10015,
		Blacksmith = 10016,
		Cooking = 10020,
		Herbalism = 10021,
		PotionMaking = 10022,
		Fishing = 10023,
		MakingMastery = 10024,
		TreasureHunt = 10025,
		AnimalTraining = 10026,
		ControlOar = 10027,
		Metallurgy = 10028,
		ControlAirBalloon = 10029,
		Carpentry = 10033,
		StageTicketMaking = 10036,
		LureOfBallad = 30015,
		WebSpinning = 50005,
		WyvernFireBreath = 50115,

		// Combat
		Defense = 20001,
		Smash = 20002,
		MeleeCounterattack = 20003,
		NaturalShield = 20004,
		HeavyStander = 20005,
		ManaRefractor = 20006,
		FullSwing = 20007,
		FinalSmash = 20008,
		FuryofBard = 20009,
		Jump = 20010,
		Assault = 20011,
		DownAttack = 20012,
		Berserker = 20013,
		BerserkerHidden = 20014,
		LanceCounter = 20016,
		LanceCharge = 20017,
		RangedCombatMastery = 21001,
		MagnumShot = 21002,
		ArrowRevolver = 21003,
		ArrowRevolver2 = 21004,
		Chaingun = 21005,
		SupportShot = 21006,
		MirageMissile = 21007,
		IgniteExplosive = 21008,
		EgoBowIncarnate = 21009,
		ThrowAttack = 21010,
		AirBalloonCrossbowShot = 21011,
		Windmill = 22001,
		Stomp = 22002,
		SelfDestructionActive = 22003,
		FinalHit = 22004,
		EgoSwordIncarnate = 22005,
		EgoBluntIncarnate = 22006,
		GiantStomp = 22007,
		WendigoStomp = 22008,
		CrocodileFullSwing = 22009,
		Roar = 22010,
		CrashShot = 22011,
		InstinctiveReaction = 23001,
		MeleeCombatMastery = 23002,
		CriticalHit = 23003,
		NaturalShieldPassive = 23004,
		HeavyStanderPassive = 23005,
		ManaRefractorPassive = 23006,
		DarkLord = 23007,
		GlasSkill = 23008,
		SelfDestruction = 23010,
		SharpMind = 23011,
		SwordMastery = 23012,
		AxeMastery = 23013,
		BluntMastery = 23014,
		ShieldMastery = 23016,
		DragonTailAttack = 23021,
		StoneBreath = 23022,
		DragonFireBreath = 23023,
		DragonDashAttack = 23024,
		SandWormMeleeAttack = 23025,
		LionBite = 23026,
		LionSwing = 23027,
		WindBreaker = 23028,
		Taunt = 23029,
		FinalShot = 23030,
		ShadowBreath = 23031,
		DarkFlame = 23032,
		LightofSword = 23033,
		ClaimhSolasDashAttack = 23034,
		ClaimhSolasFullSwing = 23035,
		ScarecrowCurse = 23036,
		GriffinRoar = 23037,
		MuralDecorationFirebolt = 23038,
		MuralDecorationIcebolt = 23039,
		MuralDecorationLightning = 23040,
		MuralDecorationArrow = 23041,
		MuralDecorationPoisonGas = 23042,
		Evasion = 23043,
		PythonstoneHeadAttack = 23045,
		PythonstoneBreath = 23046,
		NuadhaStomp = 23047,
		NuadhaLightOfSword = 23050,
		SmashforNuadha = 23051,
		TigerRoar = 23052,
		GrimReaperVerticalAttack = 23053,
		GrimReaperHorizonAttack = 23054,
		GrimReaperWildmill = 23055,
		ArmorBearRoar = 23057,
		ShadowBunshin = 23058,
		BowMastery = 23060,
		CrossbowMastery = 23061,
		LanceMastery = 23062,
		FranShockWave = 23101,
		FranSwing = 23103,
		GoldStrike = 23106,
		Dash = 50104,
		FakeDeathCombat = 50105,
		DragonMeteor = 50110,
		RedDragonFireBreath = 50111,
		DragonRainOfThunder = 50112,
		DragonFear = 50114,
		WyvernLightning = 50116,
		WyvernIceBreath = 50117,
		DragonSupportMeteor = 50119,
		Confusion = 50121,
		NeaghRoar = 50123,
		NeaghTailAttack = 50124,
		NeaghWaterBomb = 50125,
		BeholderBeam = 50129,
		ThrowingAxe = 50131,
		ChandelierAttack = 50132,
		SummonFollower = 50135,
		Boost = 50137,
		RunningBoost = 50144,
		SuperWindmill = 65002,

		// Magic
		ChainCastingofMores = 23009,
		FranDash = 23102,
		Meditation = 30003,
		Enchant = 30004, // do not use?
		Enchant2 = 30005,
		Healing = 30006,
		MagicMastery = 30007,
		PartyHealing = 30008,
		PetMeditation = 30009,
		LifeDrainMagic = 30010,
		MirrorRefuge = 30011,
		MonsterResurrection = 30012,
		YarnBinding = 30013,
		SilentMove = 30014,
		MagicFireMastery = 30016,
		MagicIceMastery = 30017,
		MagicLightningMastery = 30018,
		MagicBoltMastery = 30019,
		MagicWandMastery = 30020,
		MagicStaffMastery = 30021,
		Lightningbolt = 30101,
		Thunder = 30102,
		MagicStoneThunder = 30103,
		InstantThunder = 30104,
		Firebolt = 30201,
		Fireball = 30202,
		NianFireball = 30203,
		MagicStoneFireball = 30204,
		Icebolt = 30301,
		IceSpear = 30302,
		IceHug = 30303,
		SuperIcebolt = 30304,
		SprinkleWater = 30305,
		MagicStoneIceSpear = 30306,
		Hailstorm = 30307,
		EgoWandIncarnate = 30401,
		IceLightning = 30450,
		IceFire = 30451,
		FireLightning = 30452,
		BoltComposer = 30453,
		FireMagicShield = 30460,
		IceMagicShield = 30461,
		LightningMagicShield = 30462,
		NaturalMagicShield = 30463,
		ManaShield = 30464,
		Blaze = 30470,
		PaperAirplaneBomb = 30471,
		InvitationofDeath = 30472,
		FlameofHell = 30473,
		Swallow = 50102,
		BlowBubble = 50103,
		WarpMaster = 50106,
		Detection = 50107,
		PetHide = 50109,
		DeathOfShadow = 50133,
		Thunderstorm = 50136,
		ThunderBreath = 50138,
		Firestorm = 50139,
		FireBreath = 50140,
		PetSummonedIceStorm = 50142,
		FlameDive = 50143,
		PartnerAttack = 50149,
		PetSummonedFrostStorm = 50151,
		IceBreath = 50152,

		// Alchemy
		Dissolution = 10030,
		Synthesis = 10031,
		ManaForming = 35001,
		LifeDrain = 35002,
		AlchemyMastery = 35003,
		WaterCannon = 35004,
		CrystalMaking = 35005,
		ProtectiveWall = 35006,
		WindBlast = 35007,
		Flamer = 35008,
		SandBurst = 35009,
		RainCasting = 35010,
		FrozenBlast = 35011,
		MetalConversion = 35012,
		Spark = 35013,
		HeatBuster = 35014,
		ChainCylinder = 35015,
		AlchemyFireMastery = 35016,
		AlchemyWaterMastery = 35017,
		AlchemyEarthMastery = 35018,
		AlchemyWindMastery = 35019,
		AlchemyCylinderMastery = 35020,
		AlchemyTransmuteMastery = 35021,
		EgoCylinderIncarnate = 35101,
		GolemTransmutation = 50032,
		UseManaForming = 50033,

		// Transformation
		SpiritOfOrder = 40001,
		PowerofOrder = 40002,
		EyeofOrder = 40003,
		SwordofOrder = 40004,
		PaladinNaturalShield = 40011,
		PaladinHeavyStander = 40012,
		PaladinManaRefractor = 40013,
		SoulOfChaos = 41001,
		ControlOfDarkness = 41002,
		BodyOfChaos = 41011,
		BrainOfChaos = 41012,
		HandsOfChaos = 41013,
		DarkNaturalShield = 41021,
		DarkHeavyStander = 41022,
		DarkManaRefractor = 41023,
		RaceTransform = 42001,
		WindMillTrans = 42002,
		FuryOfConnous = 43001,
		ElvenMagicMissile = 43002,
		ArmorofConnous = 43011,
		MindofConnous = 43012,
		SharpnessofConnous = 43013,
		ConnousNaturalShield = 43021,
		ConnousHeavyStander = 43022,
		ConnousManaRefractor = 43023,
		DemonofPhysis = 44001,
		GiantFullSwing = 44002,
		ShieldofPhysis = 44011,
		LifeofPhysis = 44012,
		SpellofPhysis = 44013,
		PhysisNaturalShield = 44021,
		PhysisHeavyStander = 44022,
		PhysisManaRefractor = 44023,

		// Actions
		Sketch = 50013,
		Exploration = 50014,
		FakeDeath = 50016,
		Hide = 50017,
		PublicPerformance = 50018,
		LandMaker = 50019,
		ThrowingStone = 50020,
		DiceThrowing = 50021,
		PartyPerformance = 50022,
		PaperAirplane = 50023,
		WaterBalloonThrowing = 50044,
		InstallUninstallCylinder = 50048,
		Watering = 50126,
		Fertilizing = 50127,
		InsectControl = 50128,
		UseUmbrella = 50146,
		Scarer = 50150,

		// Personas
		WorryofHamlet = 51001,
		IntrigueofClaudius = 51002,
		TearofOphelia = 51003,
		DeclarationofRomeo = 51004,
		PowerofTybalt = 51005,
		HeartofJuliet = 51006,
		FootstepofShylock = 51007,

		// Category 6
		DrawingArtist = 10032,
		NuadhaSpearOfLight = 23048,
		NuadhaFuryOfLight = 23049,
		AwakeningofLight = 45001,
		SpearOfLight = 45002,
		FuryOfLight = 45003,
		AwakeningofLightDisposable = 45004,
		SpearOfLightDisposable = 45005,
		FuryOfLightDisposable = 45006,
		ShadowofSpirit = 45007,
		EclipseofWings = 45008,
		RageofWings = 45009,
		HiddenEnchant = 50001,
		HiddenResurrection = 50002,
		HiddenTownBack = 50003,
		HiddenGuildstoneSetting = 50004,
		HiddenBlessing = 50006,
		CampfireKit = 50007,
		SkillUntrainKit = 50008,
		BigBlessingWaterKit = 50009,
		Dye = 50010,
		EnchantElementalAllSlot = 50011,
		HiddenPoison = 50012,
		HiddenBomb = 50015,
		FossilRestoration = 50025,
		SeesawJump = 50026,
		SeesawCreate = 50027,
		DragonSupport = 50029,
		IceMineKit = 50030,
		Scan = 50031,
		UseSupportItem = 50034,
		UseAntiMacroItem = 50035,
		ItemSeal = 50036,
		ItemUnseal = 50037,
		ItemDungeonPass = 50038,
		UseElathaItem = 50039,
		UseMorrighansFeather = 50050,
		PetBuffing = 50101,
		EatVolcanicBomb = 50113,
		CherryTreeKit = 50118,
		Rotation = 50120,
		NeaghRisingandDiving = 50122,
		AdministrativePicking = 65001,
		BlockWorld = 65003,

		// Category 7
		Gardening = 10034,
		AngerManagement = 20015,
		DaggerMastery = 23015,
		DualWeaponMastery = 23017,
		Pollen = 50040,
		Firecracker = 50041,
		FeedFish = 50042,
		HammerGame = 50043,
		SoulStone = 50045,
		UseItemBomb2 = 50046,
		NameColorChange = 50047,
		HolyFire = 50049,
		MakeFaliasPortal = 50051,
		UseItemChattingColorChange = 50052,
		InstallFacility = 50053,
		RedesignFacility = 50054,
		BeholderAlarm = 50130,
		GachaponSynthesis = 50134,

		// Category 0/?
		InstallKiosk = 10035,
		PythonstoneIndirect = 23044,
		Pillage = 23104,
		RunAway = 23105,
		MakeChocoStatue = 50024,
		Painting = 50055,
		PaintMixing = 50056,
		PetSealToItem = 50108,
		FlownHotAirBalloon = 50145,
		ItemSeal2 = 50147,
		CureZombie = 50148,
		WarpContinent = 50057,
		AddSeasoning = 50058,
	}
}
