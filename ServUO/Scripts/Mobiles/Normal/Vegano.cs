using System;
using Server.Items;

namespace Server.Mobiles
{
	[TypeAlias("Server.Mobiles.Vegan")]
	public class Vegan : BaseCreature
	{
		[Constructable]
		public Vegan()
			: base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
		{
			bool Fem=false;
			SpeechHue = 18;
			Title = "the cruelty free";
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

			SetStr(40, 60);
			SetDex(30, 40);
			SetInt(1, 5);
			SetDamage(7, 9);

			if (Fem)
			{
				SetStr (35,50);
				SetDex (40,90);
				SetInt (1,5);
				SetHits (60 - 80);
				SetDamage (5,7);
			}
				
			SetSkill(SkillName.Tactics, 20.0, 45.5);
			SetSkill(SkillName.Wrestling, 25.0, 47.5);

			Fame = 500;
			Karma = -500;



			Utility.AssignRandomHair(this);
		}

		public Vegan(Serial serial)
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
			Say ("Save... the... puppies");
			return base.OnBeforeDeath();
		}

		public override void OnDeath(Container c)
		{
			base.OnDeath(c);

			if (Utility.RandomDouble () < 0.2) {

				switch ( Utility.Random(2))
				{
				case 0:
					c.DropItem (new OrgonicShirt (Utility.RandomNeutralHue()));
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
			AddLoot(LootPack.Poor);
		}

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );
			if (Utility.RandomDouble()<0.5)
			{
				switch ( Utility.Random(4))
				{
				case 0:
					Say ("inissassA!");
					break;
				case 1:
					Say ("Look how strong i became by eating vegetables!");
					break;
				case 2:
					Say ("!enoizesiviv oN");
					break;
				case 3:
					Say ("Guess tofu is not that bad after all!");
					break;
				case 4:
					Say ("Eat this!");
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
					Say ("Poor puppies :(");
					break;
				case 1:
					Say ("You are so cruel :(");
					break;
				case 2:
					Say ("Skinning animals for making armors is just mean");
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

	[TypeAlias("Server.Mobiles.Ambientalista")]
	public class Ambientalista : BaseCreature
	{
		[Constructable]
		public Ambientalista()
			: base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
		{
			bool Fem=false;
			SpeechHue = 18;
			Title = "the anti-system";
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
				SetDamage (2,3);
			}

			SetSkill(SkillName.Tactics, 3.0, 4.5);
			SetSkill(SkillName.Wrestling, 3.0, 4.5);

			Fame = 0;
			Karma = -50;



			Utility.AssignRandomHair(this);
		}

		public Ambientalista(Serial serial)
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
			Say ("Yor poisons killed me");
			return base.OnBeforeDeath();
		}

		public override void OnDeath(Container c)
		{
			base.OnDeath(c);

			if (Utility.RandomDouble () < 0.2) {

				switch ( Utility.Random(2))
				{
				case 0:
					c.DropItem (new OrgonicShirt (Utility.RandomNeutralHue()));
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
			AddLoot(LootPack.Poor);
		}

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );
			if (Utility.RandomDouble()<0.5)
			{
				switch ( Utility.Random(2))
				{
				case 0:
					Say ("Stop poisoning the world!");
					break;
				case 1:
					Say ("Stop ruining our landscape!");
					break;
				case 2:
					Say ("No incinerators!");
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
					Say ("Is this amiantus??");
					break;
				case 1:
					Say ("Ouch, your iron is poisoned!");
					break;
				case 2:
					Say ("Verite ores poison our water!");
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

	[TypeAlias("Server.Mobiles.Amish")]
	public class Amish : BaseCreature
	{
		[Constructable]
		public Amish()
			: base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
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

		public Amish(Serial serial)
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
			{ AddLoot(LootPack.Poor); }
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