using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Item_Database {


    // Will select a weapon from the weapons database based on id
    public static Weapons_Database GetWeapon(int id)
    {
        return (Weapons_Database) id;
    }

    // Will select a random weapon from the weapons database
    public static Weapons_Database GetRandomWeapon(int level)
    {
        int x = Random.Range(0, 10);
        if (x == 0)
        {
            return Weapons_Database.O_Sword;
        }
        else if (x == 1)
        {
            return Weapons_Database.T_Sword;
        }
        else if (x == 2)
        {
            return Weapons_Database.Dagger;
        }
        else if (x == 3)
        {
            return Weapons_Database.O_Mace;
        }
        else if (x == 4)
        {
            return Weapons_Database.T_Mace;
        }
        else if (x == 5)
        {
            return Weapons_Database.Axe;
        }
        else if (x == 6)
        {
            return Weapons_Database.Spear;
        }
        else if (x == 7)
        {
            return Weapons_Database.Staff;
        }
        else if (x == 8)
        {
            return Weapons_Database.Fist;
        }
        else if (x == 9)
        {
            return Weapons_Database.Bow;
        }
        else return Weapons_Database.O_Sword;
    }

    // Will select an armor from the armor database based on id
    public static Armor_Database GetArmor(int id)
    {
        if(id == -1)
        {
            return (Armor_Database)Random.Range(301, 395);
        }
        return (Armor_Database) id;
    }

    // Will select a random armor from the armor database based on level
    public static Armor_Database GetRandomArmor(int level)
    {
        return (Armor_Database)Random.Range(301, 395);
    }

    // Will select an accessory from the accessory database based on id
    public static Accessory_Database GetAccessory(int id)
    {
        return (Accessory_Database) id;
    }

    // Will select a random accessory from the accessory database based on level
    public static Accessory_Database GetRandomAccessory(int level)
    {
        return (Accessory_Database)Random.Range(501, 537);
    }

    // Will return a selected quest item by id
    public static Quest_Database GetQuestItem(int id)
    {
        return (Quest_Database)id;
    }

    // Will select a random potion from the potion database
    public static Potion_Database GetPotion(int id)
    {
        return (Potion_Database)id;
    }

    // Will select a random potion from the potion database
    public static Potion_Database GetRandomPotion()
    {
        return (Potion_Database)Random.Range(901, 970);
    }


    // Will select a random mob drop from selected monster by id
    public static Miscellaneous_Drop_Database GetMobDrop(int id)
    {
        return (Miscellaneous_Drop_Database)id;
    }

    // Will select a random mob drop from selected monster at random
    public static Miscellaneous_Drop_Database GetRandomMobDrop()
    {
        return (Miscellaneous_Drop_Database)Random.Range(1101, 1143);
    }

    // Will select a random food drop from selected monster by id
    public static Food_Database GetFoodDrop(int id)
    {
        return (Food_Database)id;
    }

    // Will select a random food drop from selected monster at random
    public static Food_Database GetRandomFoodDrop()
    {
        return (Food_Database)Random.Range(1301, 1311);
    }


    /// <summary>
    ///  Databases
    /// </summary>

    public enum Weapons_Database
    {
        O_Sword = 101,
        T_Sword = 110,
        Dagger = 119,
        O_Mace = 128,
        T_Mace = 137,
        Axe = 145,
        Spear = 153,
        Staff = 159,
        Fist = 167,
        Bow = 171
    }
    public enum Armor_Database
    {
        Starter_Light_Helm = 301,
        Starter_Light_Chest,
        Starter_Light_Pants,
        Starter_Light_Boots,

        Starter_Medium_Helm,
        Starter_Medium_Chest,
        Starter_Medium_Pants,
        Starter_Medium_Boots,

        Starter_Heavy_Helm,
        Starter_Heavy_Chest,
        Starter_Heavy_Pants,
        Starter_Heavy_Boots,

    }
    public enum Accessory_Database
    {
        Ruby_Amulet = 501,
        Ruby_Ring,
        Ruby_Earring,
        Sapphire_Amulet,
        Sapphire_Ring,
        Sapphire_Earring,
        Citrine_Amulet,
        Citrine_Ring,
        Citrine_Earring,
        Indicolite_Amulet,
        Indicolite_Ring,
        Indicolite_Earring,
        Peridot_Amulet,
        Peridot_Ring,
        Peridot_Earring,
        Axinite_Amulet,
        Axinite_Ring,
        Axinite_Earring,
        Emerald_Amulet,
        Emerald_Ring,
        Emerald_Earring,
        Garnet_Amulet,
        Garnet_Ring,
        Garnet_Earring,
        Diamond_Amulet,
        Diamond_Ring,
        Diamond_Earring,
        Amethyst_Amulet,
        Amethyst_Ring,
        Amethyst_Earring,
        Spinel_Amulet,
        Spinel_Ring,
        Spinel_Earring,
        Tourmaline_Amulet,
        Tourmaline_Ring,
        Tourmaline_Earring,


    }
    public enum Quest_Database
    {

    }
    public enum Potion_Database
    {
        Lesser_Black = 901,
        Lesser_Grey,
        Lesser_White,
        Lesser_Scarlet,
        Lesser_Red,
        Lesser_Pink,
        Lesser_Brown,
        Lesser_Orange,
        Lesser_Vermilion,
        Lesser_Fawn,
        Lesser_Yellow,
        Lesser_Beige,
        Lesser_Emerald,
        Lesser_Green,
        Lesser_Fern,
        Lesser_Aegean,
        Lesser_Cyan,
        Lesser_Arctic,
        Lesser_Azure,
        Lesser_Blue,
        Lesser_Sky,
        Lesser_Violet,
        Lesser_Purple,
        Lesser_Orchid,

        Simple_Black,
        Simple_Grey,
        Simple_White,
        Simple_Scarlet,
        Simple_Red,
        Simple_Pink,
        Simple_Brown,
        Simple_Orange,
        Simple_Vermilion,
        Simple_Fawn,
        Simple_Yellow,
        Simple_Beige,
        Simple_Emerald,
        Simple_Green,
        Simple_Fern,
        Simple_Aegean,
        Simple_Cyan,
        Simple_Arctic,
        Simple_Azure,
        Simple_Blue,
        Simple_Sky,
        Simple_Violet,
        Simple_Purple,
        Simple_Orchid,

        Complex_Red_Orange,
        Complex_Red_Yellow,
        Complex_Red_Green,
        Complex_Red_Cyan,
        Complex_Red_Blue,
        Complex_Red_Purple,
        Complex_Orange_Yellow,
        Complex_Orange_Green,
        Complex_Orange_Cyan,
        Complex_Orange_Blue,
        Complex_Orange_Purple,
        Complex_Yellow_Green,
        Complex_Yellow_Cyan,
        Complex_Yellow_Blue,
        Complex_Yellow_Purple,
        Complex_Green_Cyan,
        Complex_Green_Blue,
        Complex_Green_Purple,
        Complex_Cyan_Blue,
        Complex_Cyan_Purple,
        Complex_Blue_Purple

    }
    public enum Miscellaneous_Drop_Database
    {
        Slime_Goo_Fire = 1101,
        Slime_Goo_Water,
        Slime_Goo_Ice,
        Slime_Goo_Wind,
        Slime_Goo_Earth,
        Slime_Goo_Light,
        Slime_Goo_Dark,
        Slime_Goo_Soul,
        Bat_Wing_Fire,
        Bat_Wing_Water,
        Bat_Wing_Ice,
        Bat_Wing_Wind,
        Bat_Wing_Earth,
        Bat_Wing_Light,
        Bat_Wing_Dark,
        Bat_Wing_Soul,
        Bat_Venom,
        Bat_Fang,
        Fire_Essence,
        Water_Essence,
        Ice_Essence,
        Wind_Essence,
        Thunder_Essence,
        Earth_Essence,
        Light_Essence,
        Dark_Essence,
        Soul_Essence,
        Poison_Essence,
        Blood_Essence,
        Aether_Essence,
        Ruby,
        Sapphire,
        Indicolite,
        Peridot,
        Citrine,
        Axinite,
        Diamond,
        Amethyst,
        Tourmaline,
        Emerald,
        Garnet,
        Spinel,

    }

    public enum Food_Database
    {
        Cherry = 1301,
        Pear,
        Banana,
        Apple,
        Grape,
        Watermelon,
        Orange,
        Strawberry,
        Carrot,
        Tomato,
    }


}
