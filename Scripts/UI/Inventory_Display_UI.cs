using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Display_UI : MonoBehaviour {

    public GameObject[] invUiObjects;
    public GameObject[] test;
    public static bool isOpen = false;
    public void Start()
    {

            var ims = GetComponentsInChildren<UnityEngine.UI.Image>();
            foreach (UnityEngine.UI.Image i in ims)
            {
                if (i != null)
                {
                    i.enabled = false;
                }
            }

            var txs = GetComponentsInChildren<UnityEngine.UI.Text>();

            foreach (UnityEngine.UI.Text t in txs)
            {
                if (t != null)
                {
                    t.enabled = false;
                }
            }
        
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            isOpen = !isOpen;
            var ims = GetComponentsInChildren<UnityEngine.UI.Image>();
            foreach (UnityEngine.UI.Image i in ims)
            {
                if (i != null)
                {
                    i.enabled = !i.enabled;
                }
            }

            var txs = GetComponentsInChildren<UnityEngine.UI.Text>();

            foreach (UnityEngine.UI.Text t in txs)
            {
                if (t != null)
                {
                    t.enabled = !t.enabled;
                }
            }
        }
    }
}
