using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food_Database : MonoBehaviour {

    public Sprite[] foods;

    public Sprite GetIcon(int id)
    {
        if (id == 1301)
        {
            return foods[0];
        }
        else if (id == 1302)
        {
            return foods[1];
        }
        else if (id == 1303)
        {
            return foods[2];
        }
        else if (id == 1304)
        {
            return foods[3];
        }
        else if (id == 1305)
        {
            return foods[4];
        }
        else if (id == 1306)
        {
            return foods[5];
        }
        else if (id == 1307)
        {
            return foods[6];
        }
        else if (id == 1308)
        {
            return foods[7];
        }
        else if (id == 1309)
        {
            return foods[8];
        }
        else if (id == 1310)
        {
            return foods[9];
        }
        else
        {
            return foods[0];
        }
    }

}
