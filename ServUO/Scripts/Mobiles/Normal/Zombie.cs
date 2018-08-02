using System;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a rotting corpse")]
    public class Zombie : BaseCreature
    {
        [Constructable]
        public Zombie()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "a zombie";
            Body = 3;
            BaseSoundID = 471;

            SetStr(36, 50);
            SetDex(4, 8);
            SetInt(4, 8);

            SetHits(88, 102);

            SetDamage(6, 10);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 7, 15);
            SetResistance(ResistanceType.Cold, 20, 30);
            SetResistance(ResistanceType.Poison, 5, 10);

            SetSkill(SkillName.MagicResist, 15.1, 40.0);
            SetSkill(SkillName.Tactics, 30, 50);
            SetSkill(SkillName.Wrestling, 30, 50.0);

            Fame = 900;
            Karma = -900;

            VirtualArmor = 18;

            PackBodyPartOrBones();
        }

        public Zombie(Serial serial)
            : base(serial)
        {
        }

        public override bool BleedImmune
        {
            get
            {
                return true;
            }
        }
        public override Poison PoisonImmune
        {
            get
            {
                return Poison.Regular;
            }
        }

        public override TribeType Tribe { get { return TribeType.Undead; } }

        public override OppositionGroup OppositionGroup
        {
            get
            {
                return OppositionGroup.FeyAndUndead;
            }
        }
        public override void GenerateLoot()
        {
            AddLoot(LootPack.Meager);
        }

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );
			if (Utility.RandomDouble()<0.25)
			{
				switch ( Utility.Random(3))
				{
				case 0:
					Say ("Braaains");
					break;
				case 1:
					Say ("BRAAAAAAA.. Cough Cough");
					break;
				case 2:
					Say ("Braaaain... oh wait, i tought you were someone else");
					break;
				case 3:
					Say ("Braaaains, i said!");
					break;
				}
			}
		}

		public override void OnGotMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );
			if (Utility.RandomDouble()<0.25)
			{
				switch ( Utility.Random(3))
				{
				case 0:
					Say ("Yeah, whatever... I'm already dead anyway");
					break;
				case 1:
					Say ("uuuuuuuOuch! that hurts!");
					break;
				case 2:
					Say ("Have youuuh seen mah finger?");
					break;
				case 3:
					Say ("now i need more braaains");
					break;
				}
			}
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
