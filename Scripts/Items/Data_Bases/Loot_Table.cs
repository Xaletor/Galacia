using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot_Table : MonoBehaviour {
    /// <summary>
    /// Attach this to a monster that will drop items
    /// </summary>
    
    [Range(0.00f,100.00f)]
    public float accessoryChance; 
    public List<Item_Database.Accessory_Database> accessoriesTable;
    [Range(0.00f, 100.00f)]
    public float armorChance;
    public List<Item_Database.Armor_Database> armorTable;
    [Range(0.00f, 100.00f)]
    public float monsterChance;
    public List<Item_Database.Miscellaneous_Drop_Database> monsterTable;
    [Range(0.00f, 100.00f)]
    public float potionChance;
    public List<Item_Database.Potion_Database> potionTable;
    [Range(0.00f, 100.00f)]
    public float questChance;
    public List<Item_Database.Quest_Database> questTable;
    [Range(0.00f, 100.00f)]
    public float weaponsChance;
    public List<Item_Database.Weapons_Database> weaponsTable;

}
