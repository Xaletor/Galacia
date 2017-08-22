using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Database : MonoBehaviour {

    public Sprite[] o_Swords;
    public Sprite[] t_Swords;
    public Sprite[] dagger;
    public Sprite[] o_Mace;
    public Sprite[] t_Mace;
    public Sprite[] axe;
    public Sprite[] spear;
    public Sprite[] staff;
    public Sprite[] fist;
    public Sprite[] Bow;

    public Sprite GetIcon(int _id, Item.ItemQualityModifiers quality)
    {
        #region O_Swords 101 - 109
        if (_id == 101)
        {
            return o_Swords[0];
        }
        else if (_id == 102)
        {
            return o_Swords[1];
        }
        else if (_id == 103)
        {
            return o_Swords[2];
        }
        else if (_id == 104)
        {
            return o_Swords[3];
        }
        else if (_id == 105)
        {
            return o_Swords[4];
        }
        else if (_id == 106)
        {
            return o_Swords[5];
        }
        else if (_id == 107)
        {
            return o_Swords[6];
        }
        else if (_id == 108)
        {
            return o_Swords[7];
        }
        else if (_id == 109)
        {
            return o_Swords[8];
        }
        #endregion

        #region T_Swords 110 - 118
        if (_id == 110)
        {
            return t_Swords[0];
        }
        else if (_id == 111)
        {
            return t_Swords[1];
        }
        else if (_id == 112)
        {
            return t_Swords[2];
        }
        else if (_id == 113)
        {
            return t_Swords[3];
        }
        else if (_id == 114)
        {
            return t_Swords[4];
        }
        else if (_id == 115)
        {
            return t_Swords[5];
        }
        else if (_id == 116)
        {
            return t_Swords[6];
        }
        else if (_id == 117)
        {
            return t_Swords[7];
        }
        else if (_id == 118)
        {
            return t_Swords[8];
        }
        #endregion

        #region Daggers 119 - 127
        if (_id == 119)
        {
            return dagger[0];
        }
        else if (_id == 120)
        {
            return dagger[1];
        }
        else if (_id == 121)
        {
            return dagger[2];
        }
        else if (_id == 122)
        {
            return dagger[3];
        }
        else if (_id == 123)
        {
            return dagger[4];
        }
        else if (_id == 124)
        {
            return dagger[5];
        }
        else if (_id == 125)
        {
            return dagger[6];
        }
        else if (_id == 126)
        {
            return dagger[7];
        }
        else if (_id == 127)
        {
            return dagger[8];
        }
        #endregion

        #region O_Mace 128 - 136
        if (_id == 128)
        {
            return o_Mace[0];
        }
        else if (_id == 129)
        {
            return o_Mace[1];
        }
        else if (_id == 130)
        {
            return o_Mace[2];
        }
        else if (_id == 131)
        {
            return o_Mace[3];
        }
        else if (_id == 132)
        {
            return o_Mace[4];
        }
        else if (_id == 133)
        {
            return o_Mace[5];
        }
        else if (_id == 134)
        {
            return o_Mace[6];
        }
        else if (_id == 135)
        {
            return o_Mace[7];
        }
        else if (_id == 136)
        {
            return o_Mace[8];
        }
        #endregion

        #region T_Mace 137 - 144
        if (_id == 137)
        {
            return t_Mace[0];
        }
        else if (_id == 138)
        {
            return t_Mace[1];
        }
        else if (_id == 139)
        {
            return t_Mace[2];
        }
        else if (_id == 140)
        {
            return t_Mace[3];
        }
        else if (_id == 141)
        {
            return t_Mace[4];
        }
        else if (_id == 142)
        {
            return t_Mace[5];
        }
        else if (_id == 143)
        {
            return t_Mace[6];
        }
        else if (_id == 144)
        {
            return t_Mace[7];
        }
        #endregion

        #region Axe 145 - 152
        if (_id == 145)
        {
            return axe[0];
        }
        else if (_id == 146)
        {
            return axe[1];
        }
        else if (_id == 147)
        {
            return axe[2];
        }
        else if (_id == 148)
        {
            return axe[3];
        }
        else if (_id == 149)
        {
            return axe[4];
        }
        else if (_id == 150)
        {
            return axe[5];
        }
        else if (_id == 151)
        {
            return axe[6];
        }
        else if (_id == 152)
        {
            return axe[7];
        }
        #endregion

        #region Spear 153 - 158
        if (_id == 153)
        {
            return spear[0];
        }
        else if (_id == 154)
        {
            return spear[1];
        }
        else if (_id == 155)
        {
            return spear[2];
        }
        else if (_id == 156)
        {
            return spear[3];
        }
        else if (_id == 157)
        {
            return spear[4];
        }
        else if (_id == 158)
        {
            return spear[5];
        }
        #endregion

        #region Staff 159 - 166
        if (_id == 159)
        {
            return staff[0];
        }
        else if (_id == 160)
        {
            return staff[1];
        }
        else if (_id == 161)
        {
            return staff[2];
        }
        else if (_id == 162)
        {
            return staff[3];
        }
        else if (_id == 163)
        {
            return staff[4];
        }
        else if (_id == 164)
        {
            return staff[5];
        }
        else if (_id == 165)
        {
            return staff[5];
        }
        else if (_id == 166)
        {
            return staff[5];
        }
        #endregion

        #region Fist 167 - 170
        if (_id == 167)
        {
            return fist[0];
        }
        else if (_id == 168)
        {
            return fist[1];
        }
        else if (_id == 169)
        {
            return fist[2];
        }
        else if (_id == 170)
        {
            return fist[3];
        }

        #endregion
        
        #region Bow 171
        if (_id == 171)
        {
            return Bow[0];
        }
        #endregion

        else return null;
    }
}
