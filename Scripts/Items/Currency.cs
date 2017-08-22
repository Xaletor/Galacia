using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour {

    public void Start()
    {
        int[] what = ConvertValueToCredits(6695940);
        Debug.Log("[CURRENCY = G:" + what[2] + ", H:" + what[1] + ", S:" + what[0]+"]");
    }

    public static int[] ConvertValueToCredits(float money)
    {
        float rem = 0.00f;
        float rem2 = 0.00f;

        int[] credits = new int[3];
        credits[2] = (int)(money / 1000000f);
        rem = money % 1000000;
        credits[1] = (int)(rem / 1000f);
        rem2 = rem % 1000;
        credits[0] = (int)rem2;

        return credits;
        
    }

    public static string ConvertCreditsToText(int[] credits)
    {
        if (credits[2] == 0 && credits[1] == 0 && credits[0] != 0)
        {
            return "[CURRENCY = S:" + credits[0] + "]";

        }
        else if (credits[2] == 0 && credits[1] != 0 && credits[0] == 0)
        {
            return "[CURRENCY = H:" + credits[1] + "]";

        }
        else if (credits[2] != 0 && credits[1] == 0 && credits[0] == 0)
        {
            return "[CURRENCY = G:" + credits[2] + "]";

        }
        else if (credits[2] == 0 && credits[1] != 0 && credits[0] != 0)
        {
            return "[CURRENCY = H:" + credits[1] + ", S:" + credits[0] + "]";

        }
        else if (credits[2] != 0 && credits[1] == 0 && credits[0] != 0)
        {
            return "[CURRENCY = G:" + credits[2] + ", S:" + credits[0] + "]";

        }
        else if (credits[2] != 0 && credits[1] != 0 && credits[0] == 0)
        {
            return "[CURRENCY = G:" + credits[2] + ", H:" + credits[1] + "]";

        }
        else if (credits[2] == 0 && credits[1] == 0 && credits[0] == 0)
        {
            return "[CURRENCY = S:" + credits[0] + "]";

        }
        else
        {
            return "[CURRENCY = G:" + credits[2] + ", H:" + credits[1] + ", S:" + credits[0] + "]";
        }
    }

}
