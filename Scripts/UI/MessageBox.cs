using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageBox : MonoBehaviour {

    public static bool isShowing = false;

    public GameObject ins_TextBox_UI;
    public UnityEngine.UI.Text ins_TextBox;
    public UnityEngine.UI.Text ins_Title;

    public static GameObject st_TextBox_UI;
    public static UnityEngine.UI.Text st_TextBox;
    public static UnityEngine.UI.Text st_Title;

    void Awake()
    {
        st_TextBox = ins_TextBox;
        st_Title = ins_Title;
        st_TextBox_UI = ins_TextBox_UI;
        HideBox();   
    }

    void Update()
    {

        if (isShowing)
        {
            GetComponent<UnityEngine.UI.Image>().enabled = true;
            if (Input.GetMouseButtonDown(0))
            {      
                // If (no more in queue){
                st_Title.text = "";
                st_TextBox.text = "";
                HideBox();
                // }
                // else dequeue
            }
        }
        if (!isShowing)
        {
            GetComponent<UnityEngine.UI.Image>().enabled = false;
        }
    }

    public static void ShowBox()
    {
        isShowing = true;
        st_TextBox_UI.SetActive(true);
    }
    public static void HideBox()
    {
        isShowing = false;
        st_TextBox_UI.SetActive(false);
    }

    public static void Message(string title,string message)
    {
        ShowBox();
        st_Title.text = title;
        st_TextBox.text = message;
    }

}
