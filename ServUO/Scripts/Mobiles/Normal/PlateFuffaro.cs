using System;
using Server.Items;

namespace Server.Mobiles
{
	[TypeAlias("Server.Mobiles.ChainFuffaro")]
	public class PlateFuffaro : BaseCreature
	{
		[Constructable]
		public PlateFuffaro()
			: base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
		{
			bool Fem=false;
			SpeechHue = 18;
			Title = "Captain of the quantum ship";
			Hue = Utility.RandomSkinHue();

			if (Female = Utility.RandomBool())
			{
				Fem = true;
				Body = 0x191;
				Name = NameList.RandomName("female");
				if (Utility.RandomDouble () < 0.1) {
					AddItem (new FemalePlateChest ());
				} 
				else {
					AddItem (new OrgonicPlateChest ());
				}
			}
			else
			{
				Body = 0x190;
				Name = NameList.RandomName("male");
				if (Utility.RandomDouble () < 0.9) {
					AddItem (new PlateChest ());
				} 
				else {
					AddItem (new OrgonicPlateChest ());
				}
			}

			SetStr(101, 115);
			SetDex(96, 111);
			SetInt(1, 5);
			SetDamage(28, 30);
			this.SetHits(150, 180);

			if (Fem)
			{
				SetStr (85,101);
				SetDex (111,131);
				SetInt (1,5);
				SetDamage (30,45);
				this.SetHits(120, 150);
			}

			SetSkill(SkillName.Fencing, 85.0, 90.5);
			SetSkill(SkillName.Macing, 85.0, 90.5);
			SetSkill(SkillName.MagicResist, 35.0, 57.5);
			SetSkill(SkillName.Swords, 85.0, 90.5);
			SetSkill(SkillName.Tactics, 85.0, 90.5);
			SetSkill(SkillName.Wrestling, 25.0, 47.5);

			Fame = 5500;
			Karma = -9500;

			AddItem(new OrgonicBoots(Utility.RandomAnimalHue()));
			AddItem(new PlateGorget());
			AddItem(new PlateArms());
			AddItem (new PlateGloves());
			AddItem (new PlateLegs ());

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

		public PlateFuffaro(Serial serial)
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
					c.DropItem (new OrgonicBoots (591));
					break;
				case 1:
					c.DropItem (new OrgonicKilt (591));
					break;
				case 2:
					c.DropItem (new OrgonicShirt (591));
					break;
				}
			}
		}

		public override void GenerateLoot()
		{
			AddLoot (LootPack.Rich);
			AddLoot (LootPack.Gems, Utility.RandomMinMax(1, 3));
		}

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );
			if (Utility.RandomDouble()<0.5)
			{
				switch ( Utility.Random(4))
				{
				case 0:
					Say ("Everyone's opinion is worth the same");
					break;
				case 1:
					Say ("DO NOT interfere with free discussions");
					break;
				case 2:
					Say ("This guard has been equipped for skeptical protection");
					break;
				case 3:
					Say ("Failure to comply will result in an offensive action");
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
