using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stats : MonoBehaviour {


    public Player_Stats_UI pstats;
    public Player_Vitals_UI pvitals;

    [Header("Player Info")]
    public static int Lucky = 0;
    public string playerName = "Xaletor";
    public Classes playerClass = Classes.Warrior;
    string className;
    public int playerLevel = 5;
    public int experience = 0;
    public int requiredExp = 100000;

    [Header("ComboStats")]
    // Combo Stats
    public int baseStat = 5;
    public int strength = 0;               // +(P)Damage,      +ArmorPen
    public int dexterity = 0;              // +Perception,		+Ferocity
    public int intellect = 0;              // +(M)Damage,      +Wisdom,     +Spellpoints
    public int endurance = 0;              // +Energy,         +Armor 
    public int vitality = 0;               // +Health,         +Spirit
    public int agility = 0;                // +Speed,          +Evasion
    public int luck = 0;                   // +(%)ItemChance,  +(%)CurrencyDrop

    int mstrength = 0;              
    int mdexterity = 0;              
    int mintellect = 0;              
    int mendurance = 0;              
    int mvitality = 0;             
    int magility = 0;               
    int mluck = 0;

    [Header("Secondaries")]
    // Second Stats
    public int bonusDamage = 0;
    public int armor = 0;              // damage reduction
    public float healthPoints = 0;       // resource to live
    public float currentHP = 0;
    public float spellPoints = 0;        // resource to cast spells
    public float currentSP = 0;
    public float energyPoints = 100;       // What you can do before you are tired
    public float currentEP = 0;
    public float currentShield = 0;
    public float shieldPoints = 0;
    public int perception = 0;         // crit chance
    public int ferocity = 0;           // crit damage
    public int speed = 0;              // movement speed
    public int evasion = 0;            // chance to take 0 Damage
    public int spirit = 0;             // Health Regen
    public int wisdom = 0;             // Spell Regen
    public int armorPen = 0;           // Bypass Armor
    public int magicPen = 0;           // Bypass Resistance

    [Header("Tertiaries")]
    // % stats
    public int magicFindP = 0;          // Increases chances to find better loot
    public int moneyFindP = 0;          // Increases amount of money dropped
    public int damageP = 0;            // Increases overall Damage
    public int healthPointsP = 0;      // Increases overall Health
    public int spellPointsP = 0;       // Increases overall Spellpoints
    public int energyPointsP = 0;      // Increases overall Energy
    public int lifestealP = 0;         // Life steal % (damage returned as health by %)    
    public int critChance = 0;
    public int critDamage = 0;
    [Header("Resistances")]
    // Resistances
    public int fireResistance = 0;
    public int waterResistance = 0;
    public int iceResistance = 0;
    public int thunderResistance = 0;
    public int windResistance = 0;
    public int earthResistance = 0;
    public int lightResistance = 0;
    public int darkResistance = 0;
    public int aetherResistance = 0;
    public int soulResistance = 0;
    public int poisonResistance = 0;
    public int bleedResistance = 0;

    [Header("Damage")]
    public Damage.DamageType primaryDamage;
    public Damage_OT.Damage_OTType primaryOTDamage;

    public int minDamage_P = 0;
    public int maxDamage_P = 0;
    public int minDamage_M = 0;
    public int maxDamage_M = 0;

    float veryWeakStat      = 0.50f;
    float weakStat          = 1.75f;
    float normalStat        = 3.00f;
    float strongStat        = 4.25f;
    float veryStrongStat    = 5.00f;
    float extremeStat       = 50.00f;

    float regenTime;

    public enum Classes
    {
        Warrior,
        Mage,
        Rogue,
        Hunter,
        Warlock,
        Paladin,
        Jinx
    }

    public void Start()
    {
        pstats = GameObject.FindGameObjectWithTag("PSTATS").GetComponent<Player_Stats_UI>();
        pvitals = GameObject.FindGameObjectWithTag("PVITALS").GetComponent<Player_Vitals_UI>();
        UpdateStatsFromEquipped();
        SetRequiredExp(playerLevel);

        currentHP = healthPoints;
        currentSP = spellPoints;
        currentEP = energyPoints;
    }

    public void Regen()
    {
        if (currentHP < healthPoints)
        {
            currentHP += 0.025f + (spirit / 1800f);
        }
        if (currentSP < spellPoints)
        {
            currentSP += 0.055f + (wisdom / 1800f);
        }
        if (currentEP < energyPoints)
        {
            currentEP += 0.055f + (endurance / 60000f);
        }   
        regenTime = 0.10f;
    }

    public void FixedUpdate()
    {
        
        ///TEST LEVEL UP
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LevelUp();
        }
        regenTime -= Time.deltaTime;
        if(regenTime <= 0)
        {
            Regen();
        }
        pvitals.UpdateVitals(playerLevel, currentHP, healthPoints, currentSP, spellPoints, currentEP, energyPoints, currentShield, shieldPoints, experience, requiredExp, playerName);
        CheckExperience();
    }

    public void SetWarriorPrimaries()
    {
        className = "Warrior"; // 1s, 4n, 1w, 1vw
        strength = baseStat + (int)((playerLevel + 1) * veryStrongStat);
        dexterity = baseStat + (int)((playerLevel + 1) * normalStat);
        intellect = baseStat + (int)((playerLevel + 1) * veryWeakStat);
        endurance = baseStat + (int)((playerLevel + 1) * normalStat);
        vitality = baseStat + (int)((playerLevel + 1) * normalStat);
        agility = baseStat + (int)((playerLevel + 1) * weakStat);
        luck = baseStat + (int)((playerLevel + 1) * normalStat);
    }

    public void SetMagePrimaries()
    {
        className = "Mage"; //  1s, 4n, 1w, 1vw
        strength = baseStat + (int)((playerLevel + 1) * veryWeakStat);
        dexterity = baseStat + (int)((playerLevel + 1) * normalStat);
        intellect = baseStat + (int)((playerLevel + 1) * veryStrongStat);
        endurance = baseStat + (int)((playerLevel + 1) * normalStat);
        vitality = baseStat + (int)((playerLevel + 1) * normalStat);
        agility = baseStat + (int)((playerLevel + 1) * weakStat);
        luck = baseStat + (int)((playerLevel + 1) * normalStat);
    }

    public void SetRoguePrimaries()
    {
        className = "Rogue"; // 2s, 2n, 3w, 0vw
        strength = baseStat + (int)((playerLevel + 1) * normalStat);
        dexterity = baseStat + (int)((playerLevel + 1) * strongStat);
        intellect = baseStat + (int)((playerLevel + 1) * weakStat);
        endurance = baseStat + (int)((playerLevel + 1) * weakStat);
        vitality = baseStat + (int)((playerLevel + 1) * weakStat);
        agility = baseStat + (int)((playerLevel + 1) * strongStat);
        luck = baseStat + (int)((playerLevel + 1) * normalStat);
    }

    public void SetHunterPrimaries()
    {
        className = "Hunter"; // 0vs, 0s, 5n, 2w, 0vw
        strength = baseStat + (int)((playerLevel + 1) * normalStat);
        dexterity = baseStat + (int)((playerLevel + 1) * normalStat);
        intellect = baseStat + (int)((playerLevel + 1) * normalStat);
        endurance = baseStat + (int)((playerLevel + 1) * weakStat);
        vitality = baseStat + (int)((playerLevel + 1) * weakStat);
        agility = baseStat + (int)((playerLevel + 1) * normalStat);
        luck = baseStat + (int)((playerLevel + 1) * normalStat);
    }

    public void SetPaladinPrimaries()
    {
        className = "Paladin"; // 0vs, 2s, 3n, 2w, 0vw
        strength = baseStat + (int)((playerLevel + 1) * normalStat);
        dexterity = baseStat + (int)((playerLevel + 1) * weakStat);
        intellect = baseStat + (int)((playerLevel + 1) * normalStat);
        endurance = baseStat + (int)((playerLevel + 1) * strongStat);
        vitality = baseStat + (int)((playerLevel + 1) * strongStat);
        agility = baseStat + (int)((playerLevel + 1) * weakStat);
        luck = baseStat + (int)((playerLevel + 1) * normalStat);
    }

    public void SetWarlockPrimaries()
    {
        className = "Warlock"; // 0vs, 2s, 1n, 3w, 1vw
        strength = baseStat + (int)((playerLevel + 1) * veryWeakStat);
        dexterity = baseStat + (int)((playerLevel + 1) * weakStat);
        intellect = baseStat + (int)((playerLevel + 1) * strongStat);
        endurance = baseStat + (int)((playerLevel + 1) * weakStat);
        vitality = baseStat + (int)((playerLevel + 1) * strongStat);
        agility = baseStat + (int)((playerLevel + 1) * weakStat);
        luck = baseStat + (int)((playerLevel + 1) * normalStat);
    }

    public void SetJinxPrimaries()
    {
        className = "Jinx"; // 1ex, 0vs, 0s, 0n, 6w, 4vw
        strength = baseStat + (int)((playerLevel + 1) * veryWeakStat);
        dexterity = baseStat + (int)((playerLevel + 1) * veryWeakStat);
        intellect = baseStat + (int)((playerLevel + 1) * veryWeakStat);
        endurance = baseStat + (int)((playerLevel + 1) * normalStat);
        vitality = baseStat + (int)((playerLevel + 1) * normalStat);
        agility = baseStat + (int)((playerLevel + 1) * veryWeakStat);
        luck = baseStat + (int)((playerLevel + 1) * extremeStat);
    }

    public void ResetStats()
    {
        if (playerClass == Classes.Warrior)
        {
            SetWarriorPrimaries();
        }
        else if (playerClass == Classes.Mage)
        {
            SetMagePrimaries();
        }
        else if (playerClass == Classes.Rogue)
        {
            SetRoguePrimaries();
        }
        else if (playerClass == Classes.Paladin)
        {
            SetPaladinPrimaries();
        }
        else if (playerClass == Classes.Hunter)
        {
            SetHunterPrimaries();
        }
        else if (playerClass == Classes.Warlock)
        {
            SetWarlockPrimaries();
        }
        else if (playerClass == Classes.Jinx)
        {
            SetJinxPrimaries();
        }

        fireResistance = 0;
        waterResistance = 0;
        iceResistance = 0;
        thunderResistance = 0;
        windResistance = 0;
        earthResistance = 0;
        lightResistance = 0;
        darkResistance = 0;
        soulResistance = 0;
        bleedResistance = 0;
        poisonResistance = 0;
        aetherResistance = 0;

        minDamage_M = 0;
        maxDamage_M = 0;
        minDamage_P = 0;
        maxDamage_P = 0;

        armor = 0;
        healthPoints = 0;
        spellPoints = 0;
        energyPoints = 0;
        bonusDamage = 0;
        perception = 0;

        magicFindP = 0;
        moneyFindP = 0;
        damageP = 0;
        healthPointsP = 0;
        spellPointsP = 0;
        energyPointsP = 0;
        lifestealP = 0;

        ResetModifiedCombosAndStats();
    }

    void ResetModifiedCombosAndStats()
    {
        InitializeModifiedCombos();
        SetSecondariesBasedOnModifiedCombos();
    }
    void InitializeModifiedCombos()
    {
        mstrength = strength;
        mdexterity = dexterity;
        mintellect = intellect;
        mendurance = endurance;
        mvitality = vitality;
        magility = agility;
        mluck = luck;
    }
    void SetSecondariesBasedOnModifiedCombos()
    {
        float best = 0.9f;
        float vGood = 0.8f;
        float good = 0.7f;
        float fine = 0.6f;
        float normal = 0.5f;
        float ok = 0.40f;
        float bad = 0.30f;
        float vBad = 0.20f;
        float terrible = 0.10f;

        int hpmod = 15;
        int spmod = 15;

        if (playerClass == Classes.Warrior)
        {
            armor = (int)((mendurance * vGood) / 50f);
            healthPoints = (int)(mvitality * vGood * hpmod);
            spellPoints = (int)(mintellect * bad * spmod);
            perception = (int)(mdexterity * ok);
            ferocity = (int)(mdexterity * good);
            speed = (int)(magility * fine);
            evasion = (int)(magility * bad);
            spirit = (int)(mvitality * ok);
            wisdom = (int)(mintellect * terrible);
            armorPen = (int)(mstrength * vGood);
            magicPen = (int)(mintellect * vBad);
        }
        else if (playerClass == Classes.Mage)
        {
            armor = (int)((mendurance * bad) / 50f);
            healthPoints = (int)(mvitality * ok * hpmod);
            spellPoints = (int)(mintellect * best * spmod);
            perception = (int)(mdexterity * fine);
            ferocity = (int)(mdexterity * ok);
            speed = (int)(magility * normal);
            evasion = (int)(magility * bad);
            spirit = (int)(mvitality * ok);
            wisdom = (int)(mintellect * vGood);
            armorPen = (int)(mstrength * bad);
            magicPen = (int)(mintellect * vGood);
        }
        else if (playerClass == Classes.Rogue)
        {
            armor = (int)((mendurance * ok) / 50f);
            healthPoints = (int)(mvitality * ok * hpmod);
            spellPoints = (int)(mintellect * bad * spmod);
            perception = (int)(mdexterity * vGood);
            ferocity = (int)(mdexterity * vGood);
            speed = (int)(magility * good);
            evasion = (int)(magility * good);
            spirit = (int)(mvitality * bad);
            wisdom = (int)(mintellect * terrible);
            armorPen = (int)(mstrength * vGood);
            magicPen = (int)(mintellect * vBad);
        }
        else if (playerClass == Classes.Paladin)
        {
            armor = (int)((mendurance * best) / 50f);
            healthPoints = (int)(mvitality * best * hpmod);
            spellPoints = (int)(mintellect * bad * spmod);
            perception = (int)(mdexterity * vBad);
            ferocity = (int)(mdexterity * vBad);
            speed = (int)(magility * bad);
            evasion = (int)(magility * bad);
            spirit = (int)(mvitality * good);
            wisdom = (int)(mintellect * fine);
            armorPen = (int)(mstrength * normal);
            magicPen = (int)(mintellect * vBad);
        }
        else if (playerClass == Classes.Hunter)
        {
            armor = (int)((mendurance * ok) / 50f);
            healthPoints = (int)(mvitality * ok * hpmod);
            spellPoints = (int)(mintellect * fine * spmod);
            perception = (int)(mdexterity * best);
            ferocity = (int)(mdexterity * normal);
            speed = (int)(magility * fine);
            evasion = (int)(magility * normal);
            spirit = (int)(mvitality * fine);
            wisdom = (int)(mintellect * fine);
            armorPen = (int)(mstrength * fine);
            magicPen = (int)(mintellect * ok);
        }
        else if (playerClass == Classes.Warlock)
        {
            armor = (int)((mendurance * vBad) / 50f);
            healthPoints = (int)(mvitality * good * hpmod);
            spellPoints = (int)(mintellect * vGood * spmod);
            perception = (int)(mdexterity * ok);
            ferocity = (int)(mdexterity * vGood);
            speed = (int)(magility * bad);
            evasion = (int)(magility * bad);
            spirit = (int)(mvitality * ok);
            wisdom = (int)(mintellect * good);
            armorPen = (int)(mstrength * ok);
            magicPen = (int)(mintellect * fine);
        }
        else if (playerClass == Classes.Jinx)
        {
            armor = (int)((mendurance * bad) / 50f);
            healthPoints = (int)(mvitality * bad * hpmod);
            spellPoints = (int)(mintellect * bad * spmod);
            perception = (int)(mdexterity * bad);
            ferocity = (int)(mdexterity * bad);
            speed = (int)(magility * bad);
            evasion = (int)(magility * bad);
            spirit = (int)(mvitality * bad);
            wisdom = (int)(mintellect * bad);
            armorPen = (int)(mstrength * bad);
            magicPen = (int)(mintellect * bad);
            magicFindP = (int)(mluck * best);
        }
    }

    public void FinalizeStats()
    {
        energyPoints = 15 + (int)(playerLevel * (1.35f + (playerLevel / 5f)));
        minDamage_P = 1 + (int)(minDamage_P * (1 + (damageP / 100f)) + bonusDamage + (strength / 2f));
        maxDamage_P = 3 + (int)(maxDamage_P * (1 + (damageP / 100f)) + bonusDamage + (strength / 2f));
        healthPoints = 25 + (int)((healthPoints) * (1 + (healthPointsP / 100f)));
        spellPoints = 15 + (int)((spellPoints) * (1 + (spellPointsP / 100f)));
        energyPoints = 5 + (int)((energyPoints) * (1 + (energyPointsP / 100f)));
        magicFindP = (int)((mluck * 0.7f) + ((playerLevel / 2f) * (mluck / 5f)));
        moneyFindP = (int)((mluck * 1.1f) + ((playerLevel / 2f) * (mluck / 5f)));

        critChance = 5 + (int)(perception / (playerLevel * 1.3f) + 5);
        critDamage = (int)(ferocity / (playerLevel * 1.3f) + 50);

        if(magicFindP >= 9950)
        {
            magicFindP = 9950;
        }

        Lucky = magicFindP;

        if (Lucky >= 9950)
        {
            Lucky = 9950;
        }
        Debug.Log("LootRoll is : (" + (Lucky * 10).ToString() + ",100000) ");
        if (speed < 1)
        {
            speed = 1;
        }
        GetComponent<Player_Movement>().speed = (speed * 1.0f);

        // set weapon element
        var p_Main = GetComponent<Player_Main>();
        if (p_Main.pE.equipSlots[5].item != null)
        {
            primaryDamage = p_Main.pE.equipSlots[5].item.d_Type;
            primaryOTDamage = p_Main.pE.equipSlots[5].item.do_Type;
        }
        else
        {
            primaryDamage = Damage.DamageType.Normal;
            primaryOTDamage = Damage_OT.Damage_OTType.Normal;
        }
        UpdateUI();
    }

    public void AddExperience(int xp)
    {
        experience += xp;
        CheckExperience();
    }

    public void SetRequiredExp(int lv)
    {
        requiredExp = lv * (lv + 5) * 15;
    }

    public void CheckExperience()
    {
        if(experience >= requiredExp)
        {
            LevelUp();
        }
    }

    public void LevelUp()
    {
        playerLevel++;
        var temp = experience - requiredExp;
        SetRequiredExp(playerLevel);   
        if (temp > 0)
        {
            experience = 0 + temp;
        }
        else
        {
            experience = 0;
        }
           
        UpdateStatsFromEquipped();
        currentHP = healthPoints;
        currentSP = spellPoints;
        currentEP = energyPoints;
    }

    public void UpdateStatsFromEquipped()
    {
        ResetStats();
        var items = GetComponent<Player_Equipped>().GetEquippedItems();
        foreach (Item i in items)
        {
            if (i != null)
            {
                ChangeStatsByItem(i);
            }
        }
        FinalizeStats();
    }

    void UpdateUI()
    {
        Player_Inventory pi = GetComponent<Player_Inventory>();
        pstats.SetMain(playerName, className, playerLevel.ToString(),pi.playerMoney);
        pstats.SetVitals(minDamage_P.ToString("0"), maxDamage_P.ToString("0"), armor.ToString("0"), currentShield.ToString("0"), shieldPoints.ToString("0"), currentHP.ToString("0"), healthPoints.ToString("0"), currentSP.ToString("0"), spellPoints.ToString("0"), currentEP.ToString("0"), energyPoints.ToString("0"));
        pstats.SetPrimaries(mstrength.ToString("0"), mdexterity.ToString("0"), mintellect.ToString("0"), mendurance.ToString("0"), mvitality.ToString("0"), magility.ToString("0"), mluck.ToString("0"));
        pstats.SetSecondaries(perception.ToString("0"), ferocity.ToString("0"), speed.ToString("0"), evasion.ToString("0"), spirit.ToString("0"), wisdom.ToString("0"), armorPen.ToString("0"));
        pstats.SetTertiaries(magicFindP.ToString("0"), moneyFindP.ToString("0"), damageP.ToString("0"), healthPointsP.ToString("0"), spellPointsP.ToString("0"), energyPointsP.ToString("0"), lifestealP.ToString("0"));
    }





    void ChangeStatsByItem(Item item)
    {
        ModifyComboStatsBasedOnItem(item);
        ModifySecondariesBasedOnItem(item);
        ModifyTertiaryBasedOnItem(item);
        ModifyResistancesBasedOnItem(item);
    }
    void ModifyComboStatsBasedOnItem(Item i)
    {
        mstrength += i.strength;
        mdexterity += i.dexterity;
        mintellect += i.intellect;
        mendurance += i.endurance;
        mvitality += i.vitality;
        magility += i.agility;
        mluck += i.luck;
    }
    void ModifySecondariesBasedOnItem(Item i)
    {
        minDamage_P += i.minDamage;
        maxDamage_P += i.maxDamage;
        armor += i.armor;
        healthPoints += i.healthPoints;
        spellPoints += i.spellPoints;
        energyPoints += i.energyPoints;   
        perception += i.perception;
        ferocity += i.ferocity;
        speed += i.speed;
        evasion += i.evasion;
        spirit += i.spirit;
        wisdom += i.wisdom;
        armorPen += i.armor_Pen;
        magicPen += i.spell_Pen;
    }
    void ModifyTertiaryBasedOnItem(Item i)
    {
        magicFindP += i.magic_chance;
        moneyFindP += i.currency_percent;
        damageP += i.damage_percent;
        healthPointsP += i.life_percent;
        spellPointsP += i.spell_percent;
        energyPointsP += i.energy_percent;
        lifestealP += i.lifesteal_percent;
    }

    void ModifyResistancesBasedOnItem(Item i)
    {
        fireResistance += i.fire_Resist;
        waterResistance += i.water_Resist;
        iceResistance += i.ice_Resist;
        thunderResistance += i.thunder_Resist;
        windResistance += i.wind_Resist;
        earthResistance += i.earth_Resist;
        lightResistance += i.light_Resist;
        darkResistance += i.dark_Resist;
        soulResistance += i.soul_Resist;
        bleedResistance += i.bleeding_Resist;
        poisonResistance += i.poison_Resist;
        aetherResistance += i.aether_Resist;
    }

    public Resistance GetResistanceForType(Damage.DamageType _type)
    {
        int x = 0;
        if (_type == Damage.DamageType.Aether)
        {
            x = aetherResistance;
        }
        else if (_type == Damage.DamageType.Dark)
        {
            x = darkResistance;
        }
        else if (_type == Damage.DamageType.Earth)
        {
            x = earthResistance;
        }
        else if (_type == Damage.DamageType.Fire)
        {
            x = fireResistance;
        }
        else if (_type == Damage.DamageType.Ice)
        {
            x = iceResistance;
        }
        else if (_type == Damage.DamageType.Light)
        {
            x = lightResistance;
        }
        else if (_type == Damage.DamageType.Normal)
        {
            x = armor;
        }
        else if (_type == Damage.DamageType.Soul)
        {
            x = soulResistance;
        }
        else if (_type == Damage.DamageType.Thunder)
        {
            x = thunderResistance;
        }
        else if (_type == Damage.DamageType.Water)
        {
            x = waterResistance;
        }
        else if (_type == Damage.DamageType.Wind)
        {
            x = windResistance;
        }
        return new Resistance(x, _type);
    }
    public Resistance GetResistanceForType(Damage_OT.Damage_OTType _type)
    {
        int x = 0;
        if (_type == Damage_OT.Damage_OTType.Bleeding)
        {
            x = bleedResistance;
        }
        else if (_type == Damage_OT.Damage_OTType.Fire)
        {
            x = fireResistance;
        }
        else if (_type == Damage_OT.Damage_OTType.Poison)
        {
            x = poisonResistance;
        }

        return new Resistance(x, _type);
    }
}
