using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enchant 
{
    /// <summary>
    /// Holds the enchantment data
    /// </summary>
    
    // The type of enchant this enchant is
    public EnchantTypes type;
    // The Enchants Damage Type
    public Damage.DamageType e_dType;
    // The Enchants Damage Type
    public Damage_OT.Damage_OTType e_doType;
    // The level of strength this enchant has
    public int level = 0;
    // The value of this enchant
    public float enchantValue = 0.00f;
    // Has it been consolidated with another enchant
    public bool consolidated = false;
    // Has it been rejected
    public bool rejected = false;
    // Enchant Power
    public int power;

    private Item.ItemTypes i_type = Item.ItemTypes.NONE;

    #region Enchant Stats

    public int
        strength = 0,
        dexterity = 0,
        intellect = 0,
        endurance = 0,
        vitality = 0,
        agility = 0,
        luck = 0,

        p_damage = 0,
        w_damage = 0,

        fire_damage = 0,
        water_damage = 0,
        ice_damage = 0,
        thunder_damage = 0,
        wind_damage = 0,
        earth_damage = 0,
        light_damage = 0,
        dark_damage = 0,

        soul_damage = 0,

        bleeding_damage = 0,
        poison_damage = 0,
        aether_damage = 0,

        p_Resist = 0,

        fire_Resist = 0,
        water_Resist = 0,
        ice_Resist = 0,
        thunder_Resist = 0,
        wind_Resist = 0,
        earth_Resist = 0,
        light_Resist = 0,
        dark_Resist = 0,

        soul_Resist = 0,

        bleeding_Resist = 0,
        poison_Resist = 0,
        aether_Resist = 0,

        healthPoints = 0,
        spellPoints = 0,
        energyPoints = 0,
        perception = 0,
        ferocity = 0,
        speed = 0,
        evasion = 0,
        spirit = 0,
        wisdom = 0,
        armor_Pen = 0,
        spell_Pen = 0,

        magic_chance = 0,
        currency_percent = 0,
        damage_percent = 0,
        life_percent = 0,
        spell_percent = 0,
        energy_percent = 0,
        lifesteal_percent = 0;

    #endregion

    public enum EnchantTypes
    {
        Primary,
        Secondary,
        Tertiary,
        Resistance,
        Damage_T1,
        Damage_T2,
        Damage_T3,
        NONE = 1001
    }

    public Enchant(Item.ItemTypes t = Item.ItemTypes.NONE ,EnchantTypes e = EnchantTypes.NONE)
    {
        i_type = t;
        type = e;
    }

    // Enchants name
    private string enchant_Name;

    // Enchants plurel name
    private string p_enchant_Name;

    // Enchants Stats Bonus
    private string enchant_bonus_Text;

    // Enchants discription
    private string enchant_desc;

    // Enchant Index
    int indexA = 0; // Generic
    int indexB = 0; // Specific

    Enchant_Database.Primary_Stats_Enchants ePrimary        = Enchant_Database.Primary_Stats_Enchants.None;
    Enchant_Database.Secondary_Stats_Enchants eSecondary    = Enchant_Database.Secondary_Stats_Enchants.None;
    Enchant_Database.Tertiary_Stats_Enchants eTertiary      = Enchant_Database.Tertiary_Stats_Enchants.None;
    Enchant_Database.Tier1_Damage_Enchants eT1              = Enchant_Database.Tier1_Damage_Enchants.None;
    Enchant_Database.Tier2_Damage_Enchants eT2              = Enchant_Database.Tier2_Damage_Enchants.None;
    Enchant_Database.Tier3_Damage_Enchants eT3              = Enchant_Database.Tier3_Damage_Enchants.None;
    Enchant_Database.Resistance_Enchants eResistance        = Enchant_Database.Resistance_Enchants.None;

    public void Start()
    {
        type = EnchantTypes.NONE;
    }

    public void SetEnchantItemType(Item.ItemTypes item_type)
    {
        i_type = item_type;
    }

    // Returns A New Enchant (default is 999 for random) 
    public Enchant GetNewEnchant(Item i, int itemLevel, bool hasFirst = false)
    {
        // set the enchant level to the item level
        level = itemLevel;
        // set the type by choice or random (-1)
        type = PickEnchantType(i.GetEnchantTypeNum(), hasFirst);
        // set the enchants item type
        i_type = i.itemType;
        indexA = (int)type;
        if (i_type == Item.ItemTypes.Weapon)
        {
            w_damage = (int)((i.minDamage + i.maxDamage)/2f);
        }

        // If the type is a primary enchant type
        if (type == EnchantTypes.Primary)
        {
            // while the primary enchant is none, keep getting another primary
            while (ePrimary == Enchant_Database.Primary_Stats_Enchants.None)
            {
                ePrimary = Enchant_Database.GetPrimaryEnchant(this,i.GetSpecificEnchantTypeNum(),i.itemQuality);
                indexB = (int)ePrimary;
            }
        }
        // If the type is a secondary enchant type
        else if (type == EnchantTypes.Secondary)
        {
            // while the secondary enchant is none, keep getting another secondary
            while (eSecondary == Enchant_Database.Secondary_Stats_Enchants.None)
            {
                eSecondary = Enchant_Database.GetSecondaryEnchant(this, i.GetSpecificEnchantTypeNum());
                indexB = (int)eSecondary;
            }
        }
        // If the type is a tertiary enchant type
        else if (type == EnchantTypes.Tertiary)
        {
            // while the tertiary is none, keep getting a new tertiary enchant
            while (eTertiary == Enchant_Database.Tertiary_Stats_Enchants.None)
            {
                eTertiary = Enchant_Database.GetTertiaryEnchant(this, i.GetSpecificEnchantTypeNum());
                indexB = (int)eTertiary;
            }
        }
        // If the type is of Teir 1 damage enchant
        else if (type == EnchantTypes.Damage_T1)
        {
            // keep getting another damage enchant of teir 1
            while(eT1 == Enchant_Database.Tier1_Damage_Enchants.None)
            {
                eT1 = Enchant_Database.GetTierOneDamageEnchant(this, i.GetSpecificEnchantTypeNum());
                indexB = (int)eT1;
            }
        }
        // If the type is of Teir 2 damage enchant
        else if (type == EnchantTypes.Damage_T2)
        {
            // keep getting another damage enchant of teir 2
            while (eT2 == Enchant_Database.Tier2_Damage_Enchants.None)
            {
                eT2 = Enchant_Database.GetTierTwoDamageEnchant(this, i.GetSpecificEnchantTypeNum());
                indexB = (int)eT2;
            }
        }
        // if the type is of Teir 3 damage enchant
        else if (type == EnchantTypes.Damage_T3)
        {
            // keep getting another damage enchant of teir 3
            while (eT3 == Enchant_Database.Tier3_Damage_Enchants.None)
            {
                eT3 = Enchant_Database.GetTierThreeDamageEnchant(this, i.GetSpecificEnchantTypeNum());
                indexB = (int)eT3;
            }
        }
        // If the type of enchant is resistance
        else if (type == EnchantTypes.Resistance)
        {
            // Keep getting a resistance enchant until it is not none
            while (eResistance == Enchant_Database.Resistance_Enchants.None)
            {
                eResistance = Enchant_Database.GetResistanceEnchant(this, i.GetSpecificEnchantTypeNum());
                indexB = (int)eResistance;
            }
        }
        else
        {
            Debug.Log("ERROR :: No enchant type was found (::GetNewEnchant())");
        }
        
        
        return this;
    }

    // Gets Index A + B
    public int GetIndexA()
    {
        return indexA;
    }
    public int GetIndexB()
    {
        return indexB;
    }


    // Returns The Enchants Type
    public EnchantTypes PickEnchantType(int i, bool hasFirst)
    {
        // If 'i' is not the default value of '999' (999 meaning random)

        if (i == 0)
        {
            return EnchantTypes.Primary;
        }
        else if (i == 1)
        {
            return EnchantTypes.Secondary;
        }
        else if (i == 2)
        {
            return EnchantTypes.Tertiary;
        }
        else if (i == 3)
        {
            return EnchantTypes.Resistance;
        }
        else if (i == 4)
        { 
            return EnchantTypes.Damage_T1;
        }
        else if (i == 5)
        {
            return EnchantTypes.Damage_T2;
        }
        else if (i == 6)
        {
            return EnchantTypes.Damage_T3;
        }
        // else 'i' is random (999)
        else
        {
            if (i_type == Item.ItemTypes.Weapon)
            {
                // if the item level is 15 or lower set the enchant to only have one possible damage enchant (tier 1)
                if (level < 15)
                {
                    if (hasFirst) return (EnchantTypes)Random.Range(0, 4);
                    else return (EnchantTypes)Random.Range(0, 5);
                }
                // else if the item level is higher than 14 but lower than 45, set the first possible damage to be Teir 2, then tier 1
                else if (level >= 15 && level < 45)
                {
                    if (hasFirst) return (EnchantTypes)Random.Range(0, 5);
                    else return (EnchantTypes)Random.Range(0, 6);
                }
                // else if the level is higher than 44 and lower than 70 than first possible to be tier 3, then tier 2 or 1
                else if (level >= 45 && level < 70)
                {
                    if (hasFirst) return (EnchantTypes)Random.Range(0, 6);
                    else return (EnchantTypes)Random.Range(0, 7);
                }
                // else if the level is higher than 69 than make all damage enchants possible tier 3
                else if (level >= 70)
                {
                    if (hasFirst) return (EnchantTypes)Random.Range(0, 7);
                    else return (EnchantTypes)Random.Range(0, 7);
                }
                // if for some reason the level is fucked, send nothing
                else
                {
                    return EnchantTypes.NONE;
                }
            }
            else
            {
                return (EnchantTypes)Random.Range(0, 4);
            }
        }
    } 

    // Get Enchant Description
    public string GetEnchantDesc()
    {
        return enchant_desc;
    }

    // Set Enchant Description
    public void SetEnchantDesc(string s)
    {
        enchant_desc = s;
    }

    // Set Enchant Name
    public void SetEnchantName(string n , bool plurel = false)
    {
        if (plurel)
        {
            p_enchant_Name = n;
        }
        else
        {
            enchant_Name = n;
        }
    }

    // Returns The Name Of Enchant (plurel or not)
    public string GetEnchantName(bool plurel = false)
    {
        if(p_enchant_Name == "" || p_enchant_Name == null)
        {
            return enchant_Name;
        }
        return (plurel) ? p_enchant_Name : enchant_Name;
    }
    
    public string GetEnchantStatText()
    {
        return enchant_bonus_Text;
    }

    public void SetBonusStatText(string s)
    {
        enchant_bonus_Text = "+ " + s;
    }

}
