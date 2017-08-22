using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_Chaser_UI : MonoBehaviour {
    UnityEngine.UI.Text p_Text;
    DamageText_UI p_Dui;

    public void InitializeChaser(DamageText_UI _pDui, UnityEngine.UI.Text _pText)
    {
        p_Text = _pText;
        p_Dui = _pDui;
    }

	void Update () {
        SetChaser();
        if (!DamageTextManager.IsOkToCreate())
        {
            Destroy(gameObject);
        }
	}
    public void SetChaser()
    {
        GetComponent<UnityEngine.UI.Text>().fontSize = p_Text.fontSize;
        GetComponent<UnityEngine.UI.Text>().color = p_Dui.chaserColor;
        GetComponent<UnityEngine.UI.Text>().fontStyle = p_Text.fontStyle;
        GetComponent<UnityEngine.UI.Text>().text = p_Text.text;
    }
}
