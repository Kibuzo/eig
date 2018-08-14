using System;
using Server.Items;

namespace Server.Mobiles
{
	[TypeAlias("Server.Mobiles.ChainFuffaro")]
	public class Ringfuffaro : BaseCreature
	{
		[Constructable]
		public Ringfuffaro()
			: base(AIType.AI_Archer, FightMode.Closest, 10, 1, 0.2, 0.4)
		{
			bool Fem=false;
			SpeechHue = 18;
			Title = "the flat-earther";
			Hue = Utility.RandomSkinHue();

			if (Female = Utility.RandomBool())
			{
				Fem = true;
				Body = 0x191;
				Name = NameList.RandomName("female");
			}
			else
			{
				Body = 0x190;
				Name = NameList.RandomName("male");
			}

			SetStr(86, 100);
			SetDex(91, 105);
			SetInt(1, 5);
			SetDamage(2, 6);
			this.SetHits(120, 150);

			if (Fem)
			{
				SetStr (70,86);
				SetDex (95,115);
				SetInt (1,5);
				SetDamage (4,8);
				this.SetHits(100, 120);
			}

			SetSkill(SkillName.Fencing, 65.0, 75.5);
			SetSkill(SkillName.Macing, 65.0, 75.5);
			SetSkill(SkillName.MagicResist, 35.0, 57.5);
			SetSkill(SkillName.Swords, 65.0, 75.5);
			SetSkill(SkillName.Archery, 50.0, 55.0);
			SetSkill(SkillName.Tactics, 65.0, 65.5);
			SetSkill(SkillName.Wrestling, 25.0, 47.5);

			Fame = 3500;
			Karma = -6500;

			AddItem(new OrgonicBoots(Utility.RandomAnimalHue()));
			if (Utility.RandomDouble>0.9)
			{
				AddItem(new OrgonicStuddedGloves());
			}
			else
			{
				AddItem(new RingmailGloves());
			}
			if (Utility.RandomDouble>0.9)
			{
				AddItem(new OrgonicRingmailLegs());
			}
			else
			{
				AddItem(new RingmailLegs());
			}
			if (fem){
				if (Utility.RandomDouble>0.9)
				{
					AddItem(new OrgonicChainChest());
				}
				else
				{
					AddItem(new RingmailChest());
				}
			}

			switch ( Utility.Random(7))
			{
			case 0:
				AddItem(new Bardiche());
				break;
			case 1:
				AddItem(new Halberd());
				break;
			case 2:
				AddItem(new Broadsword());
				break;
			case 3:
				AddItem(new TwoHandedAxe());
				break;
			case 4:
				AddItem(new QuarterStaff());
				break;
			case 5:
				AddItem(new Spear());
				break;
			case 6:
				AddItem(new WarFork());
				break;
			}

			Utility.AssignRandomHair(this);
		}

		public Ringfuffaro(Serial serial)
			: base(serial)
		{
		}

		public override bool ClickTitle
		{
			get
			{
				return false;
			}
		}
		public override bool AlwaysMurderer
		{
			get
			{
				return true;
			}
		}

		public override bool ShowFameTitle
		{
			get
			{
				return true;
			}
		}

		public override bool OnBeforeDeath()
		{
			Say ("Better dead than autistic");
			return base.OnBeforeDeath();
		}

		public override void OnDeath(Container c)
		{
			base.OnDeath(c);
		}

		public override void GenerateLoot()
		{
			AddLoot(LootPack.Average);
			if (Utility.RandomDouble > 0.95) {
				AddLoot (LootPack.AosMagicItemsPoor);
			}
			else if (Utility.RandomDouble > 0.95) {
				AddLoot (LootPack.AosMagicItemsAverageType1);
			}
		}

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );
			if (Utility.RandomDouble()<0.5)
			{
				switch ( Utility.Random(3))
				{
				case 0:
					Say ("Flu shot!");
					break;
				case 1:
					Say ("Measles shot!");
					break;
				case 2:
					Say ("*Your target says some random bullshit*");
					break;
				case 3:
					Say ("Big pharma better pay you nicely for this!");
					break;
				}
			}
		}


		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}

