using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Main : MonoBehaviour {

    public Player_Stats pS;
    public Player_Inventory pI;
    public Player_Equipped pE;
    public Player_Movement pM;

    public RuntimeAnimatorController[] gender;
    int genderIndex = 0;

    //Collider2D movC;
    public Collider2D atkT;
    //public Collider2D hitT;

    public static bool isReady;
    public bool invulnerable = false;
    int spellCastIndex = 0;
    int testMagicLevel = 1;
    public GameObject magicCircle;
    float invulTime = 0f;
    float testMagicCooldown = 0.5f;
    bool testReady = false;
    void Awake()
    {
        pS = GetComponent<Player_Stats>();
        pI = GetComponent<Player_Inventory>();
        pE = GetComponent<Player_Equipped>();
        pM = GetComponent<Player_Movement>();
        //movC = GetComponent<Collider2D>();
    }

    public void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            var ani = GetComponent<Animator>();
            if(genderIndex == 0)
            {
                genderIndex = 1;
            }
            else if(genderIndex == 1)
            {
                genderIndex = 0;
            }
            ani.runtimeAnimatorController = gender[genderIndex];
        }
        if (invulnerable)
        {
            invulTime -= Time.deltaTime;
            if(invulTime <= 0)
            {
                invulnerable = false;
            }
        }
        // TestMagicCast
        TestMagicCast();
    }
    ///TEST
    ///

    public void ModifySpellIndex(int i)
    {
        int min = 0;
        int max = 3;

        spellCastIndex += i;

        if (spellCastIndex < 0)
        {
            spellCastIndex = max;
        }
        if(spellCastIndex > max)
        {
            spellCastIndex = min;
        }
    }

    public void TestMagicCast()
    {
        if (Input.GetKeyDown(KeyCode.LeftBracket))
        {
            ModifySpellIndex(-1);
        }
        if (Input.GetKeyDown(KeyCode.RightBracket))
        {
            ModifySpellIndex(1);
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            testMagicLevel++;
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            testMagicLevel += 5000;
        }
        testMagicCooldown -= Time.deltaTime;
        if (Input.GetMouseButton(1) && !Inventory_Display_UI.isOpen && !pM.attacking)
        {
           if(testMagicCooldown <= 0)
            {            
                StartCoroutine(CastMagic());
            }  
        }
    }

    Magic GetTestMagic()
    {
        Magic m = null;
        int mod = 0;

        if (spellCastIndex == 0)
        {
            m = new Magic(Magic_Database.Magic_Type.Fire, mod + 1);
        }
        if (spellCastIndex == 1)
        {
            m = new Magic(Magic_Database.Magic_Type.Aether, mod + 1);
        }
        if (spellCastIndex == 2)
        {
            m = new Magic(Magic_Database.Magic_Type.Poison, mod + 1);
        }
        if (spellCastIndex == 3)
        {
            m = new Magic(Magic_Database.Magic_Type.Poison, mod + 2);
        }

        return m;
    }

    public IEnumerator CastMagic()
    {
        
        Magic m = GetTestMagic();
        int mod = (spellCastIndex == 3)?1:0;

        m.SetMagicDamage(pS.intellect);
        m.SetMagicSkillLevel(testMagicLevel);
        if ((pS.currentSP - m.manaCost) > 0)
        {
            pS.currentSP -= m.manaCost;
            testMagicCooldown = 0.6f;
            GameObject m_circle = Instantiate(magicCircle, transform) as GameObject;
            var ps = m_circle.GetComponent<ParticleSystem>();
            var main = ps.main;
            main.startColor = m.circleColor;
            AudioSource.PlayClipAtPoint(m.birth, transform.position);
            yield return new WaitForSeconds(0.5f);    
            AudioSource.PlayClipAtPoint(m.life, transform.position);
            pM.CastAttack();
            var mdb = GameObject.Find("Database_Magic").GetComponent<Magic_Database>();
            GameObject spell = Instantiate(mdb.GetSpellProjectile(m, mod), GameObject.Find("Spells").transform) as GameObject;
            spell.transform.position = transform.position;
            Vector2 tar = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            spell.GetComponent<Magic_Projectile>().InitializeProjectile(m, tar);
        }
    }

    /// END TEST

    public void SetTriggerBoxLocation(Player_Movement.Direction direction)
    {
        if(direction == Player_Movement.Direction.Right)
        {
            atkT.offset = new Vector2(0.2f, 0f);
        }
        else if (direction == Player_Movement.Direction.Left)
        {
            atkT.offset = new Vector2(-0.2f, 0f);
        }
        else if (direction == Player_Movement.Direction.Down)
        {
            atkT.offset = new Vector2(0f, -0.2f);
        }
        else if (direction == Player_Movement.Direction.Up)
        {
            atkT.offset = new Vector2(0f, 0.1f);
        }
    }

    public void TakeDamage(int damage, bool bypass = false)
    {
        if (!invulnerable && !bypass)
        {
            Debug.Log("Player took " + damage + " damage!");
            pS.currentHP -= damage;
            CheckVitals();
            invulnerable = true;
            invulTime = 1f;
        }
        if (bypass)
        {
            Debug.Log("Player took " + damage + " OT damage!");
            pS.currentHP -= damage;
            CheckVitals();
        }
    }

    public void CheckVitals()
    {
        if(pS.currentHP <= 0)
        {
            Debug.Log("Player is Dead!");
        }
    }

    public void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag == "Monster")
        {
            if (isReady && pM.attacking)
            {
                isReady = false;
                Damage damage = new Damage(pS.primaryDamage, pS.minDamage_P, pS.maxDamage_P);
                damage.RunCritDice(0, 100, pS.critChance,(1f + (pS.critDamage/100f)));
                int hit = Damage_Calculator.CalculateElementDamageToMonster(damage, col.GetComponent<Monster>());
                if(pS.primaryOTDamage != Damage_OT.Damage_OTType.Normal)
                {
                    Damage_OT ot = new Damage_OT(pS.primaryOTDamage, (int)(Random.Range(pS.minDamage_P/5f,pS.maxDamage_P/5)), 5f);
                    int othit = Damage_Calculator.CalculateElementDamageOTToMonster(ot, col.GetComponent<Monster>());
                    col.GetComponent<Monster>().TakeDamageOT(ot, othit);
                    GameObject debuff = Instantiate(new GameObject(), col.transform);
                    debuff.AddComponent<De_Buff>().InitializeDeBuff(ot);
                }
                col.GetComponent<Monster>().TakeDamage(damage, hit);
                Debug.Log("Hit For : " + hit);
            }
            if (!pM.attacking)
            {
                isReady = true;
            }
        }
    }


}
