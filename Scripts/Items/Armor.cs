using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Item {

    // Items armor

    // Armor Starting values for type of armor
    int l = 1;
    int m = 2;
    int h = 3;
    int s = 4;

    // Armor modifiers
    float l_armor_mod = 0.66f;
    float m_armor_mod = 1f;
    float h_armor_mod = 1.33f;
    float s_armor_mod = 1.66f;

    /// Main Armor Formula
    /// armor = (int) Range((startValue + (item_lvl * mod)) , ((startValue - 1) + (3 * (item_lvl / 2)) + (lvl * mod))

    /// Light Armor Modifier Formula   Min-Max                       Light Armor  :  Results
    // (int)    (1  +   (1  * 0.66)    <->    ((0) + (3*(1/2))   +   (1 * 0.66)  )  :  Level 01 = (1-2)
    // (int)    (1  +   (10 * 0.66)    <->    ((0) + (3*(10/2))  +   (10 * 0.66) )  :  Level 10 = [7-21]
    // (int)    (1  +   (60 * 0.66)    <->    ((0) + (3*(60/2))  +   (60 * 0.66) )  :  Level 60 = {40-129}

    /// Medium Armor Modifier Formula                                 Medium Armor  :  Results
    // (int)    (2  +   (1  * 1.00)    <->    ((1) + (3*(1/2))   +   (1 * 1.00)  )  :  Level 01 = (3-3)
    // (int)    (2  +   (10 * 1.00)    <->    ((1) + (3*(10/2))  +   (10 * 1.00) )  :  Level 10 = [11-25]
    // (int)    (2  +   (60 * 1.00)    <->    ((1) + (3*(60/2))  +   (60 * 1.00) )  :  Level 60 = {61-150}

    /// Heavy Armor Modifier Formula                                   Heavy Armor  :  Results
    // (int)    (3  +   (1  * 1.33)    <->    ((2) + (3*(1/2))   +   (1 *  1.33) )  :  Level 01 = (4-4)
    // (int)    (3  +   (10 * 1.33)    <->    ((2) + (3*(10/2))  +   (10 * 1.33) )  :  Level 10 = [16-30]
    // (int)    (3  +   (60 * 1.33)    <->    ((2) + (3*(60/2))  +   (60 * 1.33) )  :  Level 60 = {82-171}


    // Initialize Armor : Passing in the armor database from item database, and the item itself
    public void InitializeArmor(Item_Database.Armor_Database armor, Item i)
    {
        int a_num = (int)armor;
        SetArmor(a_num, i);
    }

    // Sets the weapon with the weapons id and applies it to the item
    public void SetArmor(int a, Item i)
    {
        if (a >= 301 && a < 312)
        {
            if (i.slotType == Item_Slot.SlotType.Head)
            {
                // Light Helmet
                i.SetName("Light niipll");
                i.itemDesc = "Test desc for light helmet.";
                i.SetItemId(a);
                i.itemValue = 0.35f;
                i.armor = (int)Random.Range(l + (i.itemLevel * l_armor_mod), ((l - 1) + (3 * (i.itemLevel / 2)) + (i.itemLevel * l_armor_mod + 1)));
            }
            else if (i.slotType == Item_Slot.SlotType.Chest)
            {
                // Light Chest
                i.SetName("Light Chest");
                i.itemDesc = "Test desc for light Chest.";
                i.SetItemId(a);
                i.itemValue = 0.45f;
                i.armor = (int)Random.Range(l + (i.itemLevel * l_armor_mod), ((l - 1) + (3 * (i.itemLevel / 2)) + (i.itemLevel * l_armor_mod + 2)));
            }
            else if (i.slotType == Item_Slot.SlotType.Boots)
            {
                // Light Boots
                i.SetName("Light Boots");
                i.itemDesc = "Test desc for light Boots.";
                i.SetItemId(a);
                i.itemValue = 0.25f;
                i.armor = (int)Random.Range(l + (i.itemLevel * l_armor_mod), ((l - 1) + (3 * (i.itemLevel / 2)) + (i.itemLevel * l_armor_mod)));
            }
        }
        else if (a >= 313 && a < 325)
        {
            if (i.slotType == Item_Slot.SlotType.Head)
            {
                // Medium Helmet
                i.SetName("Medium Helmet");
                i.itemDesc = "Test desc for Medium helmet.";
                i.SetItemId(a);
                i.itemValue = 0.35f;
                i.armor = (int)Random.Range(m + (i.itemLevel * m_armor_mod), ((m - 1) + (3 * (i.itemLevel / 2)) + (i.itemLevel * m_armor_mod + 1)));
            }
            else if (i.slotType == Item_Slot.SlotType.Chest)
            {
                // Medium Chest
                i.SetName("Medium Chest");
                i.itemDesc = "Test desc for Medium Chest.";
                i.SetItemId(a);
                i.itemValue = 0.45f;
                i.armor = (int)Random.Range(m + (i.itemLevel * m_armor_mod), ((m - 1) + (3 * (i.itemLevel / 2)) + (i.itemLevel * m_armor_mod + 2)));
            }
            else if (i.slotType == Item_Slot.SlotType.Boots)
            {
                // Medium Boots
                i.SetName("Medium Boots");
                i.itemDesc = "Test desc for light Boots.";
                i.SetItemId(a);
                i.itemValue = 0.25f;
                i.armor = (int)Random.Range(m + (i.itemLevel * m_armor_mod), ((m - 1) + (3 * (i.itemLevel / 2)) + (i.itemLevel * m_armor_mod)));
            }
        }
        else if (a >= 325 && a < 348)
        {
            if (i.slotType == Item_Slot.SlotType.Head)
            {
                // Heavy Helmet
                i.SetName("Heavy Helmet");
                i.itemDesc = "Test desc for Heavy helmet.";
                i.SetItemId(a);
                i.itemValue = 0.35f;
                i.armor = (int)Random.Range(h + (i.itemLevel * h_armor_mod), ((h - 1) + (3 * (i.itemLevel / 2)) + (i.itemLevel * h_armor_mod + 1)));
            }
            else if (i.slotType == Item_Slot.SlotType.Chest)
            {
                // Heavy Chest
                i.SetName("Heavy Chest");
                i.itemDesc = "Test desc for Heavy Chest.";
                i.SetItemId(a);
                i.itemValue = 0.45f;
                i.armor = (int)Random.Range(h + (i.itemLevel * h_armor_mod), ((h - 1) + (3 * (i.itemLevel / 2)) + (i.itemLevel * h_armor_mod + 2)));
            }
            else if (i.slotType == Item_Slot.SlotType.Boots)
            {
                // Heavy Boots
                i.SetName("Heavy Boots");
                i.itemDesc = "Test desc for Heavy Boots.";
                i.SetItemId(a);
                i.itemValue = 0.25f;
                i.armor = (int)Random.Range(h + (i.itemLevel * h_armor_mod), ((h - 1) + (3 * (i.itemLevel / 2)) + (i.itemLevel * h_armor_mod)));
            }
        }
        else if (a >= 349 && a < 381)
        {
            // Shield
            i.slotType = Item_Slot.SlotType.Shield;
            i.SetName("Shield");
            i.itemDesc = "Test desc for shield.";
            i.SetItemId(a);
            i.itemValue = 0.35f;
            i.armor = (int)Random.Range(s + (i.itemLevel * s_armor_mod), ((s - 1) + (3 * (i.itemLevel / 2)) + (i.itemLevel * s_armor_mod + 1)));
        }
        else if (a >= 381 && a < 395)
        {
            // Gloves
            i.slotType = Item_Slot.SlotType.Gloves;
            i.SetName("Gloves");
            i.itemDesc = "Test desc for gloves.";
            i.SetItemId(a);
            i.itemValue = 0.35f;
            i.armor = (int)Random.Range(l + (i.itemLevel * l_armor_mod), ((l - 1) + (3 * (i.itemLevel / 2)) + (i.itemLevel * l_armor_mod + 1)));

        }

    }

}
