using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Stats_UI : MonoBehaviour {


    [Header("MAIN")]
    public Text nameText;
    public Text classText;
    public Text levelText;
    public Text goldText;

    [Header("Vitals")]
    public Text damageText;
    public Text armorText;
    public Text shieldText;
    public Text hpText;
    public Text spText;
    public Text epText;

    [Header("Primaries")]
    public Text strText;
    public Text dexText;
    public Text intText;
    public Text endText;
    public Text vitText;
    public Text agiText;
    public Text lukText;

    [Header("Secondaries")]
    public Text perText;
    public Text ferText;
    public Text spdText;
    public Text evaText;
    public Text sprText;
    public Text wisText;
    public Text penText;

    [Header("Tertiaries")]
    public Text magpText;
    public Text monpText;
    public Text dampText;
    public Text hppText;
    public Text sppText;
    public Text eppText;
    public Text lspText;


    public void SetMain(string pname, string pclass, string plevel, float gold)
    {
        nameText.text = "Name : " + pname;
        classText.text = "Class : " + pclass;
        levelText.text = "Level : " + plevel;
        int[] monies = Currency.ConvertValueToCredits(gold);
        goldText.text = Currency.ConvertCreditsToText(monies);
    }

    public void SetPrimaries(string pstr, string pdex, string pint, string pend, string pvit, string pagi, string pluk)
    {
        strText.text = "STR : " + pstr;
        dexText.text = "DEX : " + pdex;
        intText.text = "INT : " + pint;
        endText.text = "END : " + pend;
        vitText.text = "VIT : " + pvit;
        agiText.text = "AGI : " + pagi;
        lukText.text = "LUK : " + pluk;
    }

    public void SetSecondaries(string pper, string pfer, string pspd, string peva, string pspr, string pwis, string ppen)
    {
        perText.text = "PER : " + pper;
        ferText.text = "FER : " + pfer;
        spdText.text = "SPD : " + pspd;
        evaText.text = "EVA : " + peva;
        sprText.text = "SPR : " + pspr;
        wisText.text = "WIS : " + pwis;
        penText.text = "PEN : " + ppen;
    }

    public void SetTertiaries(string pmagp, string pmonp, string pdamp, string phpp, string pspp, string pepp, string plsp)
    {
        magpText.text = "MAG% : " + pmagp;
        monpText.text = "MON% : " + pmonp;
        dampText.text = "DAM% : " + pdamp;
        hppText.text = "HP% : " + phpp;
        sppText.text = "SP% : " + pspp;
        eppText.text = "EP% : " + pepp;
        lspText.text = "LS% : " + plsp;
    }

    public void SetVitals(string pmidmg, string pmadmg, string parm, string pcshi, string pmshi, string pchp, string pmhp, string pcsp, string pmsp, string pcep, string pmep)
    {
        damageText.text = "DMG : (" + pmidmg + " - " + pmadmg + ")";
        armorText.text = "Armor : " + parm;
        shieldText.text = "Shields : " + pcshi + "/" + pmshi;
        hpText.text = "HP : " + pchp + "/" + pmhp;
        spText.text = "SP : " + pcsp + "/" + pmsp;
        epText.text = "EP : " + pcep + "/" + pmep;
    }



}
