using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Equipped : MonoBehaviour {

    public Item_Slot[] equipSlots;
    List<Item> equippedItems = new List<Item>();

    Item head;
    Item neck;
    Item earring_1;
    Item earring_2;
    Item chest;
    Item pants;
    Item boots;
    Item ring_1;
    Item ring_2;
    Item weapon;
    Item shield;
    Item crystal;

    public void Start()
    {
        equippedItems.Add(head);
        equippedItems.Add(chest);
        equippedItems.Add(pants);
        equippedItems.Add(boots);
        equippedItems.Add(shield);
        equippedItems.Add(weapon);
        equippedItems.Add(neck);
        equippedItems.Add(earring_1);
        equippedItems.Add(earring_2);
        equippedItems.Add(ring_1);
        equippedItems.Add(ring_2);
        equippedItems.Add(crystal);
    }

    public void UpdateEquipped()
    {
        for(int i = 0; i < 12; i++)
        {
            equippedItems[i] = equipSlots[i].item;
        }
    }

    public List<Item> GetEquippedItems()
    {
        return equippedItems;
    }
}
