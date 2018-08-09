using System;
using Server.Items;

namespace Server.Mobiles
{
	[TypeAlias("Server.Mobiles.LeatherFuffaro")]
	public class LeatherFuffaro : BaseCreature
	{
		[Constructable]
		public LeatherFuffaro()
			: base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
		{
			bool Fem=false;
			bool pelle = Utility.RandomBool ();
			SpeechHue = 18;
			Title = "the highly skeptic";
			Hue = Utility.RandomSkinHue();

			if (Female = Utility.RandomBool())
			{
				Fem = true;
				Body = 0x191;
				Name = NameList.RandomName("female");

				if (pelle) {
					if (Utility.RandomDouble () > 0.9) 
					{
						AddItem (new OrgonicBustier ());
					}
					else {
						AddItem (new LeatherBustierArms());
					}
					if (Utility.RandomDouble () > 0.9) 
					{
						AddItem (new OrgonicLeatherGloves ());
					}
					else {
						AddItem (new LeatherGloves());
					}
					AddItem (new LeatherSkirt());
				}

				else {
					if (Utility.RandomDouble () > 0.9) 
					{
						AddItem (new OrgonicFemaleStuddedChest ());
					}
					else {
						AddItem (new FemaleStuddedChest ());
					}
					if (Utility.RandomDouble () > 0.9) 
					{
						AddItem (new OrgonicStuddedGloves ());
					}
					else {
						AddItem (new StuddedGloves());
					}
				}
			}

			else
			{
				Body = 0x190;
				Name = NameList.RandomName("male");

				if (pelle){
					if (Utility.RandomDouble () > 0.9) 
					{
						AddItem (new OrgonicLeatherChest ());
					}
					else {
						AddItem (new LeatherChest());
					}
					if (Utility.RandomDouble () > 0.9) 
					{
						AddItem (new OrgonicLeatherGloves ());
					}
					else {
						AddItem (new LeatherGloves());
					}
					AddItem (new LeatherLegs ());
					AddItem (new LeatherGorget ());
				}
				else
				{
					if (Utility.RandomDouble () > 0.9)
					{
						AddItem(new OrgonicStuddedChest());
					}
					else
					{
						AddItem(new StuddedChest());
					}

					if (Utility.RandomDouble () > 0.9) 
					{
						AddItem (new OrgonicStuddedGloves ());
					}
					else {
						AddItem (new StuddedGloves());
					}

				AddItem(new StuddedLegs());
				AddItem(new StuddedArms());
				AddItem(new LeatherGorget());
				}
			}

			SetStr(86, 100);
			SetDex(81, 95);
			SetInt(1, 5);
			SetDamage(13, 18);

			if (Fem)
			{
				SetStr (70,86);
				SetDex (95,115);
				SetInt (1,5);
				SetDamage (18,25);
			}

			SetSkill(SkillName.Fencing, 45.0, 65.5);
			SetSkill(SkillName.Macing, 45.0, 65.5);
			SetSkill(SkillName.MagicResist, 15.0, 27.5);
			SetSkill(SkillName.Swords, 45.0, 65.5);
			SetSkill(SkillName.Tactics, 45.0, 65.5);
			SetSkill(SkillName.Wrestling, 25.0, 47.5);

			Fame = 2500;
			Karma = -2500;

			AddItem(new OrgonicBoots(Utility.RandomAnimalHue()));

			switch ( Utility.Random(7))
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
				AddItem(new Dagger());
				break;
			case 6:
				AddItem(new Spear());
				break;
			}

			Utility.AssignRandomHair(this);
		}

		public LeatherFuffaro(Serial serial)
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
					Say ("I strongly disagree");
					break;
				case 1:
					Say ("Synchronicity can make yor wavefunction collapse");
					break;
				case 2:
					Say ("We never went to the moon!");
					break;
				case 3:
					Say ("My cousin says so!");
					break;
				case 4:
					Say ("Even Einstein was bad at math!");
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
					Say ("You should study more, ignorant!");
					break;
				case 1:
					Say ("Wikipedia disagrees");
					break;
				case 2:
					Say ("I refuse to talk to close minded people");
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