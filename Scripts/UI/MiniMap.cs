using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour {

    public int minimum;
    public int maximum;

    public void PosMag()
    {
        if(GetComponent<Camera>().orthographicSize > minimum)
            GetComponent<Camera>().orthographicSize -= 5;
    }

    public void NegMag()
    {
        if (GetComponent<Camera>().orthographicSize < maximum)
            GetComponent<Camera>().orthographicSize += 5;
    }
}
