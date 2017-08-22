using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_OT {

    int amount = 0;
    Damage_OTType type = Damage_OTType.Fire;
    float duration = 0f;

    public Damage_OT(Damage_OTType _type, int _amount, float _time)
    {
        SetDamage_OTType(_type);
        SetDamage_OTAmount(_amount);
        SetDamage_OTDuration(_time);
    }

    public Damage_OT()
    {
        SetDamage_OTType(Damage_OTType.Normal);
        SetDamage_OTAmount(0);
        SetDamage_OTDuration(0f);
    }

    public enum Damage_OTType
    {
        Normal,
        Fire,
        Poison,
        Bleeding,
    }

    public Damage_OTType GetDamage_OTType()
    {
        return type;
    }

    public void SetDamage_OTType(Damage_OTType t)
    {
        type = t;
    }

    public int GetDamage_OTAmount()
    {
        return amount;
    }

    public void SetDamage_OTAmount(int _amount)
    {
        amount = _amount;
    }

    public float GetDamage_OTDuration()
    {
        return duration;
    }

    public void SetDamage_OTDuration(float t)
    {
        duration = t;
    }
}
