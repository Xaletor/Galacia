using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Item_Slot : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    public Slot slot;
    public SlotType type;
    public Item item;
    bool mouseInSlot = false;
    Item_Display_UI idu;
    
    // Start
    public void Start()
    {
        item = null;
        idu = GameObject.FindGameObjectWithTag("ITEM_DISPLAY_UI").GetComponent<Item_Display_UI>();
    }

    // Update
    public void FixedUpdate()
    {
        if (item == null && slotChild && slot == Slot.Inventory)
        {
            GetElementItem();
        }
        // if there is a child element in inventory slot
        if (transform.childCount > 0 && slot == Slot.Inventory)
        {
            item = slotChild.GetComponent<Item_Element>().item;
        }
        // if there is a child element in equip slot
        else if (transform.childCount > 1 && slot == Slot.Equip)
        {
            item = slotChild.GetComponent<Item_Element>().item;
        }
        else
        {
            item = null;    
        }

        // if the item is not null, and the item to be displayed is not null
        if (item != null)
        {
            // if the player is holding down rightclick and the mouse is currently in the slot
            if ((Input.GetMouseButtonDown(1) || Input.GetMouseButton(1)) && (Inventory_Display_UI.isOpen) && (mouseInSlot))
            {
                idu.Show();
            }
            else if (!mouseInSlot && item == null)
            {
                idu.Hide();
            }
        }
    }

    public void GetElementItem()
    {
        //item = slotChild.GetComponent<Item_Element>().item;
    }

    // Nullifies the item in the slot
    public void NullifyItem()
    {

    }

    // Updates the Slots
    void UpdateSlots()
    {
        GameObject.Find("Player").GetComponent<Player_Equipped>().UpdateEquipped();
        GameObject.Find("Player").GetComponent<Player_Stats>().UpdateStatsFromEquipped();
    }

    // Equip Or Inventory
    public enum Slot
    {
        Equip = 0,
        Inventory = 1,
    }

    // The type of slot
    public enum SlotType
    {
        Head = 0,
        Chest,
        Gloves,
        Boots,
        Shield,
        Weapon,
        Neck,
        Earring,
        Ring,
        Crystal,
    }

    // Gets the child of the slot
    public GameObject slotChild
    {
        get
        {
            // if the slot is inventory and there is a child element
            if (transform.childCount > 0 && slot == Slot.Inventory)
            {
                var g = transform.GetChild(0).gameObject;
                if (g.GetComponent<Item_Element>())
                {
                    return g;
                }
            }
            // if the slot is equip and there is a child element
            else if (transform.childCount > 1 && slot == Slot.Equip)
            {
                var g = transform.GetChild(1).gameObject;
                if (g.GetComponent<Item_Element>())
                {
                    transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().enabled = false;
                    return g;
                }
            }
            // if the slot is equipped and there isn't a child element but a child image
            else if (transform.childCount == 1 && slot == Slot.Equip && Inventory_Display_UI.isOpen)
            {
                transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().enabled = true;
            }
            // else return null
            return null;
        }
    }

    // When the pointer enters the slot
    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseInSlot = true;
        idu.SetDisplay(item);
        //Debug.Log("Mouse Entered");
    }

    // When the pointer leaves the slot
    public void OnPointerExit(PointerEventData eventData)
    {
        mouseInSlot = false;
        idu.SetDisplay(null);
        //Debug.Log("Mouse Left");
    }

    // When the mouse has pressed down on the slot
    public void OnPointerDown(PointerEventData eventData)
    {
        idu.SetDisplay(item);
    }

    // When the mouse lets go of the item element on item slot
    public void OnDrop(PointerEventData eventData)
    {
        // if the player lets left click go
        if (Input.GetMouseButtonUp(0))
        {
            // If there isn't a slot child
            if (!slotChild)
            {
                // If the slot is inventory
                if (slot == Slot.Inventory)
                {
                    // If the dragged element exists and is not null
                    if (Item_Element.tempDrag.GetComponentInChildren<Item_Element>().item != null)  // If there is an Item Element
                    {
                        item = Item_Element.tempDrag.GetComponentInChildren<Item_Element>().item;
                    }
                    Item_Element.go.transform.SetParent(transform);
                    Item_Element.go.transform.position = transform.position;
                    UpdateSlots();
                }
                // Else if it is Equip
                else if (Item_Element.tempDrag.GetComponentInChildren<Item_Element>().item != null)
                {
                    // If the element and slottype match, and if the slot is indeed equip
                    if (type == Item_Element.tempDrag.GetComponentInChildren<Item_Element>().item.slotType && slot == Slot.Equip)   
                    {
                        item = Item_Element.tempDrag.GetComponentInChildren<Item_Element>().item;
                        Item_Element.go.transform.SetParent(transform);
                        Item_Element.go.transform.position = transform.position;
                        UpdateSlots();
                    }
                }
            }
        }
    }
}
