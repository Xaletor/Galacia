using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTextManager : MonoBehaviour {

    static List<GameObject> dtui = new List<GameObject>();

    public void FixedUpdate()
    {
        dtui.AddRange(GameObject.FindGameObjectsWithTag("DamageText"));
    }

    public static bool IsOkToCreate()
    {
        return true;
    }

}