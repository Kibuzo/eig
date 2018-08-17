using System;
using Server.Items;

namespace Server.Mobiles
{
	[TypeAlias("Server.Mobiles.AmishAstronomer")]
	public class AmishAstronomer : BaseCreature
	{
		[Constructable]
		public AmishAstronomer()
			: base(AIType.AI_Fuffaro, FightMode.Closest, 10, 1, 0.2, 0.4)
		{
			bool Fem=false;
			SpeechHue = 19;
			Title = "the amish";
			Hue = Utility.RandomSkinHue();

			switch (Utility.Random (2)) {
			case 0:
				AddItem (new Carrot());
				break;
			case 1:
				AddItem (new Squash());
				break;
			case 2:
				AddItem (new Pumpkin());
				break;
			}

			AddItem (new SheafOfHay ());
			AddItem (new Shirt(Utility.RandomNeutralHue()));
			AddItem (new Shoes (Utility.RandomNeutralHue()));

			if (Female = Utility.RandomBool())
			{
				Fem = true;
				Body = 0x191;
				Name = NameList.RandomName("female");
				AddItem (new Skirt(Utility.RandomNeutralHue()));
			}
			else
			{
				Body = 0x190;
				Name = NameList.RandomName("male");
				AddItem (new LongPants (Utility.RandomNeutralHue()));
			}

			SetStr(40, 60);
			SetDex(30, 40);
			SetInt(1, 5);
			SetDamage(1, 2);
			SetHits (80 - 90);

			if (Fem)
			{
				SetStr (35,50);
				SetDex (40,90);
				SetInt (1,5);
				SetHits (60 - 80);
				SetDamage (3,4);
			}

			SetSkill(SkillName.Tactics, 3.0, 7.5);
			SetSkill(SkillName.Wrestling, 3.0, 7.5);

			Fame = 0;
			Karma = 0;



			Utility.AssignRandomHair(this);
		}

		public AmishAstronomer(Serial serial)
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
			Say ("Manners sir, manners!");
			return base.OnBeforeDeath();
		}


		public override void GenerateLoot()
		{
			if (Utility.RandomDouble()<0.2)
			{ 
				AddLoot(LootPack.Poor);
				AddLoot(LootPack.AstronomerAmish);
			}
		}

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );
			if (Utility.RandomDouble()<0.5)
			{
				switch ( Utility.Random(1))
				{
				case 0:
					Say ("I don't use kosher salt, I don't see why i should");
					break;
				case 1:
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
					Say ("Manners sir, manners!");
					break;
				case 1:
					Say ("Oh, bloody hell!");
					break;
				case 2:
					Say ("");
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