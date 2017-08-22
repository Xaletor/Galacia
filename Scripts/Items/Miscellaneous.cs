using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miscellaneous : Item {

    // Initialize Miscellaneous : Passing in the miscellaneous database from item database, and the item itself
    public void InitializeMiscellaneous(Item_Database.Miscellaneous_Drop_Database misc, Item i)
    {
        int m_num = (int)misc;
        SetMiscellaneous(m_num, i);
    }

    // Set Miscellanious Item
    void SetMiscellaneous(int mis, Item i)
    {
        if (mis == 1101)
        {
            i.SetName("Fire Slime");
            i.itemDesc = "Test Desc.";
            i.SetItemId(1101);
            i.itemValue = 1.50f;
        }
        else if (mis == 1102)
        {
            i.SetName("Water Slime");
            i.itemDesc = "Test Desc.";
            i.SetItemId(1102);
            i.itemValue = 1.50f;
        }
        else if (mis == 1103)
        {
            i.SetName("Ice Slime");
            i.itemDesc = "Test Desc.";
            i.SetItemId(1103);
            i.itemValue = 1.50f;
        }
        else if (mis == 1104)
        {
            i.SetName("Wind Slime");
            i.itemDesc = "Test Desc.";
            i.SetItemId(1104);
            i.itemValue = 1.50f;
        }
        else if (mis == 1105)
        {
            i.SetName("Earth Slime");
            i.itemDesc = "Test Desc.";
            i.SetItemId(1105);
            i.itemValue = 1.50f;
        }
        else if (mis == 1106)
        {
            i.SetName("Light Slime");
            i.itemDesc = "Test Desc.";
            i.SetItemId(1106);
            i.itemValue = 1.50f;
        }
        else if (mis == 1107)
        {
            i.SetName("Dark Slime");
            i.itemDesc = "Test Desc.";
            i.SetItemId(1107);
            i.itemValue = 1.50f;
        }
        else if (mis == 1108)
        {
            i.SetName("Soul Slime");
            i.itemDesc = "Test Desc.";
            i.SetItemId(1108);
            i.itemValue = 1.50f;
        }
        else if (mis == 1109)
        {
            i.SetName("Fire Bat Wing");
            i.itemDesc = "Test Desc.";
            i.SetItemId(1109);
            i.itemValue = 1.50f;
        }
        else if (mis == 1110)
        {
            i.SetName("Water Bat Wing");
            i.itemDesc = "Test Desc.";
            i.SetItemId(1110);
            i.itemValue = 1.50f;
        }
        else if (mis == 1111)
        {
            i.SetName("Ice Bat Wing");
            i.itemDesc = "Test Desc.";
            i.SetItemId(1111);
            i.itemValue = 1.50f;
        }
        else if (mis == 1112)
        {
            i.SetName("Wind Bat Wing");
            i.itemDesc = "Test Desc.";
            i.SetItemId(1112);
            i.itemValue = 1.50f;
        }
        else if (mis == 1113)
        {
            i.SetName("Earth Bat Wing");
            i.itemDesc = "Test Desc.";
            i.SetItemId(1113);
            i.itemValue = 1.50f;
        }
        else if (mis == 1114)
        {
            i.SetName("Light Bat Wing");
            i.itemDesc = "Test Desc.";
            i.SetItemId(1114);
            i.itemValue = 1.50f;
        }
        else if (mis == 1115)
        {
            i.SetName("Dark Bat Wing");
            i.itemDesc = "Test Desc.";
            i.SetItemId(1115);
            i.itemValue = 1.50f;
        }
        else if (mis == 1116)
        {
            i.SetName("Soul Bat Wing");
            i.itemDesc = "Test Desc.";
            i.SetItemId(1116);
            i.itemValue = 1.50f;
        }
        else if (mis == 1117)
        {
            i.SetName("Bat Venom");
            i.itemDesc = "Test Desc.";
            i.SetItemId(1117);
            i.itemValue = 1.50f;
        }
        else if (mis == 1118)
        {
            i.SetName("Bat Fang");
            i.itemDesc = "Test Desc.";
            i.SetItemId(1118);
            i.itemValue = 1.50f;
        }
        else if (mis == 1119)
        {
            i.SetName("Fire Essence");
            i.itemDesc = "Test Desc.";
            i.SetItemId(1119);
            i.itemValue = 1.50f;
        }
        else if (mis == 1120)
        {
            i.SetName("Water Essence");
            i.itemDesc = "Test Desc.";
            i.SetItemId(1120);
            i.itemValue = 1.50f;
        }
        else if (mis == 1121)
        {
            i.SetName("Ice Essence");
            i.itemDesc = "Test Desc.";
            i.SetItemId(1121);
            i.itemValue = 1.50f;
        }
        else if (mis == 1122)
        {
            i.SetName("Wind Essence");
            i.itemDesc = "Test Desc.";
            i.SetItemId(1122);
            i.itemValue = 1.50f;
        }
        else if (mis == 1123)
        {
            i.SetName("Thunder Essence");
            i.itemDesc = "Test Desc.";
            i.SetItemId(1123);
            i.itemValue = 1.50f;
        }
        else if (mis == 1124)
        {
            i.SetName("Earth Essence");
            i.itemDesc = "Test Desc.";
            i.SetItemId(1124);
            i.itemValue = 1.50f;
        }
        else if (mis == 1125)
        {
            i.SetName("Light Essence");
            i.itemDesc = "Test Desc.";
            i.SetItemId(1125);
            i.itemValue = 1.50f;
        }
        else if (mis == 1126)
        {
            i.SetName("Dark Essence");
            i.itemDesc = "Test Desc.";
            i.SetItemId(1126);
            i.itemValue = 1.50f;
        }
        else if (mis == 1127)
        {
            i.SetName("Soul Essence");
            i.itemDesc = "Test Desc.";
            i.SetItemId(1127);
            i.itemValue = 1.50f;
        }
        else if (mis == 1128)
        {
            i.SetName("Poison Essence");
            i.itemDesc = "Test Desc.";
            i.SetItemId(1128);
            i.itemValue = 1.50f;
        }
        else if (mis == 1129)
        {
            i.SetName("Blood Essence");
            i.itemDesc = "Test Desc.";
            i.SetItemId(1129);
            i.itemValue = 1.50f;
        }
        else if (mis == 1130)
        {
            i.SetName("Aether Essence");
            i.itemDesc = "Test Desc.";
            i.SetItemId(1130);
            i.itemValue = 1.50f;
        }
        else if (mis == 1131)
        {
            i.SetName("Ruby");
            i.itemDesc = "Test Desc.";
            i.SetItemId(1131);
            i.itemValue = 1.50f;
        }
        else if (mis == 1132)
        {
            i.SetName("Sapphire");
            i.itemDesc = "Test Desc.";
            i.SetItemId(1132);
            i.itemValue = 1.50f;
        }
        else if (mis == 1133)
        {
            i.SetName("Indicolite");
            i.itemDesc = "Test Desc.";
            i.SetItemId(1133);
            i.itemValue = 1.50f;
        }
        else if (mis == 1134)
        {
            i.SetName("Peridot");
            i.itemDesc = "Test Desc.";
            i.SetItemId(1134);
            i.itemValue = 1.50f;
        }
        else if (mis == 1135)
        {
            i.SetName("Citrine");
            i.itemDesc = "Test Desc.";
            i.SetItemId(1135);
            i.itemValue = 1.50f;
        }
        else if (mis == 1136)
        {
            i.SetName("Axinite");
            i.itemDesc = "Test Desc.";
            i.SetItemId(1136);
            i.itemValue = 1.50f;
        }
        else if (mis == 1137)
        {
            i.SetName("Diamond");
            i.itemDesc = "Test Desc.";
            i.SetItemId(1137);
            i.itemValue = 1.50f;
        }
        else if (mis == 1138)
        {
            i.SetName("Amethyst");
            i.itemDesc = "Test Desc.";
            i.SetItemId(1138);
            i.itemValue = 1.50f;
        }
        else if (mis == 1139)
        {
            i.SetName("Tourmaline");
            i.itemDesc = "Test Desc.";
            i.SetItemId(1139);
            i.itemValue = 1.50f;
        }
        else if (mis == 1140)
        {
            i.SetName("Emerald");
            i.itemDesc = "Test Desc.";
            i.SetItemId(1140);
            i.itemValue = 1.50f;
        }
        else if (mis == 1141)
        {
            i.SetName("Garnet");
            i.itemDesc = "Test Desc.";
            i.SetItemId(1131);
            i.itemValue = 1.50f;
        }
        else if (mis == 1142)
        {
            i.SetName("Spinel");
            i.itemDesc = "Test Desc.";
            i.SetItemId(1142);
            i.itemValue = 1.50f;
        }
    }

}
