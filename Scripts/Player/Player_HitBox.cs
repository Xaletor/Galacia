using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_HitBox : MonoBehaviour {

    public void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Monster" && tag == "PHITBOX")
        {
            var b = GetComponentInParent<Player_Main>();
            if (!b.invulnerable)
            {
                Damage d = null;
                var m = col.GetComponent<Monster>();
                if (m.mobElement == Damage.DamageType.Poison)
                {
                    Damage_OT dot = new Damage_OT(Damage_OT.Damage_OTType.Poison, (int)(Random.Range(m.minDamage, m.maxDamage) / 5f), 1.00f);
                    GameObject debuff = Instantiate(new GameObject(), b.transform);
                    debuff.AddComponent<De_Buff>().InitializeDeBuff(dot);
                    d = new Damage(m.mobElement, m.minDamage / 3, m.maxDamage / 3);
                }

                else
                {
                    d = new Damage(m.mobElement, m.minDamage, m.maxDamage);
                }
                Resistance r = (GetComponentInParent<Player_Stats>().GetResistanceForType(m.mobElement));

                int x = Damage_Calculator.CalculateElementDamageToPlayer(m,d,r);
                b.TakeDamage(x);
                var dui = GameObject.FindGameObjectWithTag("DamageText");

                if (DamageTextManager.IsOkToCreate())
                {
                    GameObject dtui = Instantiate(dui, dui.transform.parent.parent) as GameObject;
                    Vector2 cam = Camera.main.WorldToScreenPoint(transform.position);
                    dtui.transform.position = cam;
                    dtui.AddComponent<DamageText_UI>().SetDamage(d, x, true);
                }
            }
        }
    }

}
