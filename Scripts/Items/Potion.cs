using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : Item {

    // Initialize Potion : Passing in the potion database from item database, and the item itself
    public void InitializePotion(Item_Database.Potion_Database potion, Item i)
    {
        int p_num = (int)potion;
        SetPotion(p_num, i);
    }

    // Set the Potion
    void SetPotion(int pot, Item i)
    {
        if (pot == 901)
        {
            i.SetName("Lesser Black Potion");
            i.itemDesc = "A lesser potion containing a black liquid.";
            i.SetItemId(901);
            i.itemValue = 1.50f;
        }
        else if (pot == 902)
        {
            i.SetName("Lesser Grey Potion");
            i.itemDesc = "A lesser potion containing a grey liquid.";
            i.SetItemId(902);
            i.itemValue = 1.50f;
        }
        else if (pot == 903)
        {
            i.SetName("Lesser White Potion");
            i.itemDesc = "A lesser potion containing a white liquid.";
            i.SetItemId(903);
            i.itemValue = 1.50f;
        }
        else if (pot == 904)
        {
            i.SetName("Lesser Scarlet Potion");
            i.itemDesc = "A lesser potion containing a dark red liquid.";
            i.SetItemId(904);
            i.itemValue = 1.50f;
        }
        else if (pot == 905)
        {
            i.SetName("Lesser Red Potion");
            i.itemDesc = "A lesser potion containing a red liquid.";
            i.SetItemId(905);
            i.itemValue = 1.50f;
        }
        else if (pot == 906)
        {
            i.SetName("Lesser Pink Potion");
            i.itemDesc = "A lesser potion containing a pink liquid.";
            i.SetItemId(906);
            i.itemValue = 1.50f;
        }
        else if (pot == 907)
        {
            i.SetName("Lesser Brown Potion");
            i.itemDesc = "A lesser potion containing a brown liquid.";
            i.SetItemId(907);
            i.itemValue = 1.50f;
        }
        else if (pot == 908)
        {
            i.SetName("Lesser Orange Potion");
            i.itemDesc = "A lesser potion containing an orange liquid.";
            i.SetItemId(908);
            i.itemValue = 1.50f;
        }
        else if (pot == 909)
        {
            i.SetName("Lesser Vermilion Potion");
            i.itemDesc = "A lesser potion containing a light orange liquid.";
            i.SetItemId(909);
            i.itemValue = 1.50f;
        }
        else if (pot == 910)
        {
            i.SetName("Lesser Fawn Potion");
            i.itemDesc = "A lesser potion containing a dark yellow liquid.";
            i.SetItemId(910);
            i.itemValue = 1.50f;
        }
        else if (pot == 911)
        {
            i.SetName("Lesser Yellow Potion");
            i.itemDesc = "A lesser potion containing a yellow liquid.";
            i.SetItemId(911);
            i.itemValue = 1.50f;
        }
        else if (pot == 912)
        {
            i.SetName("Lesser Beige Potion");
            i.itemDesc = "A lesser potion containing a light yellow liquid.";
            i.SetItemId(912);
            i.itemValue = 1.50f;
        }
        else if (pot == 913)
        {
            i.SetName("Lesser Emerald Potion");
            i.itemDesc = "A lesser potion containing a dark green liquid.";
            i.SetItemId(913);
            i.itemValue = 1.50f;
        }
        else if (pot == 914)
        {
            i.SetName("Lesser Green Potion");
            i.itemDesc = "A lesser potion containing a green liquid.";
            i.SetItemId(914);
            i.itemValue = 1.50f;
        }
        else if (pot == 915)
        {
            i.SetName("Lesser Fern Potion");
            i.itemDesc = "A lesser potion containing a light green liquid.";
            i.SetItemId(915);
            i.itemValue = 1.50f;
        }
        else if (pot == 916)
        {
            i.SetName("Lesser Aegean Potion");
            i.itemDesc = "A lesser potion containing a dark cyan liquid.";
            i.SetItemId(916);
            i.itemValue = 1.50f;
        }
        else if (pot == 917)
        {
            i.SetName("Lesser Cyan Potion");
            i.itemDesc = "A lesser potion containing a cyan liquid.";
            i.SetItemId(917);
            i.itemValue = 1.50f;
        }
        else if (pot == 918)
        {
            i.SetName("Lesser Arctic Potion");
            i.itemDesc = "A lesser potion containing a light cyan liquid.";
            i.SetItemId(918);
            i.itemValue = 1.50f;
        }
        else if (pot == 919)
        {
            i.SetName("Lesser Azure Potion");
            i.itemDesc = "A lesser potion containing a dark blue liquid.";
            i.SetItemId(919);
            i.itemValue = 1.50f;
        }
        else if (pot == 920)
        {
            i.SetName("Lesser Blue Potion");
            i.itemDesc = "A lesser potion containing a blue liquid.";
            i.SetItemId(920);
            i.itemValue = 1.50f;
        }
        else if (pot == 921)
        {
            i.SetName("Lesser Sky Potion");
            i.itemDesc = "A lesser potion containing a light blue liquid.";
            i.SetItemId(921);
            i.itemValue = 1.50f;
        }
        else if (pot == 922)
        {
            i.SetName("Lesser Violet Potion");
            i.itemDesc = "A lesser potion containing a dark purple liquid.";
            i.SetItemId(922);
            i.itemValue = 1.50f;
        }
        else if (pot == 923)
        {
            i.SetName("Lesser Purple Potion");
            i.itemDesc = "A lesser potion containing a purple liquid.";
            i.SetItemId(923);
            i.itemValue = 1.50f;
        }
        else if (pot == 924)
        {
            i.SetName("Lesser Orchid Potion");
            i.itemDesc = "A lesser potion containing a light purple liquid.";
            i.SetItemId(924);
            i.itemValue = 1.50f;
        }
        else if (pot == 925)
        {
            i.SetName("Simple Black Potion");
            i.itemDesc = "A simple potion containing a black liquid.";
            i.SetItemId(925);
            i.itemValue = 1.50f;
        }
        else if (pot == 926)
        {
            i.SetName("Simple Grey Potion");
            i.itemDesc = "A simple potion containing a grey liquid.";
            i.SetItemId(926);
            i.itemValue = 1.50f;
        }
        else if (pot == 927)
        {
            i.SetName("Simple White Potion");
            i.itemDesc = "A simple potion containing a white liquid.";
            i.SetItemId(927);
            i.itemValue = 1.50f;
        }
        else if (pot == 928)
        {
            i.SetName("Simple Scarlet Potion");
            i.itemDesc = "A simple potion containing a dark red liquid.";
            i.SetItemId(928);
            i.itemValue = 1.50f;
        }
        else if (pot == 929)
        {
            i.SetName("Simple Red Potion");
            i.itemDesc = "A simple potion containing a red liquid.";
            i.SetItemId(929);
            i.itemValue = 1.50f;
        }
        else if (pot == 930)
        {
            i.SetName("Simple Pink Potion");
            i.itemDesc = "A simple potion containing a pink liquid.";
            i.SetItemId(930);
            i.itemValue = 1.50f;
        }
        else if (pot == 931)
        {
            i.SetName("Simple Brown Potion");
            i.itemDesc = "A simple potion containing a brown liquid.";
            i.SetItemId(931);
            i.itemValue = 1.50f;
        }
        else if (pot == 932)
        {
            i.SetName("Simple Orange Potion");
            i.itemDesc = "A simple potion containing an orange liquid.";
            i.SetItemId(932);
            i.itemValue = 1.50f;
        }
        else if (pot == 933)
        {
            i.SetName("Simple Vermilion Potion");
            i.itemDesc = "A simple potion containing a light orange liquid.";
            i.SetItemId(933);
            i.itemValue = 1.50f;
        }
        else if (pot == 934)
        {
            i.SetName("Simple Fawn Potion");
            i.itemDesc = "A simple potion containing a dark yellow liquid.";
            i.SetItemId(934);
            i.itemValue = 1.50f;
        }
        else if (pot == 935)
        {
            i.SetName("Simple Yellow Potion");
            i.itemDesc = "A simple potion containing a yellow liquid.";
            i.SetItemId(935);
            i.itemValue = 1.50f;
        }
        else if (pot == 936)
        {
            i.SetName("Simple Beige Potion");
            i.itemDesc = "A simple potion containing a light yellow liquid.";
            i.SetItemId(936);
            i.itemValue = 1.50f;
        }
        else if (pot == 937)
        {
            i.SetName("Simple Emerald Potion");
            i.itemDesc = "A simple potion containing a dark green liquid.";
            i.SetItemId(937);
            i.itemValue = 1.50f;
        }
        else if (pot == 938)
        {
            i.SetName("Simple Green Potion");
            i.itemDesc = "A simple potion containing a green liquid.";
            i.SetItemId(938);
            i.itemValue = 1.50f;
        }
        else if (pot == 939)
        {
            i.SetName("Simple Fern Potion");
            i.itemDesc = "A simple potion containing a light green liquid.";
            i.SetItemId(939);
            i.itemValue = 1.50f;
        }
        else if (pot == 940)
        {
            i.SetName("Simple Aegean Potion");
            i.itemDesc = "A simple potion containing a dark cyan liquid.";
            i.SetItemId(940);
            i.itemValue = 1.50f;
        }
        else if (pot == 941)
        {
            i.SetName("Simple Cyan Potion");
            i.itemDesc = "A simple potion containing a cyan liquid.";
            i.SetItemId(941);
            i.itemValue = 1.50f;
        }
        else if (pot == 942)
        {
            i.SetName("Simple Arctic Potion");
            i.itemDesc = "A simple potion containing a light cyan liquid.";
            i.SetItemId(942);
            i.itemValue = 1.50f;
        }
        else if (pot == 943)
        {
            i.SetName("Simple Azure Potion");
            i.itemDesc = "A simple potion containing a dark blue liquid.";
            i.SetItemId(943);
            i.itemValue = 1.50f;
        }
        else if (pot == 944)
        {
            i.SetName("Simple Blue Potion");
            i.itemDesc = "A simple potion containing a blue liquid.";
            i.SetItemId(944);
            i.itemValue = 1.50f;
        }
        else if (pot == 945)
        {
            i.SetName("Simple Sky Potion");
            i.itemDesc = "A simple potion containing a light blue liquid.";
            i.SetItemId(945);
            i.itemValue = 1.50f;
        }
        else if (pot == 946)
        {
            i.SetName("Simple Violet Potion");
            i.itemDesc = "A simple potion containing a dark purple liquid.";
            i.SetItemId(946);
            i.itemValue = 1.50f;
        }
        else if (pot == 947)
        {
            i.SetName("Simple Purple Potion");
            i.itemDesc = "A simple potion containing a purple liquid.";
            i.SetItemId(947);
            i.itemValue = 1.50f;
        }
        else if (pot == 948)
        {
            i.SetName("Simple Orchid Potion");
            i.itemDesc = "A simple potion containing a light purple liquid.";
            i.SetItemId(948);
            i.itemValue = 1.50f;
        }
        else if (pot == 949)
        {
            i.SetName("Complex Potion (Red/Orange)");
            i.itemDesc = "A complex potion holding both red and orange liquids.";
            i.SetItemId(949);
            i.itemValue = 1.50f;
        }
        else if (pot == 950)
        {
            i.SetName("Complex Potion (Red/Yellow)");
            i.itemDesc = "A complex potion holding both red and yellow liquids.";
            i.SetItemId(950);
            i.itemValue = 1.50f;
        }
        else if (pot == 951)
        {
            i.SetName("Complex Potion (Red/Green)");
            i.itemDesc = "A complex potion holding both red and green liquids.";
            i.SetItemId(951);
            i.itemValue = 1.50f;
        }
        else if (pot == 952)
        {
            i.SetName("Complex Potion (Red/Cyan)");
            i.itemDesc = "A complex potion holding both red and cyan liquids.";
            i.SetItemId(952);
            i.itemValue = 1.50f;
        }
        else if (pot == 953)
        {
            i.SetName("Complex Potion (Red/Blue)");
            i.itemDesc = "A complex potion holding both red and blue liquids.";
            i.SetItemId(953);
            i.itemValue = 1.50f;
        }
        else if (pot == 954)
        {
            i.SetName("Complex Potion (Red/Purple)");
            i.itemDesc = "A complex potion holding both red and purple liquids.";
            i.SetItemId(954);
            i.itemValue = 1.50f;
        }
        else if (pot == 955)
        {
            i.SetName("Complex Potion (Orange/Yellow)");
            i.itemDesc = "A complex potion holding both orange and yellow liquids.";
            i.SetItemId(955);
            i.itemValue = 1.50f;
        }
        else if (pot == 956)
        {
            i.SetName("Complex Potion (Orange/Green)");
            i.itemDesc = "A complex potion holding both orange and green liquids.";
            i.SetItemId(956);
            i.itemValue = 1.50f;
        }
        else if (pot == 957)
        {
            i.SetName("Complex Potion (Orange/Cyan)");
            i.itemDesc = "A complex potion holding both orange and cyan liquids.";
            i.SetItemId(957);
            i.itemValue = 1.50f;
        }
        else if (pot == 958)
        {
            i.SetName("Complex Potion (Orange/Blue)");
            i.itemDesc = "A complex potion holding both orange and blue liquids.";
            i.SetItemId(958);
            i.itemValue = 1.50f;
        }
        else if (pot == 959)
        {
            i.SetName("Complex Potion (Orange/Purple)");
            i.itemDesc = "A complex potion holding both orange and purple liquids.";
            i.SetItemId(959);
            i.itemValue = 1.50f;
        }
        else if (pot == 960)
        {
            i.SetName("Complex Potion (Yellow/Green)");
            i.itemDesc = "A complex potion holding both yellow and green liquids.";
            i.SetItemId(960);
            i.itemValue = 1.50f;
        }
        else if (pot == 961)
        {
            i.SetName("Complex Potion (Yellow/Cyan)");
            i.itemDesc = "A complex potion holding both yellow and cyan liquids.";
            i.SetItemId(961);
            i.itemValue = 1.50f;
        }
        else if (pot == 962)
        {
            i.SetName("Complex Potion (Yellow/Blue)");
            i.itemDesc = "A complex potion holding both yellow and blue liquids.";
            i.SetItemId(962);
            i.itemValue = 1.50f;
        }
        else if (pot == 963)
        {
            i.SetName("Complex Potion (Yellow/Purple)");
            i.itemDesc = "A complex potion holding both yellow and purple liquids.";
            i.SetItemId(963);
            i.itemValue = 1.50f;
        }
        else if (pot == 964)
        {
            i.SetName("Complex Potion (Green/Cyan)");
            i.itemDesc = "A complex potion holding both green and cyan liquids.";
            i.SetItemId(964);
            i.itemValue = 1.50f;
        }
        else if (pot == 965)
        {
            i.SetName("Complex Potion (Green/Blue)");
            i.itemDesc = "A complex potion holding both green and blue liquids.";
            i.SetItemId(965);
            i.itemValue = 1.50f;
        }
        else if (pot == 966)
        {
            i.SetName("Complex Potion (Green/Purple)");
            i.itemDesc = "A complex potion holding both green and purple liquids.";
            i.SetItemId(966);
            i.itemValue = 1.50f;
        }
        else if (pot == 967)
        {
            i.SetName("Complex Potion (Cyan/Blue)");
            i.itemDesc = "A complex potion holding both cyan and blue liquids.";
            i.SetItemId(967);
            i.itemValue = 1.50f;
        }
        else if (pot == 968)
        {
            i.SetName("Complex Potion (Cyan/Purple)");
            i.itemDesc = "A complex potion holding both cyan and purple liquids.";
            i.SetItemId(968);
            i.itemValue = 1.50f;
        }
        else if (pot == 969)
        {
            i.SetName("Complex Potion (Blue/Purple)");
            i.itemDesc = "A complex potion holding both blue and purple liquids.";
            i.SetItemId(969);
            i.itemValue = 1.50f;
        }
    }

}
