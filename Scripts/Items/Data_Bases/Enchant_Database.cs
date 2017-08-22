using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enchant_Database {

    public static float lMod = 9f;
    public static float mMod = 6f;
    public static float hMod = 3f;

    public enum Primary_Stats_Enchants
    {
        // Combo Stats
        None,                      
        Strength,       // +(P)Damage,      +(C)Damage
        Dexterity,      // +(C)Chance,      +(C)Damage
        Intellect,      // +(M)Damage,      +(M)Resist
        Endurance,      // +Energy,         +(P)Resist
        Vitality,       // +Health,         + ?
        Agility,        // +Speed,          +Evasion
        Luck,           // +(%)ItemChance,  +(%)CurrencyDrop

    }
    public enum Secondary_Stats_Enchants
    {
        // Secondaries
        None,
        Physical_Damage,            // Damage done physically
        Magical_Damage,             // Damage done magically
        Physical_resistance,        // Physical damage resisted
        Health_Points,              // Life Points
        Spell_Points,               // Magic Points
        Energy_Points,              // Energy Points
        Perception,                 // Critical Chance
        Ferocity,                   // Critical Damage
        Speed,                      // Movement Speed
        Evasion,                    // Evasion Chance
        Spirit,                     // Health Regen
        Wisdom,                     // Mana Regen
        Armor_Penetration,          // Physical Armor Bypass
        Spell_Penetration,          // Magical Armor Bypass
    }
    public enum Tertiary_Stats_Enchants
    {
        // % stats
        None,
        Magic_Drop_Chance,          // Increases item grade chance
        Currency_Increase_Percent,  // Increases money amount dropped
        Damage_Percent,             // Increases overall damage
        Life_Points_Percent,        // Increases overall Lifepoints
        Spell_Points_Percent,       // Increases overall Spellpoints
        Energy_Points_Percent,      // Increases overall Energypoints
        Lifesteal_Percent,          // Damage done returned in %
    }

    public enum Resistance_Enchants
    {
        // Magical
        None,
        Fire_Resistance,
        Water_Resistance,
        Ice_Resistance,
        Thunder_Resistance,
        Wind_Resistance,
        Earth_Resistance,
        Light_Resistance,
        Dark_Resistance,

        // Physical
        Bleeding_Resistance,
        Poison_Resistance,
        Aether_Resistance,

        // Neither
        Soul_Resistance,

    }

    public enum Tier1_Damage_Enchants
    {
        None,
        Blood1,
        Poison1,
        Physical1,
        Fire1,
        Ice1,
        Water1,
        Lightning1,
        Earth1,
        Light1,
        Dark1,
        Aether1,
        Wind1,
        Soul1
    }
    public enum Tier2_Damage_Enchants
    {
        None,
        Blood2,
        Poison2,
        Physical2,
        Fire2,
        Ice2,
        Water2,
        Lightning2,
        Earth2,
        Light2,
        Dark2,
        Aether2,
        Wind2,
        Soul2
    }
    public enum Tier3_Damage_Enchants
    {
        None,
        Blood3,
        Poison3,
        Physical3,
        Fire3,
        Ice3,
        Water3,
        Lightning3,
        Earth3,
        Light3,
        Dark3,
        Aether3,
        Wind3,
        Soul3
    }

    // Returns A Primary Enchant
    public static Primary_Stats_Enchants GetPrimaryEnchant(Enchant e, int c = -1, Item.ItemQualityModifiers quality = Item.ItemQualityModifiers.Basic)
    {
        float qMod = 1f;
        if((int)quality > 1)
        {
            qMod = ((int)quality / 1.75f) + 1f;
        }
        int i = 0;
        if (c == -1)
        {
            i = Random.Range(0, 7);
        }
        else
        {
            i = c;
        }
        int j = Random.Range(1, 4);

        if (i == 0)
        {
            e.SetEnchantName("Strength");
            if (j == 1)
            {
                e.SetEnchantDesc("You feel stronger when this is equipped.");
            }
            else if (j == 2)
            {
                e.SetEnchantDesc("Your criticals will do more damage.");
            }
            else if (j == 3)
            {
                e.SetEnchantDesc("Your physical attacks will do more damage.");
            }
            e.strength = Random.Range(((int)qMod * ((int)(e.level / 4.5f + 1))), (3 * ((int)(e.level / 5f + 1))));
            e.power = e.strength;
            e.SetBonusStatText(e.strength.ToString() + " Strength");
            e.enchantValue = 1.75f;
            return Primary_Stats_Enchants.Strength;
        }
        else if (i == 1)
        {
            e.SetEnchantName("Dexterity");
            if (j == 1)
            {
                e.SetEnchantDesc("Enchanted with dexterity.");
            }
            else if (j == 2)
            {
                e.SetEnchantDesc("Your criticals will be more likely.");
            }
            else if (j == 3)
            {
                e.SetEnchantDesc("Your criticals will do more damage.");
            }
            e.dexterity = Random.Range(((int)qMod * ((int)(e.level / 4.5f + 1))), (3 * ((int)(e.level / 5f + 1))));
            e.SetBonusStatText(e.dexterity.ToString() + " Dexterity");
            e.power = e.dexterity;
            e.enchantValue = 1.75f;
            return Primary_Stats_Enchants.Dexterity;
        }
        else if (i == 2)
        {
            e.SetEnchantName("Intellect");
            if (j == 1)
            {
                e.SetEnchantDesc("Your magical attacks will do more damage.");
            }
            else if (j == 2)
            {
                e.SetEnchantDesc("You will resist magical damage more.");
            }
            else if (j == 3)
            {
                e.SetEnchantDesc("Enchanted with intellegence.");
            }
            e.intellect = Random.Range(((int)qMod * ((int)(e.level / 4.5f + 1))), (3 * ((int)(e.level / 5f + 1))));
            e.SetBonusStatText(e.intellect.ToString() + " Intellect");
            e.power = e.intellect;
            e.enchantValue = 1.75f;
            return Primary_Stats_Enchants.Intellect;
        }
        else if (i == 3)
        {
            e.SetEnchantName("Endurance");
            if (j == 1)
            {
                e.SetEnchantDesc("You will be able to do more things than usual.");
            }
            else if (j == 2)
            {
                e.SetEnchantDesc("You can handle physical attacks more.");
            }
            else if (j == 3)
            {
                e.SetEnchantDesc("Enchanted with endurance.");
            }
            e.endurance = Random.Range(((int)qMod * ((int)(e.level / 4.5f + 1))), (3 * ((int)(e.level / 5f + 1))));
            e.power = e.endurance;
            e.SetBonusStatText(e.endurance.ToString() + " Endurance");
            e.enchantValue = 1.75f;
            return Primary_Stats_Enchants.Endurance;
        }
        else if (i == 4)
        {
            e.SetEnchantName("Vitality");
            if (j == 1)
            {
                e.SetEnchantDesc("You will have more life force.");
            }
            else if (j == 2)
            {
                e.SetEnchantDesc("You will regenerate health faster.");
            }
            else if (j == 3)
            {
                e.SetEnchantDesc("Enchanted with vitality.");
            }
            e.vitality = Random.Range(((int)qMod * ((int)(e.level / 4.5f + 1))), (3 * ((int)(e.level / 5f + 1))));
            e.power = e.vitality;
            e.SetBonusStatText(e.vitality.ToString() + " Vitality");
            e.enchantValue = 1.75f;
            return Primary_Stats_Enchants.Vitality;
        }
        else if (i == 5)
        {
            e.SetEnchantName("Agility");
            if (j == 1)
            {
                e.SetEnchantDesc("You will move faster.");
            }
            else if (j == 2)
            {
                e.SetEnchantDesc("You will have the chance to evade attacks.");
            }
            else if (j == 3)
            {
                e.SetEnchantDesc("Enchanted with agility.");
            }
            e.agility = Random.Range(((int)qMod * ((int)(e.level / 4.5f + 1))), (3 * ((int)(e.level / 5f + 1))));
            e.power = e.agility;
            e.SetBonusStatText(e.agility.ToString() + " Agility");
            e.enchantValue = 1.75f;
            return Primary_Stats_Enchants.Agility;
        }
        else if (i == 6)
        {
            e.SetEnchantName("Luck");
            if (j == 1)
            {
                e.SetEnchantDesc("You will have more fortune.");
            }
            else if (j == 2)
            {
                e.SetEnchantDesc("You will have better chances at getting rare items.");
            }
            else if (j == 3)
            {
                e.SetEnchantDesc("Enchanted with Luck.");
            }
            e.luck = Random.Range(((int)qMod * ((int)(e.level / 4.5f + 1))), (3 * ((int)(e.level / 5f + 1))));
            e.power = e.luck;
            e.SetBonusStatText(e.luck.ToString() + " Luck");
            e.enchantValue = 1.75f;
            return Primary_Stats_Enchants.Luck;
        }
        else
        {
            e.SetEnchantName("Luck");
            if (j == 1)
            {
                e.SetEnchantDesc("You will have more fortune.");
            }
            else if (j == 2)
            {
                e.SetEnchantDesc("You will have better chances at getting rare items.");
            }
            else if (j == 3)
            {
                e.SetEnchantDesc("Enchanted with Luck.");
            }
            e.luck = Random.Range(((int)qMod * ((int)(e.level / 4.5f + 1))), (3 * ((int)(e.level / 5f + 1))));
            e.power = e.luck;
            e.SetBonusStatText(e.luck.ToString() + " Luck");
            e.enchantValue = 1.75f;
            return Primary_Stats_Enchants.Luck;
        }


    }
    // Returns A Secondary Enchant
    public static Secondary_Stats_Enchants GetSecondaryEnchant(Enchant e, int c = -1 )
    {
        
        int i = 0;
        if (c == -1)
        {
            i = Random.Range(0, 12);
        }
        else
        {
            i = c;
        }
        if (i == 0)
        {
            e.SetEnchantName("Armor Piercing");
            e.armor_Pen = Random.Range((1 * ((int)(e.level / 4.5f + 1))), (3 * ((int)(e.level / 5f + 1))));
            e.power = e.armor_Pen;
            e.SetBonusStatText(e.armor_Pen.ToString() + " Armor Piercing");
            e.enchantValue = 0.85f;
            return Secondary_Stats_Enchants.Armor_Penetration;
        }
        else if (i == 1)
        {
            e.SetEnchantName("Energy");
            e.energyPoints = Random.Range((1 * ((int)(e.level / 4.5f + 1))), (3 * ((int)(e.level / 5f + 1))));
            e.power = e.energyPoints;
            e.SetBonusStatText(e.energyPoints.ToString() + " Energy");
            e.enchantValue = 0.85f;
            return Secondary_Stats_Enchants.Energy_Points;
        }
        else if (i == 2)
        {
            e.SetEnchantName("Evasion");
            e.evasion = Random.Range((1 * ((int)(e.level / 4.5f + 1))), (3 * ((int)(e.level / 5f + 1))));
            e.power = e.evasion;
            e.SetBonusStatText(e.evasion.ToString() + " Evasion");
            e.enchantValue = 0.85f;
            return Secondary_Stats_Enchants.Evasion;
        }
        else if (i == 3)
        {
            e.SetEnchantName("Ferocity");
            e.ferocity = Random.Range((1 * ((int)(e.level / 4.5f + 1))), (3 * ((int)(e.level / 5f + 1))));
            e.power = e.ferocity;
            e.SetBonusStatText(e.ferocity.ToString() + " Ferocity");
            e.enchantValue = 0.85f;
            return Secondary_Stats_Enchants.Ferocity;
        }
        else if (i == 4)
        {
            e.SetEnchantName("Health");
            e.healthPoints = Random.Range((1 * ((int)(e.level / 4.5f + 1))), (3 * ((int)(e.level / 5f + 1))));
            e.power = e.healthPoints;
            e.SetBonusStatText(e.healthPoints.ToString() + " Health");
            e.enchantValue = 0.85f;
            return Secondary_Stats_Enchants.Health_Points;
        }
        else if (i == 5)
        {
            e.SetEnchantName("Perception");
            e.perception = Random.Range((1 * ((int)(e.level / 4.5f + 1))), (3 * ((int)(e.level / 5f + 1))));
            e.power = e.perception;
            e.SetBonusStatText(e.perception.ToString() + " Perception");
            e.enchantValue = 0.85f;
            return Secondary_Stats_Enchants.Perception;
        }
        else if (i == 6)
        {
            e.SetEnchantName("Armor");
            e.p_Resist = Random.Range((1 * ((int)(e.level / 4.5f + 1))), (3 * ((int)(e.level / 5f + 1))));
            e.power = e.p_Resist;
            e.SetBonusStatText(e.p_Resist.ToString() + " Armor");
            e.enchantValue = 0.85f;
            return Secondary_Stats_Enchants.Physical_resistance;
        }
        else if (i == 7)
        {
            e.SetEnchantName("Speed");
            e.speed = Random.Range((1 * ((int)(e.level / 4.5f + 1))), (3 * ((int)(e.level / 5f + 1))));
            e.power = e.speed;
            e.SetBonusStatText(e.speed.ToString() + " Speed");
            e.enchantValue = 0.85f;
            return Secondary_Stats_Enchants.Speed;
        }
        else if (i == 8)
        {
            e.SetEnchantName("Spell Piercing");
            e.spell_Pen = Random.Range((1 * ((int)(e.level / 4.5f + 1))), (3 * ((int)(e.level / 5f + 1))));
            e.power = e.spell_Pen;
            e.SetBonusStatText(e.spell_Pen.ToString() + " Spell Piercing");
            e.enchantValue = 0.85f;
            return Secondary_Stats_Enchants.Spell_Penetration;
        }
        else if (i == 9)
        {
            e.SetEnchantName("Mana");
            e.spellPoints = Random.Range((1 * ((int)(e.level / 4.5f + 1))), (3 * ((int)(e.level / 5f + 1))));
            e.power = e.spellPoints;
            e.SetBonusStatText(e.spellPoints.ToString() + " Mana");
            e.enchantValue = 0.85f;
            return Secondary_Stats_Enchants.Spell_Points;
        }
        else if (i == 10)
        {
            e.SetEnchantName("Spirit");
            e.spirit = Random.Range((1 * ((int)(e.level / 4.5f + 1))), (3 * ((int)(e.level / 5f + 1))));
            e.power = e.spirit;
            e.SetBonusStatText(e.spirit.ToString() + " Spirit");
            e.enchantValue = 0.85f;
            return Secondary_Stats_Enchants.Spirit;
        }
        else if (i == 11)
        {
            e.SetEnchantName("Wisdom");
            e.wisdom = Random.Range((1 * ((int)(e.level / 4.5f + 1))), (3 * ((int)(e.level / 5f + 1))));
            e.power = e.wisdom;
            e.SetBonusStatText(e.wisdom.ToString() + " Wisdom");
            e.enchantValue = 0.85f;
            return Secondary_Stats_Enchants.Wisdom;
        }
        else
        {
            e.SetEnchantName("Health");
            e.healthPoints = Random.Range((1 * ((int)(e.level / 4.5f + 1))), (3 * ((int)(e.level / 5f + 1))));
            e.power = e.healthPoints;
            e.SetBonusStatText(e.healthPoints.ToString() + " Health");
            e.enchantValue = 0.85f;
            return Secondary_Stats_Enchants.Health_Points;
        }
    }
    // Returns A Tertiary Enchant
    public static Tertiary_Stats_Enchants GetTertiaryEnchant(Enchant e, int c = -1)
    {
        int i = 0;
        if (c == -1)
        {
            i = Random.Range(0, 7);
        }
        else
        {
            i = c;
        }
        if (i == 0)
        {
            e.SetEnchantName("Greed");
            e.currency_percent = Random.Range((1 * ((int)(e.level / 4.5f + 1))), (3 * ((int)(e.level / 5f + 1))));
            e.power = e.currency_percent;
            e.SetBonusStatText(e.currency_percent.ToString() + " Bonus Credits %");
            e.enchantValue = 1.75f;
            return Tertiary_Stats_Enchants.Currency_Increase_Percent;
        }
        else if (i == 1)
        {
            e.SetEnchantName("Overpowering");
            e.damage_percent = Random.Range(1,11);
            e.power = e.damage_percent;
            e.SetBonusStatText(e.damage_percent.ToString() + " DMG %");
            e.enchantValue = 1.75f;
            return Tertiary_Stats_Enchants.Damage_Percent;
        }
        else if (i == 2)
        {
            e.SetEnchantName("Tenacity");
            e.energy_percent = Random.Range(1,11);
            e.power = e.energy_percent;
            e.SetBonusStatText(e.energy_percent.ToString() + " Energy %");
            e.enchantValue = 1.75f;
            return Tertiary_Stats_Enchants.Energy_Points_Percent;
        }
        else if (i == 3)
        {
            e.SetEnchantName("Vampirism");
            e.lifesteal_percent = Random.Range(1,11);
            e.power = e.lifesteal_percent;
            e.SetBonusStatText(e.lifesteal_percent.ToString() + " Lifesteal %");
            e.enchantValue = 1.75f;
            return Tertiary_Stats_Enchants.Lifesteal_Percent;
        }
        else if (i == 4)
        {
            e.SetEnchantName("Life");
            e.life_percent = Random.Range(1,11);
            e.power = e.life_percent;
            e.SetBonusStatText(e.life_percent.ToString() + " Life %");
            e.enchantValue = 1.75f;
            return Tertiary_Stats_Enchants.Life_Points_Percent;
        }
        else if (i == 5)
        {
            e.SetEnchantName("Chance");
            e.magic_chance = Random.Range(1 * (int)(e.level/5f) , 10 * (int)(e.level/5f));
            e.power = e.magic_chance;
            e.SetBonusStatText(e.magic_chance.ToString() + " Lucky Find %");
            e.enchantValue = 1.75f;
            return Tertiary_Stats_Enchants.Magic_Drop_Chance;
        }
        else if (i == 6)
        {
            e.SetEnchantName("Magic");
            e.spell_percent = Random.Range(1 , 11);
            e.power = e.spell_percent;
            e.SetBonusStatText(e.spell_percent.ToString() + " Spell Points %");
            e.enchantValue = 1.75f;
            return Tertiary_Stats_Enchants.Spell_Points_Percent;
        }
        else
        {
            e.SetEnchantName("Greed");
            e.currency_percent = Random.Range(1 * (int)(e.level / 25f), 10 * (int)(e.level / 25f));
            e.power = e.currency_percent;
            e.SetBonusStatText(e.currency_percent.ToString() + " Bonus Credits %");
            e.enchantValue = 1.75f;
            return Tertiary_Stats_Enchants.Currency_Increase_Percent;
        }
    }
    // Returns A Resistance Enchant
    public static Resistance_Enchants GetResistanceEnchant(Enchant e ,int c = -1)
    {
        int i = 0;
        if (c == -1)
        {
            i = Random.Range(0, 12);
        }
        else
        {
            i = c;
        }
        if (i == 0)
        {
            e.SetEnchantName("Aether Resistance");
            e.aether_Resist = 1 * (e.level / 2);
            e.power = e.aether_Resist;
            e.SetBonusStatText(e.aether_Resist.ToString() + " Aether Resistance");
            e.enchantValue = 0.75f;
            return Resistance_Enchants.Aether_Resistance;
        }
        else if (i == 1)
        {
            e.SetEnchantName("Bleeding Resistance");
            e.bleeding_Resist = 1 * (e.level / 2);
            e.power = e.bleeding_Resist;
            e.SetBonusStatText(e.bleeding_Resist.ToString() + " Bleeding Resistance");
            e.enchantValue = 0.75f;
            return Resistance_Enchants.Bleeding_Resistance;
        }
        else if (i == 2)
        {
            e.SetEnchantName("Dark Resistance");
            e.dark_Resist = 1 * (e.level / 5);
            e.power = e.dark_Resist;
            e.SetBonusStatText(e.dark_Resist.ToString() + " Dark Resistance");
            e.enchantValue = 0.75f;
            return Resistance_Enchants.Dark_Resistance;
        }
        else if (i == 3)
        {
            e.SetEnchantName("Earth Resistance");
            e.earth_Resist = 1 * (e.level / 2);
            e.power = e.earth_Resist;
            e.SetBonusStatText(e.earth_Resist.ToString() + " Earth Resistance");
            e.enchantValue = 0.75f;
            return Resistance_Enchants.Earth_Resistance;
        }
        else if (i == 4)
        {
            e.SetEnchantName("Fire Resistance");
            e.fire_Resist = 1 * (e.level / 2);
            e.power = e.fire_Resist;
            e.SetBonusStatText(e.fire_Resist.ToString() + " Fire Resistance");
            e.enchantValue = 0.75f;
            return Resistance_Enchants.Fire_Resistance;
        }
        else if (i == 5)
        {
            e.SetEnchantName("Ice Resistance");
            e.ice_Resist = 1 * (e.level / 2);
            e.power = e.ice_Resist;
            e.SetBonusStatText(e.ice_Resist.ToString() + " Ice Resistance");
            e.enchantValue = 0.75f;
            return Resistance_Enchants.Ice_Resistance;
        }
        else if (i == 6)
        {
            e.SetEnchantName("Light Resistance");
            e.light_Resist = 1 * (e.level / 5);
            e.power = e.light_Resist;
            e.SetBonusStatText(e.light_Resist.ToString() + " Light Resistance");
            e.enchantValue = 0.75f;
            return Resistance_Enchants.Light_Resistance;
        }
        else if (i == 7)
        {
            e.SetEnchantName("Poison Resistance");
            e.poison_Resist = 1 * (e.level / 2);
            e.power = e.poison_Resist;
            e.SetBonusStatText(e.poison_Resist.ToString() + " Poison Resistance");
            e.enchantValue = 0.75f;
            return Resistance_Enchants.Poison_Resistance;
        }
        else if (i == 8)
        {
            e.SetEnchantName("Soul Resistance");
            e.soul_Resist = 1 * (e.level / 10);
            e.power = e.soul_Resist;
            e.SetBonusStatText(e.soul_Resist.ToString() + " Soul Resistance");
            e.enchantValue = 0.75f;
            return Resistance_Enchants.Soul_Resistance;
        }
        else if (i == 9)
        {
            e.SetEnchantName("Thunder Resistance");
            e.thunder_Resist = 1 * (e.level / 2);
            e.power = e.thunder_Resist;
            e.SetBonusStatText(e.thunder_Resist.ToString() + " Thunder Resistance");
            e.enchantValue = 0.75f;
            return Resistance_Enchants.Thunder_Resistance;
        }
        else if (i == 10)
        {
            e.SetEnchantName("Water Resistance");
            e.water_Resist = 1 * (e.level / 2);
            e.power = e.water_Resist;
            e.SetBonusStatText(e.water_Resist.ToString() + " Water Resistance");
            e.enchantValue = 0.75f;
            return Resistance_Enchants.Water_Resistance;
        }
        else if (i == 11)
        {
            e.SetEnchantName("Wind Resistance");
            e.wind_Resist = 1 * (e.level / 2);
            e.power = e.wind_Resist;
            e.SetBonusStatText(e.wind_Resist.ToString() + " Wind Resistance");
            e.enchantValue = 0.75f;
            return Resistance_Enchants.Wind_Resistance;
        }
        else
        {
            e.SetEnchantName("Fire Resistance");
            e.fire_Resist = Random.Range((1 * ((int)(e.level / 4.5f + 1))), (3 * ((int)(e.level / 5f + 1))));
            e.power = e.fire_Resist;
            e.SetBonusStatText(e.fire_Resist.ToString() + " Fire Resistance");
            e.enchantValue = 0.75f;
            return Resistance_Enchants.Fire_Resistance;
        }
    }
   
    // Returns A Teir 1 Damage Enchant
    public static Tier1_Damage_Enchants GetTierOneDamageEnchant(Enchant e, int c = -1)
    {
        int i = 0;
        if (c == -1)
        {
            i = Random.Range(0, 13);
        }
        else
        {
            i = c;
        }
        if (i == 0)
        {
            
            e.SetEnchantName("Nethers");
            e.SetEnchantName("Twisted",true);
            e.aether_damage = Random.Range((1 * (int)(e.w_damage / lMod + 1)) , (int)((e.w_damage / lMod) + (e.level / lMod)) + 1);
            e.power = e.aether_damage;
            e.SetBonusStatText(e.aether_damage.ToString() + " (T1)Aether Damage");
            e.enchantValue = 2.15f;
            e.e_dType = Damage.DamageType.Aether;
            e.e_doType = Damage_OT.Damage_OTType.Normal;
            return Tier1_Damage_Enchants.Aether1;
        }
        else if (i == 1)
        {
            e.SetEnchantName("Trickles");
            e.SetEnchantName("Trickling", true);
            e.bleeding_damage = Random.Range((1 * (int)(e.w_damage / lMod + 1)), (int)((e.w_damage / lMod) + (e.level / lMod)) + 1);
            e.power = e.bleeding_damage;
            e.SetBonusStatText(e.bleeding_damage.ToString() + " (T1)Bleeding Damage");
            e.enchantValue = 2.15f;
            e.e_dType = Damage.DamageType.Normal;
            e.e_doType = Damage_OT.Damage_OTType.Bleeding;
            return Tier1_Damage_Enchants.Blood1;
        }
        else if (i == 2)
        {
            e.SetEnchantName("Nights");
            e.SetEnchantName("Dark", true);
            e.dark_damage = Random.Range((1 * (int)(e.w_damage / lMod + 1)), (int)((e.w_damage / lMod) + (e.level / lMod)) + 1);
            e.power = e.dark_damage;
            e.SetBonusStatText(e.dark_damage.ToString() + " (T1)Dark Damage");
            e.enchantValue = 2.15f;
            e.e_dType = Damage.DamageType.Dark;
            e.e_doType = Damage_OT.Damage_OTType.Normal;
            return Tier1_Damage_Enchants.Dark1;
        }
        else if (i == 3)
        {
            e.SetEnchantName("Pebbles");
            e.SetEnchantName("Heavy", true);
            e.earth_damage = Random.Range((1 * (int)(e.w_damage / lMod + 1)), (int)((e.w_damage / lMod) + (e.level / lMod)) + 1);
            e.power = e.earth_damage;
            e.SetBonusStatText(e.earth_damage.ToString() + " (T1)Earth Damage");
            e.enchantValue = 2.15f;
            e.e_dType = Damage.DamageType.Earth;
            e.e_doType = Damage_OT.Damage_OTType.Normal;
            return Tier1_Damage_Enchants.Earth1;
        }
        else if (i == 4)
        {
            e.SetEnchantName("Flames");
            e.SetEnchantName("Flaming", true);
            e.fire_damage = Random.Range((1 * (int)(e.w_damage / lMod + 1)), (int)((e.w_damage / lMod) + (e.level / lMod)) + 1);
            e.power = e.fire_damage;
            e.SetBonusStatText(e.fire_damage.ToString() + " (T1)Fire Damage");
            e.enchantValue = 2.15f;
            e.e_dType = Damage.DamageType.Fire;
            e.e_doType = Damage_OT.Damage_OTType.Fire;
            return Tier1_Damage_Enchants.Fire1;
        }
        else if (i == 5)
        {
            e.SetEnchantName("Ice");
            e.SetEnchantName("Icey", true);
            e.ice_damage = Random.Range((1 * (int)(e.w_damage / lMod + 1)), (int)((e.w_damage / lMod) + (e.level / lMod)) + 1);
            e.power = e.ice_damage;
            e.SetBonusStatText(e.ice_damage.ToString() + " (T1)Ice Damage");
            e.enchantValue = 2.15f;
            e.e_dType = Damage.DamageType.Ice;
            e.e_doType = Damage_OT.Damage_OTType.Normal;
            return Tier1_Damage_Enchants.Ice1;
        }
        else if (i == 6)
        {
            e.SetEnchantName("Prayers");
            e.SetEnchantName("Praying", true);
            e.light_damage = Random.Range((1 * (int)(e.w_damage / lMod + 1)), (int)((e.w_damage / lMod) + (e.level / lMod)) + 1);
            e.power = e.light_damage;
            e.SetBonusStatText(e.light_damage.ToString() + " (T1)Light Damage");
            e.enchantValue = 2.15f;
            e.e_dType = Damage.DamageType.Light;
            e.e_doType = Damage_OT.Damage_OTType.Normal;
            return Tier1_Damage_Enchants.Light1;
        }
        else if (i == 7)
        {
            e.SetEnchantName("Shocks");
            e.SetEnchantName("Shocking", true);
            e.thunder_damage = Random.Range((1 * (int)(e.w_damage / lMod + 1)), (int)((e.w_damage / lMod) + (e.level / lMod)) + 1);
            e.power = e.thunder_damage;
            e.SetBonusStatText(e.thunder_damage.ToString() + " (T1)Thunder Damage");
            e.enchantValue = 2.15f;
            e.e_dType = Damage.DamageType.Thunder;
            e.e_doType = Damage_OT.Damage_OTType.Normal;
            return Tier1_Damage_Enchants.Lightning1;
        }
        else if (i == 8)
        {
            e.SetEnchantName("Harm");
            e.SetEnchantName("Harming", true);
            e.p_damage = Random.Range((1 * (int)(e.w_damage / lMod + 1)), (int)((e.w_damage / lMod) + (e.level / lMod)) + 1);
            e.power = e.p_damage;
            e.SetBonusStatText(e.p_damage.ToString() + " (T1)Physical Damage");
            e.enchantValue = 2.15f;
            e.e_dType = Damage.DamageType.Normal;
            e.e_doType = Damage_OT.Damage_OTType.Normal;
            return Tier1_Damage_Enchants.Physical1;
        }
        else if (i == 9)
        {
            e.SetEnchantName("Poison");
            e.SetEnchantName("Poisoning", true);
            e.poison_damage = Random.Range((1 * (int)(e.w_damage / lMod + 1)), (int)((e.w_damage / lMod) + (e.level / lMod)) + 1);
            e.power = e.poison_damage;
            e.SetBonusStatText(e.poison_damage.ToString() + " (T1)Poison Damage");
            e.enchantValue = 2.15f;
            e.e_dType = Damage.DamageType.Normal;
            e.e_doType = Damage_OT.Damage_OTType.Poison;
            return Tier1_Damage_Enchants.Poison1;
        }
        else if (i == 10)
        {
            e.SetEnchantName("Faries");
            e.SetEnchantName("Pixie", true);
            e.soul_damage = Random.Range((1 * (int)(e.w_damage / lMod + 1)), (int)((e.w_damage / lMod) + (e.level / lMod)) + 1);
            e.power = e.soul_damage;
            e.SetBonusStatText(e.soul_damage.ToString() + " (T1)Soul Damage");
            e.enchantValue = 2.15f;
            e.e_dType = Damage.DamageType.Soul;
            e.e_doType = Damage_OT.Damage_OTType.Normal;
            return Tier1_Damage_Enchants.Soul1;
        }
        else if (i == 11)
        {
            e.SetEnchantName("Water");
            e.SetEnchantName("Watered", true);
            e.water_damage = Random.Range((1 * (int)(e.w_damage / lMod + 1)), (int)((e.w_damage / lMod) + (e.level / lMod)) + 1);
            e.power = e.water_damage;
            e.SetBonusStatText(e.water_damage.ToString() + " (T1)Water Damage");
            e.enchantValue = 2.15f;
            e.e_dType = Damage.DamageType.Water;
            e.e_doType = Damage_OT.Damage_OTType.Normal;
            return Tier1_Damage_Enchants.Water1;
        }
        else if (i == 12)
        {
            e.SetEnchantName("Water");
            e.SetEnchantName("Watered", true);
            e.water_damage = Random.Range((1 * (int)(e.w_damage / lMod + 1)), (int)((e.w_damage / lMod) + (e.level / lMod)) + 1);
            e.power = e.water_damage;
            e.SetBonusStatText(e.water_damage.ToString() + " (T1)Water Damage");
            e.enchantValue = 2.15f;
            e.e_dType = Damage.DamageType.Wind;
            e.e_doType = Damage_OT.Damage_OTType.Normal;
            return Tier1_Damage_Enchants.Wind1;
        }
        else
        {
            e.SetEnchantName("Flames");
            e.SetEnchantName("Flaming", true);
            e.fire_damage = Random.Range((1 * (int)(e.w_damage / lMod + 1)), (int)((e.w_damage / lMod) + (e.level / lMod)) + 1);
            e.power = e.fire_damage;
            e.SetBonusStatText(e.fire_damage.ToString() + " (T1)Fire Damage");
            e.enchantValue = 2.15f;
            e.e_dType = Damage.DamageType.Fire;
            e.e_doType = Damage_OT.Damage_OTType.Fire;
            return Tier1_Damage_Enchants.Fire1;
        }
    }
    // Returns A Teir 2 Damage Enchant
    public static Tier2_Damage_Enchants GetTierTwoDamageEnchant(Enchant e, int c  = -1)
    {
        int i = 0;
        if (c == -1)
        {
            i = Random.Range(0, 13);
        }
        else
        {
            i = c;
        }
        if (i == 0)
        {
            e.SetEnchantName("Void");
            e.SetEnchantName("Empty", true);
            e.aether_damage = Random.Range((1 * (int)(e.w_damage / mMod + 1)), (int)((e.w_damage / mMod) + (e.level / mMod)) + 1);
            e.power = e.aether_damage;
            e.SetBonusStatText(e.aether_damage.ToString() + " (T2)Aether Damage");
            e.enchantValue = 3.25f;
            e.e_dType = Damage.DamageType.Aether;
            e.e_doType = Damage_OT.Damage_OTType.Normal;
            return Tier2_Damage_Enchants.Aether2;
        }
        else if (i == 1)
        {
            e.SetEnchantName("Bloods");
            e.SetEnchantName("Bleeding", true);
            e.bleeding_damage = Random.Range((1 * (int)(e.w_damage / mMod + 1)), (int)((e.w_damage / mMod) + (e.level / mMod)) + 1);
            e.power = e.bleeding_damage;
            e.SetBonusStatText(e.bleeding_damage.ToString() + " (T2)Bleeding Damage");
            e.enchantValue = 3.25f;
            e.e_dType = Damage.DamageType.Normal;
            e.e_doType = Damage_OT.Damage_OTType.Bleeding;
            return Tier2_Damage_Enchants.Blood2;
        }
        else if (i == 2)
        {
            e.SetEnchantName("Evil");
            e.SetEnchantName("Corrupted", true);
            e.dark_damage = Random.Range((1 * (int)(e.w_damage / mMod + 1)), (int)((e.w_damage / mMod) + (e.level / mMod)) + 1);
            e.power = e.dark_damage;
            e.SetBonusStatText(e.dark_damage.ToString() + " (T2)Dark Damage");
            e.enchantValue = 3.25f;
            e.e_dType = Damage.DamageType.Dark;
            e.e_doType = Damage_OT.Damage_OTType.Normal;
            return Tier2_Damage_Enchants.Dark2;
        }
        else if (i == 3)
        {
            e.SetEnchantName("Stones");
            e.SetEnchantName("Stoning", true);
            e.earth_damage = Random.Range((1 * (int)(e.w_damage / mMod + 1)), (int)((e.w_damage / mMod) + (e.level / mMod)) + 1);
            e.power = e.earth_damage;
            e.SetBonusStatText(e.earth_damage.ToString() + " (T2)Earth Damage");
            e.enchantValue = 3.25f;
            e.e_dType = Damage.DamageType.Earth;
            e.e_doType = Damage_OT.Damage_OTType.Normal;
            return Tier2_Damage_Enchants.Earth2;
        }
        else if (i == 4)
        {
            e.SetEnchantName("Infernos");
            e.SetEnchantName("Blazing", true);
            e.fire_damage = Random.Range((1 * (int)(e.w_damage / mMod + 1)), (int)((e.w_damage / mMod) + (e.level / mMod)) + 1);
            e.power = e.fire_damage;
            e.SetBonusStatText(e.fire_damage.ToString() + " (T2)Fire Damage");
            e.enchantValue = 3.25f;
            e.e_dType = Damage.DamageType.Fire;
            e.e_doType = Damage_OT.Damage_OTType.Fire;
            return Tier2_Damage_Enchants.Fire2;
        }
        else if (i == 5)
        {
            e.SetEnchantName("Glaciers");
            e.SetEnchantName("Frozen", true);
            e.ice_damage = Random.Range((1 * (int)(e.w_damage / mMod + 1)), (int)((e.w_damage / mMod) + (e.level / mMod)) + 1);
            e.power = e.ice_damage;
            e.SetBonusStatText(e.ice_damage.ToString() + " (T2)Ice Damage");
            e.enchantValue = 3.25f;
            e.e_dType = Damage.DamageType.Ice;
            e.e_doType = Damage_OT.Damage_OTType.Normal;
            return Tier2_Damage_Enchants.Ice2;
        }
        else if (i == 6)
        {
            e.SetEnchantName("Holyness");
            e.SetEnchantName("Holy", true);
            e.light_damage = Random.Range((1 * (int)(e.w_damage / mMod + 1)), (int)((e.w_damage / mMod) + (e.level / mMod)) + 1);
            e.power = e.light_damage;
            e.SetBonusStatText(e.light_damage.ToString() + " (T2)Light Damage");
            e.enchantValue = 3.25f;
            e.e_dType = Damage.DamageType.Light;
            e.e_doType = Damage_OT.Damage_OTType.Normal;
            return Tier2_Damage_Enchants.Light2;
        }
        else if (i == 7)
        {
            e.SetEnchantName("Thunder");
            e.SetEnchantName("Lightning", true);
            e.thunder_damage = Random.Range((1 * (int)(e.w_damage / mMod + 1)), (int)((e.w_damage / mMod) + (e.level / mMod)) + 1);
            e.power = e.thunder_damage;
            e.SetBonusStatText(e.thunder_damage.ToString() + " (T2)Lightning Damage");
            e.enchantValue = 3.25f;
            e.e_dType = Damage.DamageType.Thunder;
            e.e_doType = Damage_OT.Damage_OTType.Normal;
            return Tier2_Damage_Enchants.Lightning2;
        }
        else if (i == 8)
        {
            e.SetEnchantName("Strikes");
            e.SetEnchantName("Striking", true);
            e.p_damage = Random.Range((1 * (int)(e.w_damage / mMod + 1)), (int)((e.w_damage / mMod) + (e.level / mMod)) + 1);
            e.power = e.p_damage;
            e.SetBonusStatText(e.p_damage.ToString() + " (T2)Physical Damage");
            e.enchantValue = 3.25f;
            e.e_dType = Damage.DamageType.Normal;
            e.e_doType = Damage_OT.Damage_OTType.Normal;
            return Tier2_Damage_Enchants.Physical2;
        }
        else if (i == 9)
        {
            e.SetEnchantName("Disease");
            e.SetEnchantName("Diseased", true);
            e.poison_damage = Random.Range((1 * (int)(e.w_damage / mMod + 1)), (int)((e.w_damage / mMod) + (e.level / mMod)) + 1);
            e.power = e.poison_damage;
            e.SetBonusStatText(e.poison_damage.ToString() + " (T2)Poison Damage");
            e.enchantValue = 3.25f;
            e.e_dType = Damage.DamageType.Normal;
            e.e_doType = Damage_OT.Damage_OTType.Poison;
            return Tier2_Damage_Enchants.Poison2;
        }
        else if (i == 10)
        {
            e.SetEnchantName("Spirits");
            e.SetEnchantName("Spiriting", true);
            e.soul_damage = Random.Range((1 * (int)(e.w_damage / mMod + 1)), (int)((e.w_damage / mMod) + (e.level / mMod)) + 1);
            e.power = e.soul_damage;
            e.SetBonusStatText(e.soul_damage.ToString() + " (T2)Soul Damage");
            e.enchantValue = 3.25f;
            e.e_dType = Damage.DamageType.Soul;
            e.e_doType = Damage_OT.Damage_OTType.Normal;
            return Tier2_Damage_Enchants.Soul2;
        }
        else if (i == 11)
        {
            e.SetEnchantName("Currents");
            e.SetEnchantName("Flowing", true);
            e.water_damage = Random.Range((1 * (int)(e.w_damage / mMod + 1)), (int)((e.w_damage / mMod) + (e.level / mMod)) + 1);
            e.power = e.water_damage;
            e.SetBonusStatText(e.water_damage.ToString() + " (T2)Water Damage");
            e.enchantValue = 3.25f;
            e.e_dType = Damage.DamageType.Water;
            e.e_doType = Damage_OT.Damage_OTType.Normal;
            return Tier2_Damage_Enchants.Water2;
        }
        else if (i == 12)
        {
            e.SetEnchantName("Currents");
            e.SetEnchantName("Flowing", true);
            e.water_damage = Random.Range((1 * (int)(e.w_damage / mMod + 1)), (int)((e.w_damage / mMod) + (e.level / mMod)) + 1);
            e.power = e.water_damage;
            e.SetBonusStatText(e.water_damage.ToString() + " (T2)Water Damage");
            e.enchantValue = 3.25f;
            e.e_dType = Damage.DamageType.Wind;
            e.e_doType = Damage_OT.Damage_OTType.Normal;
            return Tier2_Damage_Enchants.Wind2;
        }
        else
        {
            e.SetEnchantName("Infernos");
            e.SetEnchantName("Blazing", true);
            e.fire_damage = Random.Range((1 * (int)(e.w_damage / mMod + 1)), (int)((e.w_damage / mMod) + (e.level / mMod)) + 1);
            e.power = e.fire_damage;
            e.SetBonusStatText(e.fire_damage.ToString() + " (T2)Fire Damage");
            e.enchantValue = 3.25f;
            e.e_dType = Damage.DamageType.Fire;
            e.e_doType = Damage_OT.Damage_OTType.Fire;
            return Tier2_Damage_Enchants.Fire2;
        }
    }
    // Returns A Tier 3 Damage Enchant
    public static Tier3_Damage_Enchants GetTierThreeDamageEnchant(Enchant e, int c = -1)
    {
        int i = 0;
        if (c == -1)
        {
            i = Random.Range(0, 13);
        }
        else
        {
            i = c;
        }
        if (i == 0)
        {
            e.SetEnchantName("Abyss");
            e.SetEnchantName("Abyssmal", true);
            e.aether_damage = Random.Range((1 * (int)(e.w_damage / hMod + 1)), (int)((e.w_damage / hMod) + (e.level / hMod)) + 1);
            e.power = e.aether_damage;
            e.SetBonusStatText(e.aether_damage.ToString() + " (T3)Aether Damage");
            e.enchantValue = 4.65f;
            e.e_dType = Damage.DamageType.Aether;
            e.e_doType = Damage_OT.Damage_OTType.Normal;
            return Tier3_Damage_Enchants.Aether3;
        }
        else if (i == 1)
        {
            e.SetEnchantName("Garrottes");
            e.SetEnchantName("Garrotting", true);
            e.bleeding_damage = Random.Range((1 * (int)(e.w_damage / hMod + 1)), (int)((e.w_damage / hMod) + (e.level / hMod)) + 1);
            e.power = e.bleeding_damage;
            e.SetBonusStatText(e.bleeding_damage.ToString() + " (T3)Blood Damage");
            e.enchantValue = 4.65f;
            e.e_dType = Damage.DamageType.Normal;
            e.e_doType = Damage_OT.Damage_OTType.Bleeding;
            return Tier3_Damage_Enchants.Blood3;
        }
        else if (i == 2)
        {
            e.SetEnchantName("Death");
            e.SetEnchantName("Deathly", true);
            e.dark_damage = Random.Range((1 * (int)(e.w_damage / hMod + 1)), (int)((e.w_damage / hMod) + (e.level / hMod)) + 1);
            e.power = e.dark_damage;
            e.SetBonusStatText(e.dark_damage.ToString() + " (T3)Dark Damage");
            e.enchantValue = 4.65f;
            e.e_dType = Damage.DamageType.Dark;
            e.e_doType = Damage_OT.Damage_OTType.Normal;
            return Tier3_Damage_Enchants.Dark3;
        }
        else if (i == 3)
        {
            e.SetEnchantName("Boulders");
            e.SetEnchantName("Caving", true);
            e.earth_damage = Random.Range((1 * (int)(e.w_damage / hMod + 1)), (int)((e.w_damage / hMod) + (e.level / hMod)) + 1);
            e.power = e.earth_damage;
            e.SetBonusStatText(e.earth_damage.ToString() + " (T3)Earth Damage");
            e.enchantValue = 4.65f;
            e.e_dType = Damage.DamageType.Earth;
            e.e_doType = Damage_OT.Damage_OTType.Normal;
            return Tier3_Damage_Enchants.Earth3;
        }
        else if (i == 4)
        {
            e.SetEnchantName("Hades");
            e.SetEnchantName("Hellish", true);
            e.fire_damage = Random.Range((1 * (int)(e.w_damage / hMod + 1)), (int)((e.w_damage / hMod) + (e.level / hMod)) + 1);
            e.power = e.fire_damage;
            e.SetBonusStatText(e.fire_damage.ToString() + " (T3)Fire Damage");
            e.enchantValue = 4.65f;
            e.e_dType = Damage.DamageType.Fire;
            e.e_doType = Damage_OT.Damage_OTType.Fire;
            return Tier3_Damage_Enchants.Fire3;
        }
        else if (i == 5)
        {
            e.SetEnchantName("Blizzards");
            e.SetEnchantName("Winters", true);
            e.ice_damage = Random.Range((1 * (int)(e.w_damage / hMod + 1)), (int)((e.w_damage / hMod) + (e.level / hMod)) + 1);
            e.power = e.ice_damage;
            e.SetBonusStatText(e.ice_damage.ToString() + " (T3)Ice Damage");
            e.enchantValue = 4.65f;
            e.e_dType = Damage.DamageType.Ice;
            e.e_doType = Damage_OT.Damage_OTType.Normal;
            return Tier3_Damage_Enchants.Ice3;
        }
        else if (i == 6)
        {
            e.SetEnchantName("Salvation");
            e.SetEnchantName("Divine", true);
            e.light_damage = Random.Range((1 * (int)(e.w_damage / hMod + 1)), (int)((e.w_damage / hMod) + (e.level / hMod)) + 1);
            e.power = e.light_damage;
            e.SetBonusStatText(e.light_damage.ToString() + " (T3)Light Damage");
            e.enchantValue = 4.65f;
            e.e_dType = Damage.DamageType.Light;
            e.e_doType = Damage_OT.Damage_OTType.Normal;
            return Tier3_Damage_Enchants.Light3;
        }
        else if (i == 7)
        {
            e.SetEnchantName("LIGHTNING HERE");
            e.SetEnchantName("Storming", true);
            e.thunder_damage = Random.Range((1 * (int)(e.w_damage / hMod + 1)), (int)((e.w_damage / hMod) + (e.level / hMod)) + 1);
            e.power = e.thunder_damage;
            e.SetBonusStatText(e.thunder_damage.ToString() + " (T3)Lightning Damage");
            e.enchantValue = 4.65f;
            e.e_dType = Damage.DamageType.Thunder;
            e.e_doType = Damage_OT.Damage_OTType.Normal;
            return Tier3_Damage_Enchants.Lightning3;
        }
        else if (i == 8)
        {
            e.SetEnchantName("Damage");
            e.SetEnchantName("Damaging", true);
            e.p_damage = Random.Range((1 * (int)(e.w_damage / hMod + 1)), (int)((e.w_damage / hMod) + (e.level / hMod)) + 1);
            e.power = e.p_damage;
            e.SetBonusStatText(e.p_damage.ToString() + " (T3)Physical Damage");
            e.enchantValue = 4.65f;
            e.e_dType = Damage.DamageType.Normal;
            e.e_doType = Damage_OT.Damage_OTType.Normal;
            return Tier3_Damage_Enchants.Physical3;
        }
        else if (i == 9)
        {
            e.SetEnchantName("Plagues");
            e.SetEnchantName("Plaging", true);
            e.poison_damage = Random.Range((1 * (int)(e.w_damage / hMod + 1)), (int)((e.w_damage / hMod) + (e.level / hMod)) + 1);
            e.power = e.poison_damage;
            e.SetBonusStatText(e.poison_damage.ToString() + " (T3)Poison Damage");
            e.enchantValue = 4.65f;
            e.e_dType = Damage.DamageType.Normal;
            e.e_doType = Damage_OT.Damage_OTType.Poison;
            return Tier3_Damage_Enchants.Poison3;
        }
        else if (i == 10)
        {
            e.SetEnchantName("Souls");
            e.SetEnchantName("Soulful", true);
            e.soul_damage = Random.Range((1 * (int)(e.w_damage / hMod + 1)), (int)((e.w_damage / hMod) + (e.level / hMod)) + 1);
            e.power = e.soul_damage;
            e.SetBonusStatText(e.soul_damage.ToString() + " (T3)Soul Damage");
            e.enchantValue = 4.65f;
            e.e_dType = Damage.DamageType.Soul;
            e.e_doType = Damage_OT.Damage_OTType.Normal;
            return Tier3_Damage_Enchants.Soul3;
        }
        else if (i == 11)
        {
            e.SetEnchantName("Floods");
            e.SetEnchantName("Drowning", true);
            e.water_damage = Random.Range((1 * (int)(e.w_damage / hMod + 1)), (int)((e.w_damage / hMod) + (e.level / hMod)) + 1);
            e.power = e.water_damage;
            e.SetBonusStatText(e.water_damage.ToString() + " (T3)Water Damage");
            e.enchantValue = 4.65f;
            e.e_dType = Damage.DamageType.Water;
            e.e_doType = Damage_OT.Damage_OTType.Normal;
            return Tier3_Damage_Enchants.Water3;
        }
        else if (i == 12)
        {
            e.SetEnchantName("WIND HERE");
            e.SetEnchantName("PLUREL WIND HERE", true);
            e.water_damage = Random.Range((1 * (int)(e.w_damage / hMod + 1)), (int)((e.w_damage / hMod) + (e.level / hMod)) + 1);
            e.power = e.water_damage;
            e.SetBonusStatText(e.water_damage.ToString() + " (T3)Wind Damage");
            e.enchantValue = 4.65f;
            e.e_dType = Damage.DamageType.Wind;
            e.e_doType = Damage_OT.Damage_OTType.Normal;
            return Tier3_Damage_Enchants.Wind3;
        }
        else
        {
            e.SetEnchantName("Hades");
            e.SetEnchantName("Hellish", true);
            e.fire_damage = Random.Range((1 * (int)(e.w_damage / hMod + 1)), (int)((e.w_damage / hMod) + (e.level / hMod)) + 1);
            e.power = e.fire_damage;
            e.SetBonusStatText(e.fire_damage.ToString() + " (T3)Fire Damage");
            e.enchantValue = 4.65f;
            e.e_dType = Damage.DamageType.Fire;
            e.e_doType = Damage_OT.Damage_OTType.Fire;
            return Tier3_Damage_Enchants.Fire3;
        }
    }

}
