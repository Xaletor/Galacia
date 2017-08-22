using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor_Database : MonoBehaviour {

    [Header("Light_Armor")]         // ID
    public Armor_Inspector[] lightArmor;
    [Header("Medium_Armor")]
    public Armor_Inspector[] mediumArmor;
    [Header("Heavy_Armor")]
    public Armor_Inspector[] heavyArmor;
    [Header("Shields")]
    public Armor_Inspector[] shields;
    [Header("Gloves")]
    public Armor_Inspector[] gloves;

    public Armor_Inspector GetIcon(int _id, Item.ItemQualityModifiers quality)
    {
        // Light
        #region Light Armor 301 - 312
        if (_id == 301)
        {
            return lightArmor[0];
        }
        else if (_id == 302)
        {
            return lightArmor[1];
        }
        else if (_id == 303)
        {
            return lightArmor[2];
        }
        else if (_id == 304)
        {
            return lightArmor[3];
        }
        else if (_id == 305)
        {
            return lightArmor[4];
        }
        else if (_id == 306)
        {
            return lightArmor[5];
        }
        else if (_id == 307)
        {
            return lightArmor[6];
        }
        else if (_id == 308)
        {
            return lightArmor[7];
        }
        else if (_id == 309)
        {
            return lightArmor[8];
        }
        else if (_id == 310)
        {
            return lightArmor[9];
        }
        else if (_id == 311)
        {
            return lightArmor[10];
        }
        else if (_id == 312)
        {
            return lightArmor[11];
        }
        #endregion

        #region Medium Armor 313 - 324
        if (_id == 313)
        {
            return mediumArmor[0];
        }
        else if (_id == 314)
        {
            return mediumArmor[1];
        }
        else if (_id == 315)
        {
            return mediumArmor[2];
        }
        else if (_id == 316)
        {
            return mediumArmor[3];
        }
        else if (_id == 317)
        {
            return mediumArmor[4];
        }
        else if (_id == 318)
        {
            return mediumArmor[5];
        }
        else if (_id == 319)
        {
            return mediumArmor[6];
        }
        else if (_id == 320)
        {
            return mediumArmor[7];
        }
        else if (_id == 321)
        {
            return mediumArmor[8];
        }
        else if (_id == 322)
        {
            return mediumArmor[9];
        }
        else if (_id == 323)
        {
            return mediumArmor[10];
        }
        else if (_id == 324)
        {
            return mediumArmor[11];
        }
        #endregion

        #region Heavy Armor 325 - 348
        if (_id == 325)
        {
            return heavyArmor[0];
        }
        else if (_id == 326)
        {
            return heavyArmor[1];
        }
        else if (_id == 327)
        {
            return heavyArmor[2];
        }
        else if (_id == 328)
        {
            return heavyArmor[3];
        }
        else if (_id == 329)
        {
            return heavyArmor[4];
        }
        else if (_id == 330)
        {
            return heavyArmor[5];
        }
        else if (_id == 331)
        {
            return heavyArmor[6];
        }
        else if (_id == 332)
        {
            return heavyArmor[7];
        }
        else if (_id == 333)
        {
            return heavyArmor[8];
        }
        else if (_id == 334)
        {
            return heavyArmor[9];
        }
        else if (_id == 335)
        {
            return heavyArmor[10];
        }
        else if (_id == 336)
        {
            return heavyArmor[11];
        }
        else if (_id == 337)
        {
            return heavyArmor[12];
        }
        else if (_id == 338)
        {
            return heavyArmor[13];
        }
        else if (_id == 339)
        {
            return heavyArmor[14];
        }
        else if (_id == 340)
        {
            return heavyArmor[15];
        }
        else if (_id == 341)
        {
            return heavyArmor[16];
        }
        else if (_id == 342)
        {
            return heavyArmor[17];
        }
        else if (_id == 343)
        {
            return heavyArmor[18];
        }
        else if (_id == 344)
        {
            return heavyArmor[19];
        }
        else if (_id == 345)
        {
            return heavyArmor[20];
        }
        else if (_id == 346)
        {
            return heavyArmor[21];
        }
        else if (_id == 347)
        {
            return heavyArmor[22];
        }
        else if (_id == 348)
        {
            return heavyArmor[23];
        }
        #endregion

        #region Shield Armor 349 - 380
        if (_id == 349)
        {
            return shields[0];
        }
        else if (_id == 350)
        {
            return shields[1];
        }
        else if (_id == 351)
        {
            return shields[2];
        }
        else if (_id == 352)
        {
            return shields[3];
        }
        else if (_id == 353)
        {
            return shields[4];
        }
        else if (_id == 354)
        {
            return shields[5];
        }
        else if (_id == 355)
        {
            return shields[6];
        }
        else if (_id == 356)
        {
            return shields[7];
        }
        else if (_id == 357)
        {
            return shields[8];
        }
        else if (_id == 358)
        {
            return shields[9];
        }
        else if (_id == 359)
        {
            return shields[10];
        }
        else if (_id == 360)
        {
            return shields[11];
        }
        else if (_id == 361)
        {
            return shields[12];
        }
        else if (_id == 362)
        {
            return shields[13];
        }
        else if (_id == 363)
        {
            return shields[14];
        }
        else if (_id == 364)
        {
            return shields[15];
        }
        else if (_id == 365)
        {
            return shields[16];
        }
        else if (_id == 366)
        {
            return shields[17];
        }
        else if (_id == 367)
        {
            return shields[18];
        }
        else if (_id == 368)
        {
            return shields[19];
        }
        else if (_id == 369)
        {
            return shields[20];
        }
        else if (_id == 370)
        {
            return shields[21];
        }
        else if (_id == 371)
        {
            return shields[22];
        }
        else if (_id == 372)
        {
            return shields[23];
        }
        else if (_id == 373)
        {
            return shields[24];
        }
        else if (_id == 374)
        {
            return shields[25];
        }
        else if (_id == 375)
        {
            return shields[26];
        }
        else if (_id == 376)
        {
            return shields[27];
        }
        else if (_id == 377)
        {
            return shields[28];
        }
        else if (_id == 378)
        {
            return shields[29];
        }
        else if (_id == 379)
        {
            return shields[30];
        }
        else if (_id == 380)
        {
            return shields[31];
        }
        #endregion

        #region Glove Armor 381 - 394
        if (_id == 381)
        {
            return gloves[0];
        }
        else if (_id == 382)
        {
            return gloves[1];
        }
        else if (_id == 383)
        {
            return gloves[2];
        }
        else if (_id == 384)
        {
            return gloves[3];
        }
        else if (_id == 385)
        {
            return gloves[4];
        }
        else if (_id == 386)
        {
            return gloves[5];
        }
        else if (_id == 387)
        {
            return gloves[6];
        }
        else if (_id == 388)
        {
            return gloves[7];
        }
        else if (_id == 389)
        {
            return gloves[8];
        }
        else if (_id == 390)
        {
            return gloves[9];
        }
        else if (_id == 391)
        {
            return gloves[10];
        }
        else if (_id == 392)
        {
            return gloves[11];
        }
        else if (_id == 393)
        {
            return gloves[12];
        }
        else if (_id == 394)
        {
            return gloves[13];
        }
        #endregion

        else return null;
    }
}
