using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic_Database : MonoBehaviour {

    [Header("Spell Prefabs")]
    public List<GameObject> fireSpells;
    public List<GameObject> waterSpells;
    public List<GameObject> iceSpells;
    public List<GameObject> thunderSpells;
    public List<GameObject> windSpells;
    public List<GameObject> earthSpells;
    public List<GameObject> lightSpells;
    public List<GameObject> darkSpells;
    public List<GameObject> soulSpells;
    public List<GameObject> bleedingSpells;
    public List<GameObject> poisonSpells;
    public List<GameObject> aetherSpells;

    [Header("Spell Sounds")]
    public List<AudioClip> ins_fireSounds;
    public List<AudioClip> ins_waterSounds;
    public List<AudioClip> ins_iceSounds;
    public List<AudioClip> ins_thunderSounds;
    public List<AudioClip> ins_windSounds;
    public List<AudioClip> ins_earthSounds;
    public List<AudioClip> ins_lightSounds;
    public List<AudioClip> ins_darkSounds;
    public List<AudioClip> ins_soulSounds;
    public List<AudioClip> ins_bleedingSounds;
    public List<AudioClip> ins_poisonSounds;
    public List<AudioClip> ins_aetherSounds;

    public static List<AudioClip> fireSounds;
    public static List<AudioClip> waterSounds;
    public static List<AudioClip> iceSounds;
    public static List<AudioClip> thunderSounds;
    public static List<AudioClip> windSounds;
    public static List<AudioClip> earthSounds;
    public static List<AudioClip> lightSounds;
    public static List<AudioClip> darkSounds;
    public static List<AudioClip> soulSounds;
    public static List<AudioClip> bleedingSounds;
    public static List<AudioClip> poisonSounds;
    public static List<AudioClip> aetherSounds;

    public void Awake()
    {
        fireSounds = ins_fireSounds;
        waterSounds = ins_waterSounds;
        iceSounds = ins_iceSounds;
        thunderSounds = ins_thunderSounds;
        windSounds = ins_windSounds;
        earthSounds = ins_earthSounds;
        lightSounds = ins_lightSounds;
        darkSounds = ins_darkSounds;
        soulSounds = ins_soulSounds;
        bleedingSounds = ins_bleedingSounds;
        poisonSounds = ins_poisonSounds;
        aetherSounds = ins_aetherSounds;
    }


    public enum Magic_Type
    {
        None,
        Fire,
        Water,
        Ice,
        Thunder,
        Wind,
        Earth,
        Light,
        Dark,
        Soul,
        Bleeding,
        Poison,
        Aether,
    }

    public enum Fire_Spells
    {
        None,
        Firebolt,
        FireMastery,
    }
    public enum Water_Spells
    {
        None,
        Aquabolt,
        WaterMastery,
    }
    public enum Ice_Spells
    {
        None,
        Icebolt,
        IceMastery,
    }
    public enum Thunder_Spells
    {
        None,
        Thunderbolt,
        ThunderMastery,
    }
    public enum Wind_Spells
    {
        None,
        Gust,
        WindMastery,
    }
    public enum Earth_Spells
    {
        None,
        StoneBolt,
        EarthMastery,
    }
    public enum Light_Spells
    {
        None,
        Ray,
        LightMastery,
    }
    public enum Dark_Spells
    {
        None,
        Darkbolt,
        DarkMastery,
    }
    public enum Soul_Spells
    {
        None,
        SpiritBolt,
        SoulMastery,
    }
    public enum Bleeding_Spells
    {
        None,
        Blades,
        BleedMastery,
    }
    public enum Poison_Spells
    {
        None,
        PoisonBolt,
        PoisonGas,
    }
    public enum Aether_Spells
    {
        None,
        AetherBolt,
        AetherMastery,
    }

    public GameObject GetSpellProjectile(Magic m, int index)
    {
        if (m.magicType == Magic_Type.Aether)
        {
            return aetherSpells[index];
        }
        else if (m.magicType == Magic_Type.Bleeding)
        {
            return bleedingSpells[index];
        }
        else if (m.magicType == Magic_Type.Dark)
        {
            return darkSpells[index];
        }
        else if (m.magicType == Magic_Type.Earth)
        {
            return earthSpells[index];
        }
        else if (m.magicType == Magic_Type.Fire)
        {
            return fireSpells[index];
        }
        else if (m.magicType == Magic_Type.Ice)
        {
            return iceSpells[index];
        }
        else if (m.magicType == Magic_Type.Light)
        {
            return lightSpells[index];
        }
        else if (m.magicType == Magic_Type.Poison)
        {
            return poisonSpells[index];
        }
        else if (m.magicType == Magic_Type.Soul)
        {
            return soulSpells[index];
        }
        else if (m.magicType == Magic_Type.Thunder)
        {
            return thunderSpells[index];
        }
        else if (m.magicType == Magic_Type.Water)
        {
            return waterSpells[index];
        }
        else if (m.magicType == Magic_Type.Wind)
        {
            return windSpells[index];
        }
        return aetherSpells[index];
    }

    public static void SetMagicSpell(Magic m, int index)
    {
        if (m != null)
        {

            if (m.magicType == Magic_Type.Aether)
            {
                GetAetherSpell(m, index);
            }
            else if (m.magicType == Magic_Type.Bleeding)
            {
                GetBleedingSpell(m, index);
            }
            else if (m.magicType == Magic_Type.Dark)
            {
                GetDarkSpell(m, index);
            }
            else if (m.magicType == Magic_Type.Earth)
            {
                GetEarthSpell(m, index);
            }
            else if (m.magicType == Magic_Type.Fire)
            {
                GetFireSpell(m, index);
            }
            else if (m.magicType == Magic_Type.Ice)
            {
                GetIceSpell(m, index);
            }
            else if (m.magicType == Magic_Type.Light)
            {
                GetLightSpell(m, index);
            }
            else if (m.magicType == Magic_Type.Poison)
            {
                GetPoisonSpell(m, index);
            }
            else if (m.magicType == Magic_Type.Soul)
            {
                GetSoulSpell(m, index);
            }
            else if (m.magicType == Magic_Type.Thunder)
            {
                GetThunderSpell(m, index);
            }
            else if (m.magicType == Magic_Type.Water)
            {
                GetWaterSpell(m, index);
            }
            else if (m.magicType == Magic_Type.Wind)
            {
                GetWindSpell(m, index);
            }
        }
    }

    public static void GetFireSpell(Magic m, int i)
    {
        if (i == 1)
        {
            m.name = "Fire Bolt";
            m.spellSpeed = 9f;
            m.birth = fireSounds[0];
            m.life = fireSounds[1];
            m.death = fireSounds[2];
            m.circleColor = Galacia_Colors.Fire;
            m.manaCost = 2 + (int)((m.skillLevel - 1) * 1.5f);
            m.spellSpeed = 9f;
            m.isPiercing = false;
            m.d = new Damage(Damage.DamageType.Fire, 15);
            m.d.SetDamageAmount((int)(1 * (m.userIntellect / 32f)) + (int)(m.skillLevel * 2f), (int)(3 * (m.userIntellect / 16f)) + (int)(m.skillLevel * 4f));
            m.dot = new Damage_OT(Damage_OT.Damage_OTType.Fire, (2 + (int)(m.skillLevel * 1.5f)), 3 + (int)(m.skillLevel * 0.25f));

        }
        else if (i == 2)
        {
            m.name = "Fire Mastery";
            m.manaCost = 0;
        }
    }
    public static void GetWaterSpell(Magic m, int i)
    {
        if (i == 0)
        {
            m.name = "Fire Bolt";
            m.manaCost = 3 + (int)(m.skillLevel * 1.5f);
        }
    }
    public static void GetIceSpell(Magic m, int i)
    {
        if (i == 0)
        {
            m.name = "Fire Bolt";
            m.manaCost = 3 + (int)(m.skillLevel * 1.5f);
        }
    }
    public static void GetThunderSpell(Magic m, int i)
    {
        if (i == 0)
        {
            m.name = "Fire Bolt";
            m.manaCost = 3 + (int)(m.skillLevel * 1.5f);
        }
    }
    public static void GetWindSpell(Magic m, int i)
    {
        if (i == 0)
        {
            m.name = "Fire Bolt";
            m.manaCost = 3 + (int)(m.skillLevel * 1.5f);
        }
    }
    public static void GetEarthSpell(Magic m, int i)
    {
        if (i == 0)
        {
            m.name = "Fire Bolt";
            m.manaCost = 3 + (int)(m.skillLevel * 1.5f);
        }
    }
    public static void GetLightSpell(Magic m, int i)
    {
        if (i == 0)
        {
            m.name = "Fire Bolt";
            m.manaCost = 3 + (int)(m.skillLevel * 1.5f);
        }
    }
    public static void GetDarkSpell(Magic m, int i)
    {
        if (i == 0)
        {
            m.name = "Fire Bolt";
            m.manaCost = 3 + (int)(m.skillLevel * 1.5f);
        }
    }
    public static void GetSoulSpell(Magic m, int i)
    {
        if (i == 0)
        {
            m.name = "Fire Bolt";
            m.manaCost = 3 + (int)(m.skillLevel * 1.5f);
        }
    }
    public static void GetBleedingSpell(Magic m, int i)
    {
        if (i == 0)
        {
            m.name = "Fire Bolt";
            m.manaCost = 3 + (int)(m.skillLevel * 1.5f);
        }
    }
    public static void GetPoisonSpell(Magic m, int i)
    {
        if (i == 1)
        {
            m.name = "Poison Bolt";
            m.spellSpeed = 9f;
            m.birth = poisonSounds[0];
            m.life = poisonSounds[1];
            m.death = poisonSounds[2];
            m.circleColor = Galacia_Colors.Poison;
            m.manaCost = 2;//2 + (int)((m.skillLevel - 1) * 1.5f);
            m.spellSpeed = 9f;
            m.isPiercing = false;
            m.d = new Damage(Damage.DamageType.Poison, 15);
            m.d.SetDamageAmount((int)(1 * (m.userIntellect / 32f)) + (int)(m.skillLevel * 2f), (int)(3 * (m.userIntellect / 16f)) + (int)(m.skillLevel * 4f));
            m.dot = new Damage_OT(Damage_OT.Damage_OTType.Poison, (2 + (int)(m.skillLevel * 1.5f)), 5 + (int)(m.skillLevel * 0.25f));

        }
        if (i == 2)
        {
            m.name = "Poison Gas";
            m.birth = poisonSounds[0];
            m.life = poisonSounds[1];
            m.death = poisonSounds[2];
            m.circleColor = Galacia_Colors.Poison;
            m.manaCost = 2 + (int)((m.skillLevel - 1) * 1.5f);
            m.spellSpeed = 2f;
            m.isPiercing = true;
            m.d = new Damage(Damage.DamageType.Poison, 15);
            m.d.SetDamageAmount((int)(1 * (m.userIntellect / 32f)) + (int)(m.skillLevel * 2f), (int)(3 * (m.userIntellect / 16f)) + (int)(m.skillLevel * 4f));
            m.dot = new Damage_OT(Damage_OT.Damage_OTType.Poison, (2 + (int)(m.skillLevel * 1.5f)), 5 + (int)(m.skillLevel * 0.50f));

        }
    }
    public static void GetAetherSpell(Magic m, int i)
    {
        if (i == 1)
        {
            m.name = "Aether Bolt";
            m.spellSpeed = 9f;
            m.birth = aetherSounds[0];
            m.life = aetherSounds[1];
            m.death = aetherSounds[2];
            m.circleColor = Galacia_Colors.Aether;
            m.manaCost = 2 + (int)((m.skillLevel - 1) * 1.5f);
            m.spellSpeed = 9f;
            m.isPiercing = true;
            m.d = new Damage(Damage.DamageType.Aether, 15);
            m.d.SetDamageAmount((int)(1 * (m.userIntellect/32f)) + (int)(m.skillLevel * 2f), (int)(3 * (m.userIntellect / 16f)) + (int)(m.skillLevel * 4f));
            m.dot = new Damage_OT();
            m.dot.SetDamage_OTType(Damage_OT.Damage_OTType.Normal);
        }
    }

}
