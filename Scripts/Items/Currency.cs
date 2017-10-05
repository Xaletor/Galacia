using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour {

    public void Start()
    {
        int[] what = ConvertValueToCredits(7777777);
        Debug.Log("[CURRENCY = G:" + what[2] + ", S:" + what[1] + ", C:" + what[0]+"]");
    }

    public static int[] ConvertValueToCredits(float money)
    {
        float rem = 0.00f;
        float rem2 = 0.00f;
        float rem3 = 0.00f;

        int[] monies = new int[3];
        monies[2] = (int)(money / 10000f);
        rem = money % 10000;
        monies[1] = (int)(rem / 100f);
        rem2 = rem % 100;
        monies[0] = (int)rem2;

        return monies;
        
    }

    public static string ConvertCreditsToText(int[] credits)
    {
        if (credits[2] == 0 && credits[1] == 0 && credits[0] != 0)
        {
            return "[CURRENCY = C:" + credits[0] + "]";

        }
        else if (credits[2] == 0 && credits[1] != 0 && credits[0] == 0)
        {
            return "[CURRENCY = S:" + credits[1] + "]";

        }
        else if (credits[2] != 0 && credits[1] == 0 && credits[0] == 0)
        {
            return "[CURRENCY = G:" + credits[2] + "]";

        }
        else if (credits[2] == 0 && credits[1] != 0 && credits[0] != 0)
        {
            return "[CURRENCY = S:" + credits[1] + " C:" + credits[0] + "]";

        }
        else if (credits[2] != 0 && credits[1] == 0 && credits[0] != 0)
        {
            return "[CURRENCY = G:" + credits[2] + " C:" + credits[0] + "]";

        }
        else if (credits[2] != 0 && credits[1] != 0 && credits[0] == 0)
        {
            return "[CURRENCY = G:" + credits[2] + " S:" + credits[1] + "]";

        }
        else if (credits[2] == 0 && credits[1] == 0 && credits[0] == 0)
        {
            return "[CURRENCY = C:" + credits[0] + "]";

        }
        else
        {
            return "[CURRENCY = G:" + credits[2] + ", S:" + credits[1] + ", C:" + credits[0] + "]";
        }
    }

}
