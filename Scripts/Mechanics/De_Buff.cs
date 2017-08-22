using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class De_Buff : MonoBehaviour {

    Damage_OT dot;

    int level;
    float dotTime;
    float ticker;

    public void InitializeDeBuff(Damage_OT _dot)
    {
        dot = _dot;
        dotTime = dot.GetDamage_OTDuration();
        ticker = 1f;
    }

    public void CheckDebuff()
    {
        if(ticker <= 0f)
        {
            Attack();    
            ticker = 2f;
            dotTime -= ticker;

            if(dotTime <= 0f)
            {
                KillYourSelf();
            }
        }
    }

    public void FixedUpdate()
    {
        ticker -= Time.deltaTime;
        CheckDebuff();
    }

    public void Attack()
    {
        var m = GetComponentInParent<Monster>();
        var p = GetComponentInParent<Player_Main>();
        if(dot.GetDamage_OTAmount() <= 0)
        {
            dot.SetDamage_OTAmount(1);
        }
        if(m != null)
        {
            int x = Damage_Calculator.CalculateElementDamageOTToMonster(dot,m);
            m.TakeDamageOT(dot, x);
        }
        else if(p != null)
        {
            
            int x = Damage_Calculator.CalculateElementDamageOTToPlayer(level,dot,p.pS.GetResistanceForType(dot.GetDamage_OTType()));
            var dui = GameObject.FindGameObjectWithTag("DamageText");
            GameObject dtui = Instantiate(dui, dui.transform.parent.parent) as GameObject;
            Vector2 cam = Camera.main.WorldToScreenPoint(transform.position);
            dtui.transform.position = cam;
            dtui.AddComponent<DamageText_UI>().SetDamage(dot, x, true);
            p.TakeDamage(x,true);
        }
        else
        {
            
        }
    }

    public void KillYourSelf()
    {
        Destroy(gameObject);
    }

}
