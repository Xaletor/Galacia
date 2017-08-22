using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleaningManager : MonoBehaviour {
    GameObject g = null;
    public void Update()
    {
        g = GameObject.Find("New Game Object");
        if (g != null)
        {
            Destroy(g);
        }
    }
}
