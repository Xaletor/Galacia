using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item {

    
    // Initialize Weapon : Passing in the weapons database from item database, and the item itself
    public void InitializeWeapon(Item_Database.Weapons_Database weapon, Item i)
    {
        int w_num = (int)weapon;
        SetWeapon(w_num,i);
    }

    // Sets the weapon with the weapons id and applies it to the item
    public void SetWeapon(int w, Item i)
    {
        if (w >= 101 && w < 109)
        {
            w = Random.Range(101, 110);
            // 1 - 5 (lvl / 5) dmg
            i.SetName("Sword");
            i.itemDesc = "Test desc for sword.";
            i.SetItemId(w);
            i.itemValue = 0.50f;
            i.minDamage = Random.Range(1 + (int)(i.itemLevel * 0.15f), 3 + (int)(i.itemLevel * 0.15f));
            i.maxDamage = Random.Range(3 + (int)(i.itemLevel * 0.35f), (int)(6 + (itemLevel / 5f) + (int)(i.itemLevel * 0.35f)));
            i.slotType = Item_Slot.SlotType.Weapon;
        }

        else if (w >= 110 && w < 118)
        {
            w = Random.Range(110, 119);
            // 1 - 5 (lvl / 5) dmg
            i.SetName("Two-Handed Sword");
            i.itemDesc = "Test desc for 2H - sword.";
            i.SetItemId(w);
            i.itemValue = 0.50f;
            i.minDamage = Random.Range(1 + (int)(i.itemLevel * 0.15f), 3 + (int)(i.itemLevel * 0.15f));
            i.maxDamage = Random.Range(3 + (int)(i.itemLevel * 0.35f), (int)(6 + (itemLevel / 5f) + (int)(i.itemLevel * 0.35f)));
            i.slotType = Item_Slot.SlotType.Weapon;
        }

        else if (w >= 119 && w < 127)
        {
            w = Random.Range(119, 128);
            // 1 - 5 (lvl / 5) dmg
            i.SetName("Dagger");
            i.itemDesc = "Test desc for dagger.";
            i.SetItemId(w);
            i.itemValue = 0.50f;
            i.minDamage = Random.Range(1 + (int)(i.itemLevel * 0.15f), 3 + (int)(i.itemLevel * 0.15f));
            i.maxDamage = Random.Range(3 + (int)(i.itemLevel * 0.35f), (int)(6 + (itemLevel / 5f) + (int)(i.itemLevel * 0.35f)));
            i.slotType = Item_Slot.SlotType.Weapon;
        }

        else if (w >= 128 && w < 136)
        {
            w = Random.Range(128, 137);
            // 1 - 5 (lvl / 5) dmg
            i.SetName("Mace");
            i.itemDesc = "Test desc for mace.";
            i.SetItemId(w);
            i.itemValue = 0.50f;
            i.minDamage = Random.Range(1 + (int)(i.itemLevel * 0.15f), 3 + (int)(i.itemLevel * 0.15f));
            i.maxDamage = Random.Range(3 + (int)(i.itemLevel * 0.35f), (int)(6 + (itemLevel / 5f) + (int)(i.itemLevel * 0.35f)));
            i.slotType = Item_Slot.SlotType.Weapon;
        }
        else if (w >= 137 && w < 144)
        {
            w = Random.Range(137, 145);
            // 1 - 5 (lvl / 5) dmg
            i.SetName("Hammer");
            i.itemDesc = "Test desc for hammer.";
            i.SetItemId(w);
            i.itemValue = 0.50f;
            i.minDamage = Random.Range(1 + (int)(i.itemLevel * 0.15f), 3 + (int)(i.itemLevel * 0.15f));
            i.maxDamage = Random.Range(3 + (int)(i.itemLevel * 0.35f), (int)(6 + (itemLevel / 5f) + (int)(i.itemLevel * 0.35f)));
            i.slotType = Item_Slot.SlotType.Weapon;
        }
        else if (w >= 145 && w < 152)
        {
            w = Random.Range(145, 153);
            // 1 - 5 (lvl / 5) dmg
            i.SetName("Axe");
            i.itemDesc = "Test desc for axe.";
            i.SetItemId(w);
            i.itemValue = 0.50f;
            i.minDamage = Random.Range(1 + (int)(i.itemLevel * 0.15f), 3 + (int)(i.itemLevel * 0.15f));
            i.maxDamage = Random.Range(3 + (int)(i.itemLevel * 0.35f), (int)(6 + (itemLevel / 5f) + (int)(i.itemLevel * 0.35f)));
            i.slotType = Item_Slot.SlotType.Weapon;
        }
        else if (w >= 153 && w < 158)
        {
            w = Random.Range(153, 159);
            // 1 - 5 (lvl / 5) dmg
            i.SetName("Spear");
            i.itemDesc = "Test desc for spear.";
            i.SetItemId(w);
            i.itemValue = 0.50f;
            i.minDamage = Random.Range(1 + (int)(i.itemLevel * 0.15f), 3 + (int)(i.itemLevel * 0.15f));
            i.maxDamage = Random.Range(3 + (int)(i.itemLevel * 0.35f), (int)(6 + (itemLevel / 5f) + (int)(i.itemLevel * 0.35f)));
            i.slotType = Item_Slot.SlotType.Weapon;
        }
        else if (w >= 159 && w < 166)
        {
            w = Random.Range(159, 167);
            // 1 - 5 (lvl / 5) dmg
            i.SetName("Staff");
            i.itemDesc = "Test desc for staff.";
            i.SetItemId(w);
            i.itemValue = 0.50f;
            i.minDamage = Random.Range(1 + (int)(i.itemLevel * 0.15f), 3 + (int)(i.itemLevel * 0.15f));
            i.maxDamage = Random.Range(3 + (int)(i.itemLevel * 0.35f), (int)(6 + (itemLevel / 5f) + (int)(i.itemLevel * 0.35f)));
            i.slotType = Item_Slot.SlotType.Weapon;
        }
        else if (w >= 167 && w < 170)
        {
            w = Random.Range(167, 171);
            // 1 - 5 (lvl / 5) dmg
            i.SetName("Fist");
            i.itemDesc = "Test desc for fist.";
            i.SetItemId(w);
            i.itemValue = 0.50f;
            i.minDamage = Random.Range(1 + (int)(i.itemLevel * 0.15f), 3 + (int)(i.itemLevel * 0.15f));
            i.maxDamage = Random.Range(3 + (int)(i.itemLevel * 0.35f), (int)(6 + (itemLevel / 5f) + (int)(i.itemLevel * 0.35f)));
            i.slotType = Item_Slot.SlotType.Weapon;
        }
        else if (w >= 171)
        {
            w = Random.Range(171, 172);
            // 1 - 5 (lvl / 5) dmg
            i.SetName("Bow");
            i.itemDesc = "Test desc for bow.";
            i.SetItemId(w);
            i.itemValue = 0.50f;
            i.minDamage = Random.Range(1 + (int)(i.itemLevel * 0.15f), 3 + (int)(i.itemLevel * 0.15f));
            i.maxDamage = Random.Range(3 + (int)(i.itemLevel * 0.35f), (int)(6 + (itemLevel / 5f) + (int)(i.itemLevel * 0.35f)));
            i.slotType = Item_Slot.SlotType.Weapon;
        }

    }

}
