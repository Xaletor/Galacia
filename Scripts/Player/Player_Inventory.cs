using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Inventory : MonoBehaviour
{
    public GameObject slotTemplate;
    public GameObject ui_Parent;
    public GameObject elementTemplate;
    public GameObject invSlotManager;
    public List<Item_Slot> invSlots;
    public List<Item> inventory_Items = new List<Item>();
    public Item_Display_UI idu;
    public float playerMoney = 0;
    public bool inventoryFull = false;

    void Awake()
    {
        InitializeSlots();
    }

    void Start()
    {
        AddSlotsToList();
        idu = GameObject.FindGameObjectWithTag("ITEM_DISPLAY_UI").GetComponent<Item_Display_UI>();
    }

    public void InitializeSlots()
    {
        for (int i = 0; i < 72; i++)
        {
            GameObject invSlotClone = Instantiate(slotTemplate, ui_Parent.transform);
            invSlotClone.AddComponent<Item_Slot>().item = null;
            invSlotClone.GetComponent<Item_Slot>().slot = Item_Slot.Slot.Inventory;
        }
    }

    public void AddSlotsToList()
    {
        var obs = invSlotManager.GetComponentsInChildren<Item_Slot>();
        foreach (Item_Slot iS in obs)
        {
            invSlots.Add(iS);
        }
    }

    public void AddItemToInventory(Item item)
    {
        for(int i = 0; i < invSlots.Count; i++)
        {
            if(invSlots[i].slotChild == null)
            {
                GameObject itemElement = Instantiate(elementTemplate, invSlots[i].transform) as GameObject;
                itemElement.AddComponent<Item_Element>();
                itemElement.GetComponent<Item_Element>().item = item;
                invSlots[i].item = item;
                break;
            }
        }
    }

    public bool CanItemBeAdded()
    {
        return !inventoryFull;
    }

    void FixedUpdate()
    {
        if(inventory_Items.Count >= 72)
        {
            inventoryFull = true;
        }
        else
        {
            inventoryFull = false;
        }
    }

}
