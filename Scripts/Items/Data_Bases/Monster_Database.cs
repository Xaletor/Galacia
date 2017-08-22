using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Database : MonoBehaviour {

    public List<GameObject> monsters;

    public enum Monsters
    {
        Bat = 0,
    }

    public GameObject GetMonster(int i)
    {
        return monsters[i];
    }

}
