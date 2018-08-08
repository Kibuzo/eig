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
		this.Hue = 591;
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
		this.Hue = 591;
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
			this.Hue = 591;
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
			this.Name = "Orgonic studded chest";
			this.Hue = 591;
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
				return true;
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
//Studded orgonic gloves
	[FlipableAttribute(0x13d5, 0x13dd)]
	public class OrgonicStuddedGloves : BaseArmor
	{
		[Constructable]
		public OrgonicStuddedGloves()
			: base(0x13D5)
		{
			this.Weight = 1.0;
			this.Hue = 591;
		}

		public OrgonicStuddedGloves(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance
		{
			get
			{
				return 6;
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
				return 9;
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
				return 25;
			}
		}
		public override int OldStrReq
		{
			get
			{
				return 25;
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
		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			if (this.Weight == 2.0)
				this.Weight = 1.0;
		}
	}

//Orgonic Leather Chest
	[FlipableAttribute(0x13cc, 0x13d3)]
	public class OrgonicLeatherChest : BaseArmor
	{
		[Constructable]
		public OrgonicLeatherChest()
			: base(0x13CC)
		{
			this.Weight = 6.0;
			this.Hue = 591;
		}

		public OrgonicLeatherChest(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance
		{
			get
			{
				return 5;
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
				return 13;
			}
		}
		public override int InitMinHits
		{
			get
			{
				return 30;
			}
		}
		public override int InitMaxHits
		{
			get
			{
				return 40;
			}
		}
		public override int AosStrReq
		{
			get
			{
				return 25;
			}
		}
		public override int OldStrReq
		{
			get
			{
				return 15;
			}
		}
		public override int ArmorBase
		{
			get
			{
				return 13;
			}
		}
		public override ArmorMaterialType MaterialType
		{
			get
			{
				return ArmorMaterialType.Leather;
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
				return ArmorMeditationAllowance.All;
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
// Orgonic Leather Gloves
	[Flipable]
	public class OrgonicLeatherGloves : BaseArmor
	{
		public override int BasePhysicalResistance
		{
			get
			{
				return 5;
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
				return 6;
			}
		}

		public override int InitMinHits
		{
			get
			{
				return 30;
			}
		}
		public override int InitMaxHits
		{
			get
			{
				return 40;
			}
		}

		public override int AosStrReq
		{
			get
			{
				return 20;
			}
		}
		public override int OldStrReq
		{
			get
			{
				return 10;
			}
		}

		public override int ArmorBase
		{
			get
			{
				return 5;
			}
		}
		public override ArmorMaterialType MaterialType
		{
			get
			{
				return ArmorMaterialType.Leather;
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
				return ArmorMeditationAllowance.All;
			}
		}

		[Constructable]
		public OrgonicLeatherGloves()
			: base(0x13C6)
		{
			this.Weight = 1.0;
			this.Hue = 591;
		}

		public OrgonicLeatherGloves(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)1); // version

			if (this.IsArcane)
			{
				writer.Write(true);
				writer.Write((int)this.m_CurArcaneCharges);
				writer.Write((int)this.m_MaxArcaneCharges);
			}
			else
			{
				writer.Write(false);
			}
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

			switch ( version )
			{
			case 1:
				{
					if (reader.ReadBool())
					{
						this.m_CurArcaneCharges = reader.ReadInt();
						this.m_MaxArcaneCharges = reader.ReadInt();

						if (this.Hue == 2118)
							this.Hue = ArcaneGem.DefaultArcaneHue;
					}

					break;
				}
			}
		}

		#region Arcane Impl
		private int m_MaxArcaneCharges, m_CurArcaneCharges;

		[CommandProperty(AccessLevel.GameMaster)]
		public int MaxArcaneCharges
		{
			get
			{
				return this.m_MaxArcaneCharges;
			}
			set
			{
				this.m_MaxArcaneCharges = value;
				this.InvalidateProperties();
				this.Update();
			}
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int CurArcaneCharges
		{
			get
			{
				return this.m_CurArcaneCharges;
			}
			set
			{
				this.m_CurArcaneCharges = value;
				this.InvalidateProperties();
				this.Update();
			}
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public bool IsArcane
		{
			get
			{
				return (this.m_MaxArcaneCharges > 0 && this.m_CurArcaneCharges >= 0);
			}
		}

		public void Update()
		{
			if (this.IsArcane)
				this.ItemID = 0x26B0;
			else if (this.ItemID == 0x26B0)
				this.ItemID = 0x13C6;

			if (this.IsArcane && this.CurArcaneCharges == 0)
				this.Hue = 0;
		}

		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);

			if (this.IsArcane)
				list.Add(1061837, "{0}\t{1}", this.m_CurArcaneCharges, this.m_MaxArcaneCharges); // arcane charges: ~1_val~ / ~2_val~
		}

		public override void OnSingleClick(Mobile from)
		{
			base.OnSingleClick(from);

			if (this.IsArcane)
				this.LabelTo(from, 1061837, String.Format("{0}\t{1}", this.m_CurArcaneCharges, this.m_MaxArcaneCharges));
		}

		public void Flip()
		{
			if (this.ItemID == 0x13C6)
				this.ItemID = 0x13CE;
			else if (this.ItemID == 0x13CE)
				this.ItemID = 0x13C6;
		}
		#endregion
	}
}