using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

    public float aggroRange;
    public bool flying = false;
    public RectTransform hp_Bar;

    public int level;
    public string name;
    public int minDamage;
    public int maxDamage;
    public int cbp;
    public int chp;
    public int csp;
    public int bp;
    public int hp;
    public int sp;
    public int exp;

    public float minSpeed;
    public float maxSpeed;
    bool dying = false;
    public int monsterSound = 0;

    AudioSource aS;
    Animator animator;
    SoundManager sM;
    GameObject player;

    void Start()
    {
        animator = GetComponent<Animator>();
        aS = GetComponent<AudioSource>();
        sM = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        SetStats();
        StartVitals();
        player = GameObject.Find("Player");
        playerTarget = player.transform;
        GetComponent<AI_Movement>().speed = Random.Range(minSpeed, maxSpeed);
        speed =  Random.Range(minSpeed, maxSpeed);
    }

    public Damage.DamageType mobElement = Damage.DamageType.Normal;
    public Monster_Class mobClass = Monster_Class.Normal;
    public enum Monster_Element
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
        Aether,
        Random
    }

    public enum Monster_Class
    {
        
        Normal,
        Tank,
        Fast,
        Strong,
        Elite,
        Random
    }

    public void StartVitals()
    {
        cbp = bp;
        chp = hp;
        csp = sp;
    }

    public void SetStats()
    {
        if (mobElement == Damage.DamageType.Random)
        {
            mobElement = (Damage.DamageType)Random.Range(0, 12);
        }
        if (mobClass == Monster_Class.Random)
        {
            mobClass = (Monster_Class)Random.Range(0, 5);
        }
        if (mobClass != Monster_Class.Normal)
        {
            if (mobClass == Monster_Class.Tank)
            {
                SetStatsForTank();
            }
            else if (mobClass == Monster_Class.Fast)
            {
                SetStatsForFast();
            }
            else if (mobClass == Monster_Class.Strong)
            {
                SetStatsForStrong();
            }
            else if (mobClass == Monster_Class.Elite)
            {
                SetStatsForElite();
            }
        }
        else
        {
            SetStatsForNormal();
        }   
    }

    void SetStatsForNormal()
    {
        transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
        hp = 15 + (int)(level * (level + 3) * (2.45f / 1.9f));
        sp = 5 + (int)(level * (level + 3) * (1.85f / 2f));
        minDamage = 5 + (int)(level * (level + 3) * (1.15f / 12f));
        maxDamage = 10 + (int)(level * (level + 3) * (1.35f / 10f));
        exp = 1 + (int)((level * (level + 1) * 1f + ((maxDamage + hp) / 1.66f)) / 4.33f);
    }

    void SetStatsForTank()
    {
        transform.localScale = new Vector3(3f, 3f, 2f);
        hp = 20 + (int)(level * (level + 4) * (2.55f / 1.9f));
        sp = 5 + (int)(level * (level + 3) * (1.85f / 2f));
        minDamage = 2 + (int)(level * (level + 1) * (1.05f / 12f));
        maxDamage = 5 + (int)(level * (level + 3) * (1.25f / 10f));
        exp = 1 + (int)((level * (level + 1) * 1f + ((maxDamage + hp) / 1.66f)) / 4.33f);
    }

    void SetStatsForFast()
    {
        transform.localScale = new Vector3(1f, 1f, 2f);
        hp = 10 + (int)(level * (level + 2) * (2.35f / 1.9f));
        sp = 5 + (int)(level * (level + 3) * (1.85f / 2f));
        minDamage = 3 + (int)(level * (level + 3) * (1.05f / 12f));
        maxDamage = 7 + (int)(level * (level + 3) * (1.25f / 10f));
        minSpeed = minSpeed + 0.5f;
        maxSpeed = maxSpeed + 1.5f;
        exp = 1 + (int)((level * (level + 1) * 1f + ((maxDamage + hp) / 1.66f)) / 4.33f);
    }

    void SetStatsForStrong()
    {
        transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
        hp = 15 + (int)(level * (level + 3) * (2.45f / 1.9f));
        sp = 5 + (int)(level * (level + 3) * (1.85f / 2f));
        minDamage = 8 + (int)(level * (level + 3) * (1.25f / 12f));
        maxDamage = 13 + (int)(level * (level + 3) * (1.45f / 10f));
        exp = 1 + (int)((level * (level + 1) * 1f + ((maxDamage + hp) / 1.66f)) / 4.33f);
    }

    void SetStatsForElite()
    {
        transform.localScale = new Vector3(4.5f, 4.5f, 4.5f);
        hp = 20 + (int)(level * (level + 6) * (2.55f / 1.9f));
        sp = 10 + (int)(level * (level + 6) * (1.95f / 2f));
        minDamage = 8 + (int)(level * (level + 6) * (1.45f / 12f));
        maxDamage = 13 + (int)(level * (level + 6) * (1.85f / 10f));
        exp = 1 + (int)((level * (level + 1) * 1f + ((maxDamage + hp) / 1.66f)) / 4.33f);
    }


    Damage.DamageType notChangedelement;
    public static byte mod = 0;

    private Color32 mob_Fire = new Color32(255,mod, mod, 255);
    private Color32 mob_Water = new Color32(mod, mod, 255, 255);
    private Color32 mob_Thunder = new Color32(128, 255, mod, 255);
    private Color32 mob_Ice = new Color32(mod, 255, 255, 255);
    private Color32 mob_Wind = new Color32(mod, 255, 128, 255);
    private Color32 mob_Earth = new Color32(255, 128, mod, 255);
    private Color32 mob_Poison = new Color32(mod, 153, mod, 255);
    private Color32 mob_Light = new Color32(255,255, mod, 255);
    private Color32 mob_Dark = new Color32(114, mod, 114, 255);
    private Color32 mob_Aether = new Color32(255, mod, 127, 255);
    private Color32 mob_Soul = new Color32(0,0,0,255);

    public void GetMobSound()
    {
        aS.volume = 0.1f;
        aS.pitch = Random.Range(1.7f, 1.9f);
        aS.PlayOneShot(sM.GetMonsterClip(0));
    }

    public void SetMobColor(Damage.DamageType element)
    {
        if (element == Damage.DamageType.Fire)
        {
            GetComponent<SpriteRenderer>().color = mob_Fire;
        }
        else if (element == Damage.DamageType.Water)
        {
            GetComponent<SpriteRenderer>().color = mob_Water;
        }
        else if (element == Damage.DamageType.Thunder)
        {
            GetComponent<SpriteRenderer>().color = mob_Thunder;
        }
        else if (element == Damage.DamageType.Ice)
        {
            GetComponent<SpriteRenderer>().color = mob_Ice;
        }
        else if (element == Damage.DamageType.Wind)
        {
            GetComponent<SpriteRenderer>().color = mob_Wind;
        }
        else if (element == Damage.DamageType.Earth)
        {
            GetComponent<SpriteRenderer>().color = mob_Earth;
        }
        else if (element == Damage.DamageType.Light)
        {
            GetComponent<SpriteRenderer>().color = mob_Light;
        }
        else if (element == Damage.DamageType.Poison)
        {
            GetComponent<SpriteRenderer>().color = mob_Poison;
        }
        else if (element == Damage.DamageType.Dark)
        {
            GetComponent<SpriteRenderer>().color = mob_Dark;
        }
        else if (element == Damage.DamageType.Aether)
        {
            GetComponent<SpriteRenderer>().color = mob_Aether;
        }
        else if (element == Damage.DamageType.Soul)
        {
            GetComponent<SpriteRenderer>().color = mob_Soul;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
        notChangedelement = mobElement;
    }

    public void TakeDamage(Damage d,int damage)
    {
        if(cbp > 0)     // If there is a barrier attack barrier first; take damage to hp
        {
            if(cbp > damage)
            {
                cbp = cbp - damage;
                damage = 0;
            }
            else if( damage > cbp)
            {
                damage = damage - cbp;
            }
        }

        if(cbp <= 0 && chp > 0 && damage > 0) // If there is no barrier, has more than 0 current hp, and there is damage to deal; take damage to hp
        {
            chp = chp - damage;
        }

        if (DamageTextManager.IsOkToCreate())
        {
            var dui = GameObject.FindGameObjectWithTag("DamageText");
            GameObject dtui = Instantiate(dui, dui.transform.parent.parent) as GameObject;
            Vector2 cam = Camera.main.WorldToScreenPoint(transform.position);
            dtui.transform.position = cam;
            dtui.AddComponent<DamageText_UI>().SetDamage(d, damage);
        }

        CheckVitals();
        KnockBack();
    }

    public void TakeDamageOT(Damage_OT dot, int damage)
    {
        if (cbp > 0)     // If there is a barrier attack barrier first; take damage to hp
        {
            if (cbp > damage)
            {
                cbp = cbp - damage;
                damage = 0;
            }
            else if (damage > cbp)
            {
                damage = damage - cbp;
            }
        }

        if (cbp <= 0 && chp > 0 && damage > 0) // If there is no barrier, has more than 0 current hp, and there is damage to deal; take damage to hp
        {
            chp = chp - damage;
        }

        var dui = GameObject.FindGameObjectWithTag("DamageText");
        GameObject dtui = Instantiate(dui, dui.transform.parent.parent) as GameObject;
        Vector2 cam = Camera.main.WorldToScreenPoint(transform.position);
        dtui.transform.position = cam;
        dtui.AddComponent<DamageText_UI>().SetDamage(dot, damage);
        CheckVitals();
    }

    public void KnockBack()
    {
        //Debug.Log("Velocity Before Hit : " + GetComponent<Rigidbody2D>().velocity);
        //Debug.Log("Velocity Magnitude Before Hit : " + GetComponent<Rigidbody2D>().velocity.magnitude);
        //Debug.Log("Velocity SQR-Magnitude Before Hit : " + GetComponent<Rigidbody2D>().velocity.sqrMagnitude);
        var p = player.transform.position;
        var m = transform.position;
        float mag = 5f;
        var vx = Mathf.Abs(m.x - p.x) * mag;
        var vy = Mathf.Abs(m.y - p.y) * mag;

        //GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        if (m.x <= p.x && m.y >= p.y)         // If player is to the bottom right
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(-vx, vy); // Shoot op direction
        }
        else if (m.x >= p.x && m.y >= p.y)    // if player is to the bottom left
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(vx, vy);  // Shoot op direction
        }
        else if (m.x <= p.x && m.y <= p.y)    // if player is to the top right
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(-vx, -vy); // Shoot op direction
        }
        else if (m.x >= p.x && m.y <= p.y)    // if player is to the top right
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(vx, -vy); // Shoot op direction
        }
        //Debug.Log("Velocity After Hit : " + GetComponent<Rigidbody2D>().velocity);
        //Debug.Log("Velocity Magnitude After Hit : " + GetComponent<Rigidbody2D>().velocity.magnitude);
        //Debug.Log("Velocity SQR-Magnitude After Hit : " + GetComponent<Rigidbody2D>().velocity.sqrMagnitude);
    }

    public void CheckVitals()
    {

        if (chp > hp)   // If current hp is greater than hp; set current to max
        {
            chp = hp;
        }
        if (csp > sp)   // If current sp is greater than sp; set current to max
        {
            csp = sp;
        }
        if (cbp > bp)   // If current bp is greater than bp; set current to max
        {
            cbp = bp;
        }
        float mod = (chp / (float)hp);
        if(mod < 0)
        {
            mod = 0f;
        }
        hp_Bar.localScale = new Vector3(mod, 1f, 1f);
        if (chp <= 0)    // If the current health has dropped to zero or below, kill yourself
        {
            KillYourSelf();
        }
    }

    public void KillYourSelf()
    {
        if (!dying)
        {
            var sM = GameObject.Find("SoundManager").GetComponent<SoundManager>();
            AudioSource.PlayClipAtPoint(sM.GetMonsterClip(0), transform.position);
            GameObject.Find("Player").GetComponent<Player_Main>().pS.AddExperience(exp);
            GetComponent<Collider2D>().enabled = false;
            dying = true;
        }
        //Loot_Table.DropLoot()
        animator.speed = 0;
        
        var c = GetComponent<SpriteRenderer>().color;
        c.r = 1f;
        c.g = 0f;
        c.b = 0f;

        if (c.a >= 0f)
        {
            c.a -= Time.deltaTime;
            GetComponent<SpriteRenderer>().color = c;
        }
        else
        {
            StopCoroutine("FollowPath");
            Destroy(gameObject);
        }
    }

    public void CheckMovement()
    {
        if (flying)
        {
            FlyToPlayer();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Period))
            {
                WalkToPlayer();  
            }
        }
    }

    public Transform playerTarget;
    float speed;
    Vector3[] path;
    int targetIndex;
    float refindTime = 0f;

    public void WalkToPlayer()
    {
        if (refindTime <= 0)
        {
            targetIndex = 0;
            path = new Vector3[0];
            StopCoroutine("FollowPath");
            PathRequestManager.RequestPath(transform.position, playerTarget.position, OnPathFound);
        }
        else
        {
            refindTime -= Time.deltaTime;
        }
    }

    public void OnPathFound(Vector3[] newPath,bool pathSuccessful)
    {
        if (pathSuccessful)
        {
            path = newPath;
            StartCoroutine("FollowPath");
            refindTime = Random.Range(0.1f, 0.4f);
        }
    }

    IEnumerator FollowPath()
    {if (path.Length <= 0)
        {
            yield break;
        }
        Vector3 currentWaypoint = path[0];
        if (targetIndex >= path.Length)
        {
            targetIndex = 0;
            path = new Vector3[0];
            yield break;
        }
        
        while (true)
        {
            if(Vector3.Distance(transform.position, currentWaypoint) < 0.1f)
            {
                targetIndex++;
                if(targetIndex >= path.Length)
                {
                    yield break;
                }
                currentWaypoint = path[targetIndex];
                
            }
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, speed * Time.deltaTime);
            yield return null;
        }
    }

    public void FlyToPlayer()
    {
        var m = transform.position;
        //var t = GetComponent<AI_Movement>().activeNode.transform.position;
        var t = player.transform.position;
        var s = GetComponent<AI_Movement>().speed;
        var sSqr = s * s;
        float mag = 0.01f * s;
        var vx = Mathf.Abs(m.x - t.x);
        var vy = Mathf.Abs(m.y - t.y);
        //var v = GetComponent<Rigidbody2D>().velocity;

        if (m.x <= t.x && m.y >= t.y)         // If node is to the bottom right
        {
            GetComponent<Rigidbody2D>().velocity += new Vector2(mag * vx, -mag * vy);
        }
        else if (m.x >= t.x && m.y >= t.y)    // if node is to the bottom left
        {
            GetComponent<Rigidbody2D>().velocity += new Vector2(-mag * vx, -mag * vy);
        }
        else if (m.x <= t.x && m.y <= t.y)    // if node is to the top right
        {
            GetComponent<Rigidbody2D>().velocity += new Vector2(mag * vx, mag * vy);
        }
        else if (m.x >= t.x && m.y <= t.y)    // if node is to the top right
        {
            GetComponent<Rigidbody2D>().velocity += new Vector2(-mag * vx, mag * vy);
        }

        if (GetComponent<Rigidbody2D>().velocity.x > s)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(s, GetComponent<Rigidbody2D>().velocity.y);
        }
        if (GetComponent<Rigidbody2D>().velocity.y > s)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, s);
        }
        if (GetComponent<Rigidbody2D>().velocity.x < -s)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-s, GetComponent<Rigidbody2D>().velocity.y);
        }
        if (GetComponent<Rigidbody2D>().velocity.y < -s)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -s);
        }

        if ((vx + vy) / 2 > aggroRange)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    public void FixedUpdate()
    { 
        if (hp > 0)
        {
            CheckMovement();
        }
        if (mobElement != notChangedelement)
        {
            SetMobColor(mobElement);
        }
        CheckVitals();
    }

    public void OnDrawGizmos()
    {
        if(path != null)
        {
            for(int i = targetIndex; i < path.Length; i++)
            {
                Gizmos.color = Color.black;
                Gizmos.DrawCube(path[i], new Vector3(0.1f,0.1f,0.1f)); 
                if(i == targetIndex)
                {
                    Gizmos.DrawLine(transform.position, path[i]);
                }
                else
                {
                    Gizmos.DrawLine(path[i-1],path[i]);
                }
            }
        }
    }

}
