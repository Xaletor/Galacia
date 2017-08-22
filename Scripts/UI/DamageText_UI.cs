using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageText_UI : MonoBehaviour
{

    public float timeTillDeath = 1f;
    static byte mod = 0;

    private Color32 Fire = new Color32(255, 50, mod, 255);
    private Color32 Mob = new Color32(255, mod, mod, 255);
    private Color32 Blood = new Color32(150, mod, mod, 255);
    private Color32 Water = new Color32(mod, mod, 255, 255);
    private Color32 Thunder = new Color32(128, 255, mod, 255);
    private Color32 Ice = new Color32(mod, 255, 255, 255);
    private Color32 Wind = new Color32(mod, 255, 128, 255);
    private Color32 Earth = new Color32(173, 100, mod, 255);
    private Color32 Poison = new Color32(mod, 153, mod, 255);
    private Color32 Light = new Color32(255, 255, mod, 255);
    private Color32 Dark = new Color32(114, mod, 114, 255);
    private Color32 Aether = new Color32(255, mod, 127, 255);
    private Color32 Soul = new Color32(50, 50, 50, 255);
    private Color32 Normal = new Color32(255, 255, 255, 255);
    public Color32 chaserColor;

    public void Start()
    {
       
        transform.gameObject.AddComponent<Text_Chaser_UI>().InitializeChaser(this, GetComponent<UnityEngine.UI.Text>());
    }

    public void FixedUpdate()
    {
        timeTillDeath -= Time.deltaTime;
        if (timeTillDeath <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void SetDamage(Damage damage, int amount, bool monster = false)
    {
        if (DamageTextManager.IsOkToCreate())
        {
            GetComponent<Rigidbody2D>().simulated = true;
            if (monster)
            {
                GetComponent<UnityEngine.UI.Text>().fontStyle = (damage.isCritical) ? FontStyle.BoldAndItalic : FontStyle.Italic;
            }
            else if (!monster)
            {
                GetComponent<UnityEngine.UI.Text>().fontStyle = (damage.isCritical) ? FontStyle.Bold : FontStyle.Normal;
            }
            GetComponent<UnityEngine.UI.Text>().color = Color.black;
            chaserColor = (!monster) ? SetDamageColor(damage.GetDamageType()) : Mob;
            GetComponent<UnityEngine.UI.Text>().fontSize = (damage.isCritical) ? 5 : 4;
            GetComponent<UnityEngine.UI.Text>().text = amount.ToString();
            GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-200, 200), 200);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetDamage(Damage_OT damage, int amount, bool monster = false)
    {
        if (DamageTextManager.IsOkToCreate())
        {
            GetComponent<Rigidbody2D>().simulated = true;
            if (monster)
            {
                GetComponent<UnityEngine.UI.Text>().fontStyle = FontStyle.Italic;
            }
            else if (!monster)
            {
                GetComponent<UnityEngine.UI.Text>().fontStyle = FontStyle.Normal;
            }
            GetComponent<UnityEngine.UI.Text>().color = Color.black;
            chaserColor = (!monster) ? SetDamageOTColor(damage.GetDamage_OTType()) : Mob;
            GetComponent<UnityEngine.UI.Text>().fontSize = 4;
            GetComponent<UnityEngine.UI.Text>().text = amount.ToString();
            GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-200, 200), 200);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Color32 SetDamageColor(Damage.DamageType dt)
    {
        if (dt == Damage.DamageType.Aether)
        {
            return Aether;
        }
        else if (dt == Damage.DamageType.Dark)
        {
            return Dark;
        }
        else if (dt == Damage.DamageType.Poison)
        {
            return Poison;
        }
        else if (dt == Damage.DamageType.Earth)
        {
            return Earth;
        }
        else if (dt == Damage.DamageType.Fire)
        {
            return Fire;
        }
        else if (dt == Damage.DamageType.Ice)
        {
            return Ice;
        }
        else if (dt == Damage.DamageType.Light)
        {
            return Light;
        }
        else if (dt == Damage.DamageType.Soul)
        {
            return Soul;
        }
        else if (dt == Damage.DamageType.Thunder)
        {
            return Thunder;
        }
        else if (dt == Damage.DamageType.Water)
        {
            return Water;
        }
        else if (dt == Damage.DamageType.Wind)
        {
            return Wind;
        }
        else
        {
            return Normal;
        }

    }

    public Color32 SetDamageOTColor(Damage_OT.Damage_OTType dt)
    {
        if (dt == Damage_OT.Damage_OTType.Bleeding)
        {
            return Blood;
        }
        else if (dt == Damage_OT.Damage_OTType.Fire)
        {
            return Fire;
        }
        else if (dt == Damage_OT.Damage_OTType.Poison)
        {
            return Poison;
        }
        else
        {
            return Normal;
        }
    }
}
