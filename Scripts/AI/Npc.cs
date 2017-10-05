using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour {

    public string name;

    public bool invulnerable;
    public bool talkable;
    public int bondLevel;
    public int hp;

    public List<string> dialogue;

    public string RequestDialogue()
    {
        return dialogue[Random.Range(0,3)];
    }

    public void Update()
    {
        if(talkable && Input.GetKeyDown(KeyCode.E))
        {
            MessageBox.Message(name, RequestDialogue());
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            talkable = true; 
        }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            talkable = false;
            MessageBox.HideBox();
        }
    }
}
