using System;
using Server.Items;

namespace Server.Mobiles 
{ 
	[CorpseName("A quantumagical corpse")] 
	public class FuffaroMago : BaseCreature 
	{ 
		[Constructable] 
		public FuffaroMago()
			: base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
		{ 
			this.Name = NameList.RandomName("evil mage");
			this.Title = "The quantum mage";
			this.Body = 124;

			this.SetStr(50, 60);
			this.SetDex(50, 60);
			this.SetInt(96, 120);

			this.SetHits(49, 63);

			this.SetDamage(5, 10);

			this.SetDamageType(ResistanceType.Physical, 60);

			this.SetResistance(ResistanceType.Physical, 15, 20);
			this.SetResistance(ResistanceType.Fire, 5, 10);
			this.SetResistance(ResistanceType.Poison, 5, 10);
			this.SetResistance(ResistanceType.Energy, 5, 10);

			this.SetSkill(SkillName.EvalInt, 65.1, 70);
			this.SetSkill(SkillName.Magery, 30, 50.0);
			this.SetSkill(SkillName.MagicResist, 35.0, 57.5);
			this.SetSkill(SkillName.Tactics, 35.0, 57.5);
			this.SetSkill(SkillName.Wrestling, 20.2, 40.0);

			this.Fame = 2500;
			this.Karma = -5500;

			this.VirtualArmor = 16;
			this.PackReg(6);
			this.PackItem(new Robe(Utility.RandomNeutralHue())); // TODO: Proper hue
			this.PackItem(new Sandals());
			switch (Utility.Random(18))
			{
			case 0: PackItem(new BloodOathScroll()); break;
			case 1: PackItem(new CurseWeaponScroll()); break;
			case 2: PackItem(new StrangleScroll()); break;
			}
		}

		public FuffaroMago(Serial serial)
			: base(serial)
		{
		}

		public override bool CanRummageCorpses
		{
			get
			{
				return true;
			}
		}
		public override bool AlwaysMurderer
		{
			get
			{
				return true;
			}
		}
		public override int Meat
		{
			get
			{
				return 1;
			}
		}
		public override int TreasureMapLevel
		{
			get
			{
				return Core.AOS ? 1 : 0;
			}
		}
		public override void GenerateLoot()
		{
			this.AddLoot(LootPack.Average);
			this.AddLoot(LootPack.MedScrolls);
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}
}