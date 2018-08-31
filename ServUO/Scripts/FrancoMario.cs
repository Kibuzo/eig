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
			Title = "the group admin";
			Hue = Utility.RandomSkinHue();

			if (Female = Utility.RandomBool())
			{
				Fem = true;
				Body = 0x191;
				Name = "Franco Mario";
			}
			else
			{
				Body = 0x190;
				Name = "Franco Mario";
			}
			AddItem (new OrgonicKilt(Utility.RandomBlueHue()));
			AddItem (new OrgonicBoots(Utility.RandomBlueHue()));
			AddItem (new OrgonicShirt(Utility.RandomBlueHue()));

			SetStr(400, 420);
			SetDex(160, 180);
			SetInt(1, 5);
			SetDamage(18, 20);
			SetHits (300 - 400);

			SetSkill(SkillName.Tactics, 80.0, 85);
			SetSkill(SkillName.Wrestling, 80.0, 85);

			Fame = 10000;
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
				AddLoot(LootPack.FuffaroBoss);
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