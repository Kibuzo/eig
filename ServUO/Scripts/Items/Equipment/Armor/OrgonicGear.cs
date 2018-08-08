using System;

namespace Server.Items
{
	[FlipableAttribute(0x13bf, 0x13c4)]
	public class OrgonicShirt : BaseArmor
	{
	[Constructable]
		public OrgonicShirt(int hue)
			: base(0x1517) //questo è l'id della shirt, se lo cambi ha un altro aspetto iniziale
	{
		this.Weight = 1.0;
		this.Name = "An orgonic shirt";
		this.Hue = 97;
	}

	public OrgonicShirt(Serial serial)
		: base(serial)
	{
	}

	public override int BasePhysicalResistance
	{
		get
		{
			return 4;
		}
	}
	public override int BaseFireResistance
	{
		get
		{
			return 4;
		}
	}
	public override int BaseColdResistance
	{
		get
		{
			return 4;
		}
	}
	public override int BasePoisonResistance
	{
		get
		{
			return 1;
		}
	}
	public override int BaseEnergyResistance
	{
		get
		{
			return 10;
		}
	}
	public override int InitMinHits
	{
		get
		{
			return 45;
		}
	}
	public override int InitMaxHits
	{
		get
		{
			return 60;
		}
	}
	public override int AosStrReq
	{
		get
		{
			return 10;
		}
	}
	public override int OldStrReq
	{
		get
		{
			return 10;
		}
	}
	public override int OldDexBonus
	{
		get
		{
			return -0;
		}
	}
	public override int ArmorBase
	{
		get
		{
			return 28;
		}
	}
	public override ArmorMaterialType MaterialType
	{
		get
		{
			return ArmorMaterialType.Cloth;
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

//ORGONIC LEGS

[FlipableAttribute(0x13be, 0x13c3)]
public class OrgonicKilt : BaseArmor
{
	[Constructable]
	public OrgonicKilt(int hue)
		: base(0x1537) //questo è l'id della shirt, se lo cambi ha un altro aspetto iniziale
	{
		this.Weight = 1.0;
		this.Name = "An orgonic kilt";
		this.Hue = 97;
	}

	public OrgonicKilt(Serial serial)
		: base(serial)
	{
	}

	public override int BasePhysicalResistance
	{
		get
		{
			return 4;
		}
	}
	public override int BaseFireResistance
	{
		get
		{
			return 4;
		}
	}
	public override int BaseColdResistance
	{
		get
		{
			return 4;
		}
	}
	public override int BasePoisonResistance
	{
		get
		{
			return 1;
		}
	}
	public override int BaseEnergyResistance
	{
		get
		{
			return 10;
		}
	}
	public override int InitMinHits
	{
		get
		{
			return 45;
		}
	}
	public override int InitMaxHits
	{
		get
		{
			return 60;
		}
	}
	public override int AosStrReq
	{
		get
		{
			return 10;
		}
	}
	public override int OldStrReq
	{
		get
		{
			return 10;
		}
	}
	public override int OldDexBonus
	{
		get
		{
			return -0;
		}
	}
	public override int ArmorBase
	{
		get
		{
			return 28;
		}
	}
	public override ArmorMaterialType MaterialType
	{
		get
		{
			return ArmorMaterialType.Cloth;
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

// Orgonic boots

[FlipableAttribute(0x2FC4, 0x317A)]
public class OrgonicBoots : BaseShoes
{
	public override CraftResource DefaultResource
	{
		get
		{
			return CraftResource.RegularLeather;
		}
	}

	[Constructable]
	public OrgonicBoots()
		: this(0)
	{
	}

	[Constructable]
	public OrgonicBoots(int hue)
		: base(0x2FC4, hue)
	{
		this.Weight = 2.0;
		this.Name = "Orgonic Boots";
	}

	public OrgonicBoots(Serial serial)
		: base(serial)
	{
	}

	public override bool Dye(Mobile from, DyeTub sender)
	{
		return false;
	}

	public override void Serialize(GenericWriter writer)
	{
		base.Serialize(writer);

		writer.WriteEncodedInt(0); // version
	}

	public override void Deserialize(GenericReader reader)
	{
		base.Deserialize(reader);

		int version = reader.ReadEncodedInt();
	}
	public override int BasePhysicalResistance
	{
		get
		{
				return (Utility.Random(3)+4);
		}
	}
	public override int BaseFireResistance
	{
		get
		{
			return 4;
		}
	}
	public override int BaseColdResistance
	{
		get
		{
			return 4;
		}
	}
	public override int BasePoisonResistance
	{
		get
		{
			return 1;
		}
	}
	public override int BaseEnergyResistance
	{
		get
		{
			return 15;
		}
	}
	public override int InitMinHits
	{
		get
		{
			return 45;
		}
	}
	public override int InitMaxHits
	{
		get
		{
			return 60;
		}
	}
	public override int AosStrReq
	{
		get
		{
			return 10;
		}
	}
	public override int OldStrReq
	{
		get
		{
			return 10;
		}
	}
	
}

//Orgonic female studded chest
	[FlipableAttribute(0x1c02, 0x1c03)]
	public class OrgonicFemaleStuddedChest : BaseArmor
	{
		[Constructable]
		public OrgonicFemaleStuddedChest()
			: base(0x1C02)
		{
			this.Weight = 6.0;
			this.Name = "Orgonic female studded chest";
			this.Hue = 97;
		}

		public OrgonicFemaleStuddedChest(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance
		{
			get
			{
				return (Utility.Random(2)+6);
			}
		}
		public override int BaseFireResistance
		{
			get
			{
				return 4;
			}
		}
		public override int BaseColdResistance
		{
			get
			{
				return 3;
			}
		}
		public override int BasePoisonResistance
		{
			get
			{
				return 3;
			}
		}
		public override int BaseEnergyResistance
		{
			get
			{
				return 4;
			}
		}
		public override int InitMinHits
		{
			get
			{
				return 35;
			}
		}
		public override int InitMaxHits
		{
			get
			{
				return 45;
			}
		}
		public override int AosStrReq
		{
			get
			{
				return 35;
			}
		}
		public override int OldStrReq
		{
			get
			{
				return 35;
			}
		}
		public override int ArmorBase
		{
			get
			{
				return 16;
			}
		}
		public override ArmorMaterialType MaterialType
		{
			get
			{
				return ArmorMaterialType.Studded;
			}
		}
		public override CraftResource DefaultResource
		{
			get
			{
				return CraftResource.RegularLeather;
			}
		}
		public override ArmorMeditationAllowance DefMedAllowance
		{
			get
			{
				return ArmorMeditationAllowance.Half;
			}
		}
		public override bool AllowMaleWearer
		{
			get
			{
				return false;
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

			if (this.Weight == 1.0)
				this.Weight = 6.0;
		}
	}

//Orgonic studded chest
	[FlipableAttribute(0x13db, 0x13e2)]
	public class OrgonicStuddedChest : BaseArmor
	{
		[Constructable]
		public OrgonicStuddedChest()
			: base(0x13DB)
		{
			this.Weight = 6.0;
			this.Name = "Orgonic female studded chest";
			this.Hue = 97;
		}

		public OrgonicStuddedChest(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance
		{
			get
			{
				return (Utility.Random(2)+6);
			}
		}
		public override int BaseFireResistance
		{
			get
			{
				return 4;
			}
		}
		public override int BaseColdResistance
		{
			get
			{
				return 3;
			}
		}
		public override int BasePoisonResistance
		{
			get
			{
				return 3;
			}
		}
		public override int BaseEnergyResistance
		{
			get
			{
				return 4;
			}
		}
		public override int InitMinHits
		{
			get
			{
				return 35;
			}
		}
		public override int InitMaxHits
		{
			get
			{
				return 45;
			}
		}
		public override int AosStrReq
		{
			get
			{
				return 35;
			}
		}
		public override int OldStrReq
		{
			get
			{
				return 35;
			}
		}
		public override int ArmorBase
		{
			get
			{
				return 16;
			}
		}
		public override ArmorMaterialType MaterialType
		{
			get
			{
				return ArmorMaterialType.Studded;
			}
		}
		public override CraftResource DefaultResource
		{
			get
			{
				return CraftResource.RegularLeather;
			}
		}
		public override ArmorMeditationAllowance DefMedAllowance
		{
			get
			{
				return ArmorMeditationAllowance.Half;
			}
		}
		public override bool AllowMaleWearer
		{
			get
			{
				return false;
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

			if (this.Weight == 1.0)
				this.Weight = 6.0;
		}
	}
}