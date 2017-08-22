using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest_UI : MonoBehaviour {

    public UnityEngine.UI.Image textboxBG;
    public UnityEngine.UI.Text textbox;
    float timedMessage = 0f;
    bool isMessageShown = false;

    void Start()
    {
        HideMessage();
    }

    public void FixedUpdate()
    {
        if(timedMessage > 0f && isMessageShown)
        {
            timedMessage -= Time.deltaTime;
        }
        else if(timedMessage <= 0 && isMessageShown)
        {
            HideMessage();
        }
    }

    public void HideMessage()
    {
        isMessageShown = false;
        GetComponent<UnityEngine.UI.Image>().enabled = false;
        textboxBG.enabled = false;
        textbox.enabled = false;
    }

    public void ShowMessage(Item item)
    {
        isMessageShown = true;

        GetComponent<UnityEngine.UI.Image>().enabled = true;
        textboxBG.enabled = true;
        textbox.enabled = true;
        SetMessage(item.itemName);
        timedMessage = 3f;

    }
    public void SetMessage(string s)
    {
        textbox.text = "You have obtained the item : " + s + "!";
    }

}
