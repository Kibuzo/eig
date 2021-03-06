using System;

namespace Server.Items
{
    public class DragonHideShield : GargishKiteShield
	{
		public override bool IsArtifact { get { return true; } }
        [Constructable]
        public DragonHideShield()
            : base()
        {		
			Hue = 44;	
            AbsorptionAttributes.EaterFire = 20;
            Attributes.RegenHits = 2;
            Attributes.DefendChance = 10;
        }

        public DragonHideShield(Serial serial)
            : base(serial)
        {
        }
        
        public override int LabelNumber { get{return 1113532;} }// Dragon Hide Shield

        public override int BasePhysicalResistance
        {
            get
            {
                return 15;
            }
        }
        public override int BaseFireResistance
        {
            get
            {
                return 0;
            }
        }
        public override int BaseColdResistance
        {
            get
            {
                return 0;
            }
        }
        public override int BasePoisonResistance
        {
            get
            {
                return 0;
            }
        }
        public override int BaseEnergyResistance
        {
            get
            {
                return -4;
            }
        }
        public override int InitMinHits
        {
            get
            {
                return 255;
            }
        }
        public override int InitMaxHits
        {
            get
            {
                return 255;
            }
        }
		
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);//version
        }
    }
}
