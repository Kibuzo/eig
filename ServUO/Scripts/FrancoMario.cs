using System;
using Server.Items;

namespace Server.Mobiles
{
	[TypeAlias("Server.Mobiles.FrancoMario")]
	public class FrancoMario : BaseCreature
	{
		[Constructable]
		public FrancoMario()
			: base(AIType.AI_Fuffaro, FightMode.Closest, 10, 1, 0.2, 0.4)
		{
			bool Fem=false;
			SpeechHue = 19;
			Title = "the amish observatory techician";
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

			SetStr(100, 120);
			SetDex(60, 80);
			SetInt(1, 5);
			SetDamage(1, 2);
			SetHits (80 - 90);

			if (Fem)
			{
				SetStr (80,100);
				SetDex (100,120);
				SetInt (1,5);
				SetHits (60 - 80);
				SetDamage (3,4);
			}

			SetSkill(SkillName.Tactics, 80.0, 85);
			SetSkill(SkillName.Wrestling, 80.0, 85);

			Fame = 8000;
			Karma = -10000;



			Utility.AssignRandomHair(this);
		}

		public FrancoMario(Serial serial)
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
		public override bool AlwaysAttackable
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
			Say ("I give you two hours to excuse yourself");
			return base.OnBeforeDeath();
		}


		public override void GenerateLoot()
		{
			if (Utility.RandomDouble()<1)
			{ 
				AddLoot(LootPack.FilthyRich);
				//AddLoot(LootPack.FrancoMario);
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
					Say ("Hi :), thanks!");
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
					Say ("That's against the rules");
					break;
				case 1:
					Say ("I never tought of a current as a flow of electrons");
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