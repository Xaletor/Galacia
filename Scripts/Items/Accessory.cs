using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accessory : Item {
    
    // Initialize Accessory : Passing in the accessory database from item database, and the item itself
    public void InitializeAccessory(Item_Database.Accessory_Database accessory, Item i)
    {
        int ac_num = (int)accessory;
        SetAccessory(ac_num, i);
    }

    // Set Accessory Item
    void SetAccessory(int acc, Item i)
    {
        if(acc == 501)
        {
            i.SetName("Ruby Amulet");
            i.itemDesc = "An amulet made of ruby.";
            i.SetItemId(501);
            i.itemValue = 1.50f;
            i.SetEnchantTypeNum(3);
            i.SetSpecificEnchantTypeNum(4);
            i.slotType = Item_Slot.SlotType.Neck;
        }
        else if (acc == 502)
        {
            i.SetName("Ruby Earring");
            i.itemDesc = "A earring made from ruby.";
            i.SetItemId(502);
            i.itemValue = 1.50f;
            i.SetEnchantTypeNum(3);
            i.SetSpecificEnchantTypeNum(4);
            i.slotType = Item_Slot.SlotType.Earring;
        }
        else if (acc == 503)
        {
            i.SetName("Ruby Ring");
            i.itemDesc = "An ring made of ruby.";
            i.SetItemId(503);
            i.itemValue = 1.50f;
            i.SetEnchantTypeNum(3);
            i.SetSpecificEnchantTypeNum(4);
            i.slotType = Item_Slot.SlotType.Ring;
        }
        else if (acc == 504)
        {
            i.SetName("Sapphire Amulet");
            i.itemDesc = "An amulet made of sapphire.";
            i.SetItemId(504);
            i.itemValue = 1.50f;
            i.SetEnchantTypeNum(3);
            i.SetSpecificEnchantTypeNum(10);
            i.slotType = Item_Slot.SlotType.Neck;
        }
        else if (acc == 505)
        {
            i.SetName("Sapphire Earring");
            i.itemDesc = "A earring made from sapphire.";
            i.SetItemId(505);
            i.itemValue = 1.50f;
            i.SetEnchantTypeNum(3);
            i.SetSpecificEnchantTypeNum(10);
            i.slotType = Item_Slot.SlotType.Earring;
        }
        else if (acc == 506)
        {
            i.SetName("Sapphire Ring");
            i.itemDesc = "An ring made of sapphire.";
            i.SetItemId(506);
            i.itemValue = 1.50f;
            i.SetEnchantTypeNum(3);
            i.SetSpecificEnchantTypeNum(10);
            i.slotType = Item_Slot.SlotType.Ring;
        }
        else if (acc == 507)
        {
            i.SetName("Citrine Amulet");
            i.itemDesc = "An amulet made of citrine.";
            i.SetItemId(507);
            i.itemValue = 1.50f;
            i.SetEnchantTypeNum(3);
            i.SetSpecificEnchantTypeNum(9);
            i.slotType = Item_Slot.SlotType.Neck;
        }
        else if (acc == 508)
        {
            i.SetName("Citrine Earring");
            i.itemDesc = "A earring made from citrine.";
            i.SetItemId(508);
            i.itemValue = 1.50f;
            i.SetEnchantTypeNum(3);
            i.SetSpecificEnchantTypeNum(9);
            i.slotType = Item_Slot.SlotType.Earring;
        }
        else if (acc == 509)
        {
            i.SetName("Citrine Ring");
            i.itemDesc = "An ring made of citrine.";
            i.SetItemId(509);
            i.itemValue = 1.50f;
            i.SetEnchantTypeNum(3);
            i.SetSpecificEnchantTypeNum(9);
            i.slotType = Item_Slot.SlotType.Ring;
        }
        else if (acc == 510)
        {
            i.SetName("Indicolite Amulet");
            i.itemDesc = "An amulet made of indicolite.";
            i.SetItemId(510);
            i.itemValue = 1.50f;
            i.SetEnchantTypeNum(3);
            i.SetSpecificEnchantTypeNum(5);
            i.slotType = Item_Slot.SlotType.Neck;
        }
        else if (acc == 511)
        {
            i.SetName("Indicolite Earring");
            i.itemDesc = "A earring made from indicolite.";
            i.SetItemId(511);
            i.itemValue = 1.50f;
            i.SetEnchantTypeNum(3);
            i.SetSpecificEnchantTypeNum(5);
            i.slotType = Item_Slot.SlotType.Earring;
        }
        else if (acc == 512)
        {
            i.SetName("Indicolite Ring");
            i.itemDesc = "An ring made of indicolite.";
            i.SetItemId(512);
            i.itemValue = 1.50f;
            i.SetEnchantTypeNum(3);
            i.SetSpecificEnchantTypeNum(5);
            i.slotType = Item_Slot.SlotType.Ring;
        }
        else if (acc == 513)
        {
            i.SetName("Peridot Amulet");
            i.itemDesc = "An amulet made of peridot.";
            i.SetItemId(513);
            i.itemValue = 1.50f;
            i.SetEnchantTypeNum(3);
            i.SetSpecificEnchantTypeNum(11);
            i.slotType = Item_Slot.SlotType.Neck;
        }
        else if (acc == 514)
        {
            i.SetName("Peridot Earring");
            i.itemDesc = "A earring made from peridot.";
            i.SetItemId(514);
            i.itemValue = 1.50f;
            i.SetEnchantTypeNum(3);
            i.SetSpecificEnchantTypeNum(11);
            i.slotType = Item_Slot.SlotType.Earring;
        }
        else if (acc == 515)
        {
            i.SetName("Peridot Ring");
            i.itemDesc = "An ring made of peridot.";
            i.SetItemId(515);
            i.itemValue = 1.50f;
            i.SetEnchantTypeNum(3);
            i.SetSpecificEnchantTypeNum(11);
            i.slotType = Item_Slot.SlotType.Ring;
        }
        else if (acc == 516)
        {
            i.SetName("Axinite Amulet");
            i.itemDesc = "An amulet made of axinite.";
            i.SetItemId(516);
            i.itemValue = 1.50f;
            i.SetEnchantTypeNum(3);
            i.SetSpecificEnchantTypeNum(3);
            i.slotType = Item_Slot.SlotType.Neck;
        }
        else if (acc == 517)
        {
            i.SetName("Axinite Earring");
            i.itemDesc = "A earring made from axinite.";
            i.SetItemId(517);
            i.itemValue = 1.50f;
            i.SetEnchantTypeNum(3);
            i.SetSpecificEnchantTypeNum(3);
            i.slotType = Item_Slot.SlotType.Earring;
        }
        else if (acc == 518)
        {
            i.SetName("Axinite Ring");
            i.itemDesc = "An ring made of axinite.";
            i.SetItemId(518);
            i.itemValue = 1.50f;
            i.SetEnchantTypeNum(3);
            i.SetSpecificEnchantTypeNum(3);
            i.slotType = Item_Slot.SlotType.Ring;
        }
        else if (acc == 519)
        {
            i.SetName("Emerald Amulet");
            i.itemDesc = "An amulet made of emerald.";
            i.SetItemId(519);
            i.itemValue = 1.50f;
            i.SetEnchantTypeNum(3);
            i.SetSpecificEnchantTypeNum(7);
            i.slotType = Item_Slot.SlotType.Neck;
        }
        else if (acc == 520)
        {
            i.SetName("Emerald Earring");
            i.itemDesc = "A earring made from emerald.";
            i.SetItemId(520);
            i.itemValue = 1.50f;
            i.SetEnchantTypeNum(3);
            i.SetSpecificEnchantTypeNum(7);
            i.slotType = Item_Slot.SlotType.Earring;
        }
        else if (acc == 521)
        {
            i.SetName("Emerald Ring");
            i.itemDesc = "An ring made of emerald.";
            i.SetItemId(521);
            i.itemValue = 1.50f;
            i.SetEnchantTypeNum(3);
            i.SetSpecificEnchantTypeNum(7);
            i.slotType = Item_Slot.SlotType.Ring;
        }
        else if (acc == 522)
        {
            i.SetName("Garnet Amulet");
            i.itemDesc = "An amulet made of garnet.";
            i.SetItemId(522);
            i.itemValue = 1.50f;
            i.SetEnchantTypeNum(3);
            i.SetSpecificEnchantTypeNum(1);
            i.slotType = Item_Slot.SlotType.Neck;
        }
        else if (acc == 523)
        {
            i.SetName("Garnet Earring");
            i.itemDesc = "A earring made from garnet.";
            i.SetItemId(523);
            i.itemValue = 1.50f;
            i.SetEnchantTypeNum(3);
            i.SetSpecificEnchantTypeNum(1);
            i.slotType = Item_Slot.SlotType.Earring;
        }
        else if (acc == 524)
        {
            i.SetName("Garnet Ring");
            i.itemDesc = "An ring made of garnet.";
            i.SetItemId(524);
            i.itemValue = 1.50f;
            i.SetEnchantTypeNum(3);
            i.SetSpecificEnchantTypeNum(1);
            i.slotType = Item_Slot.SlotType.Ring;
        }
        else if (acc == 525)
        {
            i.SetName("Diamond Amulet");
            i.itemDesc = "An amulet made of diamond.";
            i.SetItemId(525);
            i.itemValue = 1.50f;
            i.SetEnchantTypeNum(3);
            i.SetSpecificEnchantTypeNum(6);
            i.slotType = Item_Slot.SlotType.Neck;
        }
        else if (acc == 526)
        {
            i.SetName("Diamond Earring");
            i.itemDesc = "A earring made from diamond.";
            i.SetItemId(526);
            i.itemValue = 1.50f;
            i.SetEnchantTypeNum(3);
            i.SetSpecificEnchantTypeNum(6);
            i.slotType = Item_Slot.SlotType.Earring;
        }
        else if (acc == 527)
        {
            i.SetName("Diamond Ring");
            i.itemDesc = "An ring made of diamond.";
            i.SetItemId(527);
            i.itemValue = 1.50f;
            i.SetEnchantTypeNum(3);
            i.SetSpecificEnchantTypeNum(6);
            i.slotType = Item_Slot.SlotType.Ring;
        }
        else if (acc == 528)
        {
            i.SetName("Amethyst Amulet");
            i.itemDesc = "An amulet made of amethyst.";
            i.SetItemId(528);
            i.itemValue = 1.50f;
            i.SetEnchantTypeNum(3);
            i.SetSpecificEnchantTypeNum(2);
            i.slotType = Item_Slot.SlotType.Neck;
        }
        else if (acc == 529)
        {
            i.SetName("Amethyst Earring");
            i.itemDesc = "A earring made from amethyst.";
            i.SetItemId(529);
            i.itemValue = 1.50f;
            i.SetEnchantTypeNum(3);
            i.SetSpecificEnchantTypeNum(2);
            i.slotType = Item_Slot.SlotType.Earring;
        }
        else if (acc == 530)
        {
            i.SetName("Amethyst Ring");
            i.itemDesc = "An ring made of amethyst.";
            i.SetItemId(530);
            i.itemValue = 1.50f;
            i.SetEnchantTypeNum(3);
            i.SetSpecificEnchantTypeNum(2);
            i.slotType = Item_Slot.SlotType.Ring;
        }
        else if (acc == 531)
        {
            i.SetName("Spinel Amulet");
            i.itemDesc = "An amulet made of spinel.";
            i.SetItemId(531);
            i.itemValue = 1.50f;
            i.SetEnchantTypeNum(3);
            i.SetSpecificEnchantTypeNum(0);
            i.slotType = Item_Slot.SlotType.Neck;
        }
        else if (acc == 532)
        {
            i.SetName("Spinel Earring");
            i.itemDesc = "A earring made from spinel.";
            i.SetItemId(532);
            i.itemValue = 1.50f;
            i.SetEnchantTypeNum(3);
            i.SetSpecificEnchantTypeNum(0);
            i.slotType = Item_Slot.SlotType.Earring;
        }
        else if (acc == 533)
        {
            i.SetName("Spinel Ring");
            i.itemDesc = "An ring made of spinel.";
            i.SetItemId(533);
            i.itemValue = 1.50f;
            i.SetEnchantTypeNum(3);
            i.SetSpecificEnchantTypeNum(0);
            i.slotType = Item_Slot.SlotType.Ring;
        }
        else if (acc == 534)
        {
            i.SetName("Tourmaline Amulet");
            i.itemDesc = "An amulet made of tourmaline.";
            i.SetItemId(534);
            i.itemValue = 1.50f;
            i.SetEnchantTypeNum(3);
            i.SetSpecificEnchantTypeNum(8);
            i.slotType = Item_Slot.SlotType.Neck;
        }
        else if (acc == 535)
        {
            i.SetName("Tourmaline Earring");
            i.itemDesc = "A earring made from tourmaline.";
            i.SetItemId(535);
            i.itemValue = 1.50f;
            i.SetEnchantTypeNum(3);
            i.SetSpecificEnchantTypeNum(8);
            i.slotType = Item_Slot.SlotType.Earring;
        }
        else if (acc == 536)
        {
            i.SetName("Tourmaline Ring");
            i.itemDesc = "An ring made of tourmaline.";
            i.SetItemId(536);
            i.itemValue = 1.50f;
            i.SetEnchantTypeNum(3);
            i.SetSpecificEnchantTypeNum(8);
            i.slotType = Item_Slot.SlotType.Ring;
        }
    }
}
