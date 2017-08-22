using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Magic
{

    public AudioClip birth;
    public AudioClip life;
    public AudioClip death;
    public Color circleColor;
    public AnimationClip initialize;

    public string name;
    public int manaCost;
    public float spellSpeed;
    public bool isPiercing = false;
    public Tier tier;
    public int skillLevel = 1;
    public int userIntellect;
    public int requiredPointsToLevel;
    public int levelRequirement;
    public int level;
    public int minD;
    public int maxD;

    

    public bool passive = false;
    int index;
    public Damage d;
    public Damage_OT dot;

    public Magic_Database.Magic_Type magicType = Magic_Database.Magic_Type.None;
    public Damage.DamageType magicDamageType = Damage.DamageType.Normal;
    public Damage_OT.Damage_OTType magicDamageOTType = Damage_OT.Damage_OTType.Normal;

    public enum Tier
    {
        Tier1,
        Tier2,
        Tier3,
        Tier4,
        Tier5,
        Tier6,
        Tier7,
        Tier8,
        Tier9,
    }

    public void IncreaseMagicLevel()
    {
        skillLevel++;
        Magic_Database.SetMagicSpell(this, index);
    }
    public void SetMagicDamage(int x)
    {
        userIntellect += x;
        Magic_Database.SetMagicSpell(this, index);
    }

    public void SetMagicSkillLevel(int x)
    {
        skillLevel = x;
        Magic_Database.SetMagicSpell(this, index);
    }

    public Magic(Magic_Database.Magic_Type t , int i)
    {
        magicType = t;
        index = i;
        Magic_Database.SetMagicSpell(this, index);
    }

}


