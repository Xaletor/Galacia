using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage {

    int min = 0;
    int max = 0;
    DamageType type = DamageType.Normal;
    public bool isCritical = false;
    public bool isBasic = false;
    public bool isSpecial = false;
    public bool isPowerful = false;

    public Damage(DamageType _type, int _min, int _max)
    {
        SetBools(false, false, false);
        SetDamageType(_type);
        CheckType();
        SetDamageAmount(_min, _max); ;
    }
    public Damage(DamageType _type, int _amount)
    {
        SetBools(false, false, false);
        SetDamageType(_type);
        CheckType();
        SetDamageAmount(_amount);
    }

    void CheckType()
    {
        if(    type == DamageType.Fire 
            || type == DamageType.Water
            || type == DamageType.Thunder
            || type == DamageType.Ice
            || type == DamageType.Wind
            || type == DamageType.Earth)
        {
            SetBools(true, false, false);
        }
        else if (type == DamageType.Light || type == DamageType.Dark)
        {
            SetBools(false, true, false);
        }
        else if(type == DamageType.Soul)
        {
            SetBools(false, false, true);
        }
    }

    public void RunCritDice(int _min, int _max, int chance, float multiplier)
    {
        int x = Random.Range(_min, _max + 1);
        if(x <= chance)
        {
            isCritical = true;
            min = (int)(min * multiplier);
            max = (int)(max * multiplier);
        }
        else
        {
            isCritical = false;
        }
    }

    public enum DamageType
    {
        Normal = 0,
        Fire,
        Water,
        Ice,
        Thunder,
        Wind,
        Earth,
        Light,
        Dark,
        Soul, 
        Poison,  
        Aether,
        Random
    }

    void SetBools(bool x,bool y,bool z)
    {
        isBasic = x;
        isSpecial = y;
        isPowerful = z;
    }


    public DamageType GetDamageType()
    {
        return type;
    }

    public void SetDamageType(DamageType t)
    {
        type = t;
    }

    public int GetDamageAmount()
    {
        return Random.Range(min,max + 1);
    }

    public void SetDamageAmount(int _amount)
    {
        max = _amount;
        min = max;
    }

    public void SetDamageAmount(int _min, int _max)
    {
        min = _min;
        max = _max;
    }

}
