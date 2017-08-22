using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Display_UI : MonoBehaviour {



    public GameObject[] itemUiObjects;
    public static Item itemToBeDisplayed;
    public static bool testRun = false;
    public UnityEngine.UI.Text[] txts;

    Color32 poor = new Color32(98, 98, 98, 255);
    Color32 basic = new Color32(78, 44, 0, 255);
    Color32 fine = new Color32(18, 78, 0, 255);
    Color32 great = new Color32(0, 78, 78, 255);
    Color32 masterful = new Color32(0, 29, 78, 255);
    Color32 epic = new Color32(78, 0, 69, 255);
    Color32 legendary = new Color32(88, 89, 0, 255);
    Color32 godlike = new Color32(98, 0, 0, 255);

    Color32 poorb = new Color32(198, 198, 198, 255);
    Color32 basicb = new Color32(178, 144, 0, 255);
    Color32 fineb = new Color32(118, 178, 0, 255);
    Color32 greatb = new Color32(0, 178, 178, 255);
    Color32 masterfulb = new Color32(0, 129, 178, 255);
    Color32 epicb = new Color32(178, 0, 169, 255);
    Color32 legendaryb = new Color32(188, 189, 0, 255);
    Color32 godlikeb = new Color32(198, 0, 0, 255);

    Color32[] colors = new Color32[16];

    public void Start()
    {
        colors[0] = poor;
        colors[1] = poorb;
        colors[2] = basic;
        colors[3] = basicb;
        colors[4] = fine;
        colors[5] = fineb;
        colors[6] = great;
        colors[7] = greatb;
        colors[8] = masterful;
        colors[9] = masterfulb;
        colors[10] = epic;
        colors[11] = epicb;
        colors[12] = legendary;
        colors[13] = legendaryb;
        colors[14] = godlike;
        colors[15] = godlikeb;
    }

    public void SetDisplay(Item i)
    {

        itemToBeDisplayed = i;
        if (i != null)
        {
            SetColor(i.itemQuality);
            SetTitle(i.itemName);
            SetDesc(i.itemDesc);
            SetIcon(i.icon);
            SetValue(i.itemValue);
            SetStatText(i.GetStats());
            SetLevel(i.itemLevel);
        }
    }

    public void Update()
    {
        if (Input.GetMouseButton(1))
        {
        }
        else
        {
            Hide();
        }
    }

    public void Show()
    {
        var ims = itemUiObjects[9].GetComponentsInChildren<UnityEngine.UI.Image>();
        foreach (UnityEngine.UI.Image i in ims)
        {
            if (i != null)
            {
                i.enabled = true;
            }
        }
        var txs = itemUiObjects[9].GetComponentsInChildren<UnityEngine.UI.Text>();
        foreach (UnityEngine.UI.Text t in txs)
        {
            if (t != null)
            {
                t.enabled = true;
            }
        }
    }
    public void Hide()
    {
        var ims = itemUiObjects[9].GetComponentsInChildren<UnityEngine.UI.Image>();
        foreach (UnityEngine.UI.Image i in ims)
        {
            if (i != null)
            {
                i.enabled = false;
            }
        }
        var txs = itemUiObjects[9].GetComponentsInChildren<UnityEngine.UI.Text>();
        foreach (UnityEngine.UI.Text t in txs)
        {
            if (t != null)
            {
                t.enabled = false;
            }
        }
    }

    public void SetIcon(Sprite s)
    {
        itemUiObjects[1].GetComponent<UnityEngine.UI.Image>().sprite = s;
    }
    public void SetTitle(string s)
    {
        itemUiObjects[2].GetComponent<UnityEngine.UI.Text>().text = s;
    }
    public void SetDesc(string d)
    {
        itemUiObjects[3].GetComponent<UnityEngine.UI.Text>().text = d;
    }

    public void UIColor(int i)
    {
        itemUiObjects[0].GetComponent<UnityEngine.UI.Image>().color = colors[i];
        itemUiObjects[5].GetComponent<UnityEngine.UI.Image>().color = colors[i];
        itemUiObjects[6].GetComponent<UnityEngine.UI.Image>().color = colors[i];
        itemUiObjects[4].GetComponent<UnityEngine.UI.Image>().color = colors[i + 1];
        itemUiObjects[8].GetComponent<UnityEngine.UI.Image>().color = colors[i + 1];
    }

    public void SetValue(float value)
    {
        //itemUiObjects[7].GetComponent<UnityEngine.UI.Text>().text = "Value : $" + value.ToString("0.00");
        int[] c = Currency.ConvertValueToCredits(value * 100);
        string s = Currency.ConvertCreditsToText(c);
        itemUiObjects[7].GetComponent<UnityEngine.UI.Text>().text = s;

    }

    public void ClearStatTexts()
    {
        foreach(UnityEngine.UI.Text t in txts)
        {
            t.text = "";
        }
    }

    public void SetLevel(int ilvl)
    {
        txts[9].text = "Level : " + ilvl.ToString();
    }

    public void SetStatText(List<string> stats)
    {
        ClearStatTexts();

        for (int i = 0; i < stats.Count; i++)
        {
            if (stats[i] != null)
            {
                if (stats[i] != "")
                {
                    txts[i].text = stats[i];
                }
                else
                {
                    continue;
                }
            }
        }
    }

    public void SetColor(Item.ItemQualityModifiers quality)
    {
        if (quality == Item.ItemQualityModifiers.Poor)
        {
            UIColor(0);
        }
        else if (quality == Item.ItemQualityModifiers.Basic)
        {
            UIColor(2);
        }
        else if (quality == Item.ItemQualityModifiers.Fine)
        {
            UIColor(4);
        }
        else if (quality == Item.ItemQualityModifiers.Great)
        {
            UIColor(6);
        }
        else if (quality == Item.ItemQualityModifiers.Masterful)
        {
            UIColor(8);
        }
        else if (quality == Item.ItemQualityModifiers.Epic)
        {
            UIColor(10);
        }
        else if (quality == Item.ItemQualityModifiers.Legendary)
        {
            UIColor(12);
        }
        else if (quality == Item.ItemQualityModifiers.Godlike)
        {
            UIColor(14);
        }
    }
}