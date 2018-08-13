using System;
using Server.Items;

namespace Server.Mobiles
{
	[TypeAlias("Server.Mobiles.ChainFuffaro")]
	public class ChainFuffaro : BaseCreature
	{
		[Constructable]
		public ChainFuffaro()
			: base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
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
			SetDex(81, 95);
			SetInt(1, 5);
			SetDamage(15, 20);
			this.SetHits(120, 150);

			if (Fem)
			{
				SetStr (70,86);
				SetDex (95,115);
				SetInt (1,5);
				SetDamage (20,25);
				this.SetHits(100, 120);
			}

			SetSkill(SkillName.Fencing, 65.0, 75.5);
			SetSkill(SkillName.Macing, 65.0, 75.5);
			SetSkill(SkillName.MagicResist, 35.0, 57.5);
			SetSkill(SkillName.Swords, 65.0, 75.5);
			SetSkill(SkillName.Tactics, 65.0, 65.5);
			SetSkill(SkillName.Wrestling, 25.0, 47.5);

			Fame = 3500;
			Karma = -6500;

			AddItem(new OrgonicBoots(Utility.RandomAnimalHue()));
			AddItem(new ChainCoif());
			AddItem(new ChainLegs());
			AddItem(new ChainChest());

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

		public ChainFuffaro(Serial serial)
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
			Say ("You only wasted my time");
			return base.OnBeforeDeath();
		}

		public override void OnDeath(Container c)
		{
			base.OnDeath(c);

			if (Utility.RandomDouble () < 0.2) {

				switch ( Utility.Random(2))
				{
				case 0:
					c.DropItem (new OrgonicBoots (Utility.RandomNeutralHue()));
					break;
				case 1:
					c.DropItem (new OrgonicKilt (Utility.RandomNeutralHue()));
					break;
				case 2:
					c.DropItem (new OrgonicShirt (Utility.RandomNeutralHue()));
					break;
				}
			}
		}

		public override void GenerateLoot()
		{
			AddLoot(LootPack.Average);
		}

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );
			if (Utility.RandomDouble()<0.5)
			{
				switch ( Utility.Random(4))
				{
				case 0:
					Say ("The earth is flat");
					break;
				case 1:
					Say ("All is relative");
					break;
				case 2:
					Say ("We never went to the moon!");
					break;
				case 3:
					Say ("My cousin says so!");
					break;
				case 4:
					Say ("Die, scumbag!");
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
