using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic_Projectile : MonoBehaviour {

    Magic magic;

    Vector2 target;
    Rigidbody2D rb;

    float lifeSpan = 1f;
    float projectileSpeed = 1f;

    Vector2 heading;
    float distance;
    Vector2 direction;


    public void Start()
    {
        AudioSource.PlayClipAtPoint(magic.life, transform.position);
    }

    public void InitializeProjectile(Magic _magic, Vector2 _target)
    {
        rb = GetComponent<Rigidbody2D>();
        magic = _magic;
        projectileSpeed = magic.spellSpeed;
        target = _target;
        heading = new Vector2(transform.position.x,transform.position.y) - target;
        distance = heading.magnitude;
        direction = heading / distance;
        rb.velocity = (-direction * projectileSpeed);
        //AudioSource.PlayClipAtPoint(magic.life, transform.position);
        Debug.Log("Projectile Fired - Heading : (" + heading + ")," + "Target : (" + target + ")," + "Distance : (" + distance + ")," + "Direction : (" + direction + ")!");
    }

    public void FixedUpdate()
    {
        lifeSpan -= Time.deltaTime;

        if(lifeSpan <= 0)
        {
            KillYourSelf();
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if(tag == "PlayerProjectile" && col.tag == "Monster")
        {
            int x = Damage_Calculator.CalculateElementDamageToMonster(magic.d,col.GetComponent<Monster>());
            col.GetComponent<Monster>().TakeDamage(magic.d,x);
            if (magic.dot.GetDamage_OTType() != Damage_OT.Damage_OTType.Normal)
            {
                GameObject debuff = Instantiate(new GameObject(), col.transform);
                debuff.AddComponent<De_Buff>().InitializeDeBuff(magic.dot);
            }
            if (!magic.isPiercing)
            {
                KillYourSelf();
            }
        }
    }

    public void KillYourSelf()
    {
        AudioSource.PlayClipAtPoint(magic.death, transform.position);
        Destroy(gameObject);
    }

}
