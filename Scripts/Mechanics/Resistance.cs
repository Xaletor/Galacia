using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resistance {

    int amount = 0;
    Damage.DamageType type = Damage.DamageType.Normal;
    Damage_OT.Damage_OTType oType = Damage_OT.Damage_OTType.Normal;

    public Resistance(int _amount, Damage.DamageType _type)
    {
        SetResistanceType(_type);
        SetResistanceAmount(_amount);
    }

    public Resistance(int _amount, Damage_OT.Damage_OTType _type)
    {
        SetResistanceType(_type);
        SetResistanceAmount(_amount);
    }

    public enum ResistanceType
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
        Aether,

    }

    public Damage.DamageType GetResistanceType()
    {
        return type;
    }

    public Damage_OT.Damage_OTType GetResistanceOTType()
    {
        return oType;
    }

    public void SetResistanceType(Damage.DamageType t)
    {
        type = t;
    }

    public void SetResistanceType(Damage_OT.Damage_OTType t)
    {
        oType = t;
    }

    public int GetResistanceAmount()
    {
        return amount;
    }

    public void SetResistanceAmount(int _amount)
    {
        amount = _amount;
    }

}
