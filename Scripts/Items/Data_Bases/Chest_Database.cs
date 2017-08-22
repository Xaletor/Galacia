using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest_Database : MonoBehaviour {

    public List<GameObject> chests;

    public GameObject GetChest(int index)
    {
        return chests[index];
    }
}
