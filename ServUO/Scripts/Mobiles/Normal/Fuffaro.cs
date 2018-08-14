using System;
using Server.Items;

namespace Server.Mobiles
{
	[TypeAlias("Server.Mobiles.Fuffaro")]
	public class Fuffaro : BaseCreature
	{
		[Constructable]
		public Fuffaro()
			: base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
		{
			SpeechHue = Utility.RandomDyedHue();
			Title = "the skeptic";
			Hue = Utility.RandomSkinHue();

			if (Female = Utility.RandomBool())
			{
				Body = 0x191;
				Name = NameList.RandomName("female");
				AddItem(new Kilt(Utility.RandomNeutralHue()));
				SetStr(60, 70);
				SetDex(90, 100);
				switch ( Utility.Random(2))
				{
				case 0:
					AddItem(new Kryss());
					break;
				case 1:
					AddItem(new ButcherKnife());
					break;
				case 2:
					AddItem(new Dagger());
					break;
				}
			}
			else
			{
				Body = 0x190;
				Name = NameList.RandomName("male");
				AddItem(new ShortPants(Utility.RandomNeutralHue()));
				SetStr(90, 100);
				SetDex(60, 70);
				switch ( Utility.Random(5))
				{
				case 0:
					AddItem(new Longsword());
					break;
				case 1:
					AddItem(new Cutlass());
					break;
				case 2:
					AddItem(new Broadsword());
					break;
				case 3:
					AddItem(new Axe());
					break;
				case 4:
					AddItem(new Club());
					break;
				case 5:
					AddItem(new Spear());
					break;
				}
			}
			SetInt(1, 5);

			SetDamage(5, 18);

			SetSkill(SkillName.Fencing, 30.0, 55.5);
			SetSkill(SkillName.Macing, 30.0, 55.5);
			SetSkill(SkillName.MagicResist, 15.0, 27.5);
			SetSkill(SkillName.Swords, 30.0, 55.5);
			SetSkill(SkillName.Tactics, 30.0, 55.5);
			SetSkill(SkillName.Wrestling, 15.0, 37.5);

			Fame = 1000;
			Karma = -1000;

			AddItem(new Boots(Utility.RandomNeutralHue()));
			AddItem(new Shirt(Utility.RandomNeutralHue()));
			if (Utility.RandomBool())
			{
				switch (Utility.Random(3))
				{
				case 0:
					AddItem(new FeatheredHat(Utility.RandomNeutralHue()));
					break;
				case 1:
					AddItem(new Bandana(Utility.RandomNeutralHue()));
					break;
				case 2:
					break;
				}
			}
				

			Utility.AssignRandomHair(this);
		}

		public Fuffaro(Serial serial)
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
				return false;
			}
		}

		public override bool OnBeforeDeath()
		{
			Say ("I'm still not convinced by your theory");
			return base.OnBeforeDeath();
		}

		public override void OnDeath(Container c)
		{
			base.OnDeath(c);

			if (Utility.RandomDouble () < 0.2) {

				switch ( Utility.Random(2))
				{
				case 0:
					c.DropItem (new OrgonicBoots (Utility.RandomBlueHue()));
					break;
				case 1:
					c.DropItem (new OrgonicKilt (Utility.RandomBlueHue()));
					break;
				case 2:
					c.DropItem (new OrgonicShirt (Utility.RandomBlueHue()));
					break;
				}
			}
		}

		public override void GenerateLoot()
		{
			AddLoot(LootPack.Poor);
			if (Utility.RandomDouble() > 0.95) {
				AddLoot (LootPack.AosMagicItemsPoor);
			}
			else if (Utility.RandomDouble ()> 0.95) {
				AddLoot (LootPack.AosMagicItemsAverageType1);
			}
		}

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );
			if (Utility.RandomDouble()<0.5)
			{
				switch ( Utility.Random(4))
				{
				case 0:
					Say ("I don't think so");
					break;
				case 1:
					Say ("I'm a naturopath, of course i know quantum mechanics!");
					break;
				case 2:
					Say ("Ighina can make clouds disappear");
					break;
				case 3:
					Say ("I just wished to hit you and it happened!");
					break;
				case 4:
					Say ("Vortex attack!");
					break;
				}
			}
		}

		public override void OnGotMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );
			if (Utility.RandomDouble()<0.5)
			{
				switch ( Utility.Random(2))
				{
				case 0:
					Say ("You are such an arrogant");
					break;
				case 1:
					Say ("Yeah... according to official science, but...");
					break;
				case 2:
					Say ("You know what? I'm getting tired of yor close mind");
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