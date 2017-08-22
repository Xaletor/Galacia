using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Vitals_UI : MonoBehaviour {


    [Header("MAIN")]
    public Text name_Text;
    public Text level_Text;

    [Header("SLIDERS")]
    public Slider bp_Slider;
    public Text bp_Text_Value;

    public Slider hp_Slider;
    public Text hp_Text_Value;

    public Slider sp_Slider;
    public Text sp_Text_Value;

    public Slider ep_Slider;
    public Text ep_Text_Value;

    public Slider exp_Slider;
    public Text exp_Text_Value;

    public void UpdateVitals(int lvl, float mihp, float mahp, float misp, float masp, float miep, float maep, float mibp, float mabp, int cuxp, int maxp, string name)
    {
        name_Text.text = name;
        level_Text.text = lvl.ToString();

        bp_Slider.maxValue = mabp;
        bp_Slider.value = mibp;
        //bp_Text_Value.text = "(" + mibp.ToString() + "/" + mabp.ToString() + ")";

        hp_Slider.maxValue = mahp;
        hp_Slider.value = mihp;
        hp_Text_Value.text = "(" + mihp.ToString("0") + "/" + mahp.ToString("0") + ")";

        sp_Slider.maxValue = masp;
        sp_Slider.value = misp;
        sp_Text_Value.text = "(" + misp.ToString("0") + "/" + masp.ToString("0") + ")";

        ep_Slider.maxValue = maep;
        ep_Slider.value = miep;
        ep_Text_Value.text = "(" + miep.ToString("0") + "/" + maep.ToString("0") + ")";

        exp_Slider.maxValue = maxp;
        exp_Slider.value = cuxp;
        exp_Text_Value.text = "(" + cuxp.ToString("0") + "/" + maxp.ToString("0") + ")";


    }


}
