using System;
using Server.Engines.Craft;

namespace Server.Items
{
    [Alterable(typeof(DefBlacksmithy), typeof(StoneWarSword))]
    [FlipableAttribute(0x13B9, 0x13Ba)]
    public class ClimateSword : BaseSword
    {
        [Constructable]
        public ClimateSword()
            : base(0x13B9)
        {
            this.Weight = 4.0;
            this.Name = "Viking Sword of the climate change";
            WeaponAttributes.HitLightning=100;
        }

        public ClimateSword(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get
            {
                return WeaponAbility.CrushingBlow;
            }
        }
        public override WeaponAbility SecondaryAbility
        {
            get
            {
                return WeaponAbility.ParalyzingBlow;
            }
        }
        public override int AosStrengthReq
        {
            get
            {
                return 80;
            }
        }
        public override int AosMinDamage
        {
            get
            {
                return 16;
            }
        }
        public override int AosMaxDamage
        {
            get
            {
                return 19;
            }
        }
        public override int AosSpeed
        {
            get
            {
                return 28;
            }
        }
        public override float MlSpeed
        {
            get
            {
                return 4.0f;
            }
        }
        public override int OldStrengthReq
        {
            get
            {
                return 40;
            }
        }
        public override int OldMinDamage
        {
            get
            {
                return 6;
            }
        }
        public override int OldMaxDamage
        {
            get
            {
                return 34;
            }
        }
        public override int OldSpeed
        {
            get
            {
                return 30;
            }
        }
        public override int DefHitSound
        {
            get
            {
                return 0x237;
            }
        }
        public override int DefMissSound
        {
            get
            {
                return 0x23A;
            }
        }
        public override int InitMinHits
        {
            get
            {
                return 31;
            }
        }
        public override int InitMaxHits
        {
            get
            {
                return 200;
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

    [Alterable(typeof(DefBlacksmithy), typeof(GargishKryss))]
    [FlipableAttribute(0x1401, 0x1400)]
    public class ClimateKryss : BaseKnife
    {
        [Constructable]
        public ClimateKryss()
            : base(0x1401)
        {
            this.Weight = 1.0;
            this.Name = "Kryss of the climate change";
            WeaponAttributes.HitLightning=100;
        }

        public ClimateKryss(Serial serial)
            : base(serial)
        {
        }

         public override WeaponAbility PrimaryAbility
        {
            get
            {
                return WeaponAbility.ArmorIgnore;
            }
        }
        public override WeaponAbility SecondaryAbility
        {
            get
            {
                return WeaponAbility.InfectiousStrike;
            }
        }
        public override int AosStrengthReq
        {
            get
            {
                return 26;
            }
        }
        public override int AosMinDamage
        {
            get
            {
                return 8;
            }
        }
        public override int AosMaxDamage
        {
            get
            {
                return 10;
            }
        }
        public override int AosSpeed
        {
            get
            {
                return 28;
            }
        }
        public override float MlSpeed
        {
            get
            {
                return 1.75f;
            }
        }
        public override int OldStrengthReq
        {
            get
            {
                return 40;
            }
        }
        public override int OldMinDamage
        {
            get
            {
                return 6;
            }
        }
        public override int OldMaxDamage
        {
            get
            {
                return 34;
            }
        }
        public override int OldSpeed
        {
            get
            {
                return 30;
            }
        }
        public override int DefHitSound
        {
            get
            {
                return 0x23C;
            }
        }
        public override int DefMissSound
        {
            get
            {
                return 0x23A;
            }
        }
        public override int InitMinHits
        {
            get
            {
                return 31;
            }
        }
        public override int InitMaxHits
        {
            get
            {
                return 200;
            }
        }
        public override SkillName DefSkill
        {
            get
            {
                return SkillName.Fencing;
            }
        }
        public override WeaponType DefType
        {
            get
            {
                return WeaponType.Piercing;
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