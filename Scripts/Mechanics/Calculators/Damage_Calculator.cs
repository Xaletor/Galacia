using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Damage_Calculator {


    public static int CalculateElementDamageToPlayer(Monster m, Damage x, Resistance y) // When monster attacks player
    {
        x.RunCritDice(0, 100, 5, 1.5f);
        int d = 0;
        int r = y.GetResistanceAmount();

        int ele_halfsies = (int)(x.GetDamageAmount() / 2f);
        int arm_halfsies = ele_halfsies;

        int halfe = 0;
        int halfa = 0;

        if (y.GetResistanceType() != Damage.DamageType.Normal)
        {
            if ((int)x.GetDamageType() == (int)y.GetResistanceType())    // if the damage element is the same as players resistant element
            {
                if (r > 100)
                {
                    halfe = (int)((ele_halfsies - ((ele_halfsies * y.GetResistanceAmount()) / 100f)));
                }
                else if (r == 0)
                {
                    halfe = ele_halfsies;
                }
                else if (r != 0)
                {
                    halfe = (int)(ele_halfsies - ((ele_halfsies * y.GetResistanceAmount()) / 100));
                }
            }
        }
        else
        {
            arm_halfsies += ele_halfsies;
            halfe = 0;
        }
        var ps = GameObject.Find("Player").GetComponent<Player_Stats>();
        // PLACE ARMOR FORMULA HERE

        if (m.level >= (ps.playerLevel - 10))
        {
            halfa = (arm_halfsies - (ps.armor));
        }
        else
        {
            halfa = ((arm_halfsies - (int)(ps.armor / (ps.playerLevel / (25f * ps.playerLevel)))));
        }

        if (halfa < 0)
        {
            halfa = 0;
        }

        d = halfa + halfe;

        return d;
    }

    public static int CalculateElementDamageToMonster(Damage x, Monster y)
    {
        Damage.DamageType dt = x.GetDamageType();
        Damage.DamageType mt = y.mobElement;

        int d = 0;
        if ((int)dt == (int)mt)  // If attack element is same element as monster
        {
            if (x.isBasic)
            {
                d = (int)((x.GetDamageAmount() / 2f)) * -1; // heal 50% damage
            }
            else if (x.isSpecial)
            {
                d = (int)(x.GetDamageAmount() * -1f);        // heal 100% damage
            }
            else if (x.isPowerful)
            {
                d = (int)((x.GetDamageAmount() * -1.5f));   // heal 150% damage
            }
            else
            {
                d = (x.GetDamageAmount());
            }
        }
        else if ((int)dt != (int)mt)    // If attack element isn't the same as monster element
        {
            if (x.isBasic)
            {
                if ((dt == Damage.DamageType.Fire && mt == Damage.DamageType.Ice) ||  // Effective Basic
                    (dt == Damage.DamageType.Water && mt == Damage.DamageType.Fire) ||
                    (dt == Damage.DamageType.Ice && mt == Damage.DamageType.Earth) ||
                    (dt == Damage.DamageType.Thunder && mt == Damage.DamageType.Water) ||
                    (dt == Damage.DamageType.Earth && mt == Damage.DamageType.Thunder))
                {
                    d = (int)(x.GetDamageAmount() * 1.5f);
                }
                else if ((dt == Damage.DamageType.Fire && mt == Damage.DamageType.Water) ||        // Not-Effective Basic
                         (dt == Damage.DamageType.Water && mt == Damage.DamageType.Thunder) ||
                         (dt == Damage.DamageType.Ice && mt == Damage.DamageType.Fire) ||
                         (dt == Damage.DamageType.Thunder && mt == Damage.DamageType.Earth) ||
                         (dt == Damage.DamageType.Earth && mt == Damage.DamageType.Ice) ||
                         (dt == Damage.DamageType.Wind && mt == Damage.DamageType.Wind))
                {
                    d = (int)(x.GetDamageAmount() * 0.5f);
                }
                else
                {
                    d = (x.GetDamageAmount());
                }
            }
            else if (x.isSpecial)
            {
                if ((dt == Damage.DamageType.Light && mt == Damage.DamageType.Dark) ||
                (dt == Damage.DamageType.Dark && mt == Damage.DamageType.Light))

                {
                    d = (int)(x.GetDamageAmount() * 2.0f);
                }
                else
                {
                    d = (int)(x.GetDamageAmount() * 1.0f);
                }
            }
            else if (x.isPowerful)
            {
                if ((dt == Damage.DamageType.Soul && mt != Damage.DamageType.Soul))
                {
                    d = (int)((x.GetDamageAmount() * 1.5f));
                }
            }
            else // Normal Attack
            {
                d = (x.GetDamageAmount());
            }
        }
        return d;
    }

    public static int CalculateElementDamageOTToPlayer(int level, Damage_OT dot, Resistance y)
    {
        var ps = GameObject.Find("Player").GetComponent<Player_Stats>();

        int d = 0;
        if (dot.GetDamage_OTType() != Damage_OT.Damage_OTType.Normal)
        {
            if (dot.GetDamage_OTType() == y.GetResistanceOTType())
            {
                int r = y.GetResistanceAmount();
                if (r > 100)
                {
                    d = (int)((((r - 100f) / 100f) + 1f) * -1f);
                }
                else if (r == 0)
                {
                    d = (int)(dot.GetDamage_OTAmount() / (y.GetResistanceAmount() + 1f));
                }
                else if (r != 0)
                {
                    d = (dot.GetDamage_OTAmount() / (y.GetResistanceAmount()));
                }
            }
        }
        else
        {
            if (level >= (ps.playerLevel - 10))
            {
                d = ((dot.GetDamage_OTAmount() - (ps.armor / ps.playerLevel)));
            }
            else
            {
                d = ((dot.GetDamage_OTAmount() - (int)(ps.armor / (ps.playerLevel / (25f * ps.playerLevel)))));
            }
            if (d < 0)
            {
                d = 0;
            }
        }
        return d;
    }

    public static int CalculateElementDamageOTToMonster(Damage_OT dot, Monster y)
    {
        int d = 0;
        Damage_OT.Damage_OTType otype = dot.GetDamage_OTType();
        Damage_OT.Damage_OTType poi = Damage_OT.Damage_OTType.Poison;

        //Damage_OT.Damage_OTType ble = Damage_OT.Damage_OTType.Bleeding;
        Damage_OT.Damage_OTType fir = Damage_OT.Damage_OTType.Fire;

        Damage.DamageType m = y.mobElement;

        if (otype == poi && m == Damage.DamageType.Poison)
        {
            d = (int)((dot.GetDamage_OTAmount() / 2f)) * -1;
        }
        else if (otype == fir && m == Damage.DamageType.Fire)
        {
            d = (int)((dot.GetDamage_OTAmount() / 2f)) * -1;
        }
        else
        {
            d = dot.GetDamage_OTAmount();
        }
        return d;
    }

}
