using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : Item
{

    // Initialize Food : Passing in the food database from item database, and the item itself
    public void InitializeFood(Item_Database.Food_Database food, Item i)
    {
        int f_num = (int)food;
        SetFood(f_num, i);
    }

    // Sets the food with the foods id and applies it to the item
    public void SetFood(int fo, Item i)
    {
        if (fo == 1301)
        {
            i.SetName("Cherry");
            i.itemDesc = "Yummy cherries!";
            i.SetItemId(1301);
            i.itemValue = 1.5f;
        }
        else if (fo == 1302)
        {
            i.SetName("Pear");
            i.itemDesc = "Tasty!";
            i.SetItemId(1302);
            i.itemValue = 1.5f;
        }
        else if (fo == 1303)
        {
            i.SetName("Banana");
            i.itemDesc = "Nice and yellow!";
            i.SetItemId(1303);
            i.itemValue = 1.5f;
        }
        else if (fo == 1304)
        {
            i.SetName("Apple");
            i.itemDesc = "Nice and crisp!";
            i.SetItemId(1304);
            i.itemValue = 1.5f;
        }
        else if (fo == 1305)
        {
            i.SetName("Grape");
            i.itemDesc = "This is grape, er great!";
            i.SetItemId(1305);
            i.itemValue = 1.5f;
        }
        else if (fo == 1306)
        {
            i.SetName("Watermelon");
            i.itemDesc = "Hope there's no seeds!";
            i.SetItemId(1306);
            i.itemValue = 1.5f;
        }
        else if (fo == 1307)
        {
            i.SetName("Orange");
            i.itemDesc = "Zest is the best!";
            i.SetItemId(1307);
            i.itemValue = 1.5f;
        }
        else if (fo == 1308)
        {
            i.SetName("Strawberry");
            i.itemDesc = "Great with chocolate!";
            i.SetItemId(1308);
            i.itemValue = 1.5f;
        }
        else if (fo == 1309)
        {
            i.SetName("Carrot");
            i.itemDesc = "Crunchy goodness!";
            i.SetItemId(1309);
            i.itemValue = 1.5f;
        }
        else if (fo == 1310)
        {
            i.SetName("Tomato");
            i.itemDesc = "Toemaytoe, towmahtow!";
            i.SetItemId(1310);
            i.itemValue = 1.5f;
        }
    }
}
