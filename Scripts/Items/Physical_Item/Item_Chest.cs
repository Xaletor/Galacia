using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Chest : MonoBehaviour {

    Item item;
    Animator ator;
    AudioSource aS;
    public ChestType chestType = ChestType.Random;
    public AudioClip open;
    public AudioClip close;
    bool isopen = false;
    bool messageDisplayed = false;
    bool inRange = false;
    int rarityMod = 0;
    ChestType oldType;

    void Start()
    {
        ator = GetComponent<Animator>();
        aS = GetComponent<AudioSource>();
        oldType = chestType;   
    }

    public enum ChestType
    {
        Random,
        Money,
        Weapon,
        Armor,
        Accessory,
        Consumable,
        Misc,
        Box,
        Wooden,
        Bronze,
        Silver,
        Gold,
        Purple,
        Crimson
    }

    public void FixedUpdate()
    {
        if(inRange)
        {
            if (Input.GetKeyDown(KeyCode.E) && !isopen && !Inventory_Display_UI.isOpen)
            {
                isopen = true;
                GenerateItem();
                aS.volume = 0.1f;
                aS.PlayOneShot(open);
                StartCoroutine(OpenChest());
            }
            else if (Input.GetKey(KeyCode.R) && isopen)
            {
                ResetChest();
            }
        }
        if(isopen && !messageDisplayed)
        {
            var display = GameObject.FindGameObjectWithTag("Chest_UI").GetComponent<Chest_UI>();
            display.ShowMessage(item);
            Debug.Log(item.GetItemName());
            messageDisplayed = true;
        }
    }

    public void GenerateItem()
    {
        if(chestType == ChestType.Random)
        {
            chestType = (ChestType)Random.Range(1, 7);
            rarityMod = 0;
        }

        if(chestType == ChestType.Box)
        {
            chestType = (ChestType)Random.Range(1,4);
            rarityMod = 1;
        }
        else if(chestType == ChestType.Wooden)
        {
            chestType = (ChestType)Random.Range(1, 4);
            rarityMod = 2;
        }
        else if (chestType == ChestType.Bronze)
        {
            chestType = (ChestType)Random.Range(1, 4);
            rarityMod = 3;
        }
        else if (chestType == ChestType.Silver)
        {
            chestType = (ChestType)Random.Range(1, 4);
            rarityMod = 4;
        }
        else if (chestType == ChestType.Gold)
        {
            chestType = (ChestType)Random.Range(1, 4);
            rarityMod = 5;
        }
        else if (chestType == ChestType.Purple)
        {
            chestType = (ChestType)Random.Range(1, 4);
            rarityMod = 6;
        }
        else if (chestType == ChestType.Crimson)
        {
            chestType = (ChestType)Random.Range(1, 4);
            rarityMod = 7;
        }


        if (chestType == ChestType.Weapon)
        {
            item = new Item(Item.ItemTypes.Weapon, GameObject.Find("Player").GetComponent<Player_Stats>().playerLevel, rarityMod);
        }
        else if (chestType == ChestType.Armor)
        {
            item = new Item(Item.ItemTypes.Armor, GameObject.Find("Player").GetComponent<Player_Stats>().playerLevel, rarityMod,Random.Range(301,395));
        }
        else if (chestType == ChestType.Consumable)
        {
            item = new Item(Item.ItemTypes.Potion, GameObject.Find("Player").GetComponent<Player_Stats>().playerLevel);
        }
        else if (chestType == ChestType.Accessory)
        {
            item = new Item(Item.ItemTypes.Accessory, GameObject.Find("Player").GetComponent<Player_Stats>().playerLevel);
        }
        else if (chestType == ChestType.Misc)
        {
            item = new Item(Item.ItemTypes.Monster, GameObject.Find("Player").GetComponent<Player_Stats>().playerLevel);
        }
        else if (chestType == ChestType.Money)
        {
            item = new Item(Item.ItemTypes.Money, GameObject.Find("Player").GetComponent<Player_Stats>().playerLevel, rarityMod);
        }

        if (chestType != ChestType.Money)
        {
            var idu = GameObject.FindGameObjectWithTag("ITEM_DISPLAY_UI").GetComponent<Item_Display_UI>();
            idu.SetDisplay(item);
        }
    }

    public void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player" && tag == "ChestTriggerZone")
        {
            inRange = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" && tag == "ChestTriggerZone")
        {
            inRange = true;
        }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player" && tag == "ChestTriggerZone")
        {
            inRange = false;
        }
    }

    public IEnumerator OpenChest()
    {
        ator.SetBool("Open", true);
        if (ator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            var p_Inv = GameObject.Find("Player").GetComponent<Player_Main>().pI;
            if (chestType != ChestType.Money)
            {
                if (p_Inv.CanItemBeAdded())
                {
                    p_Inv.AddItemToInventory(item);
                }
            }
            isopen = true;
        }
        yield return null;
    }

    public void ResetChest()
    {
        aS.volume = 0.1f;
        aS.PlayOneShot(close);
        chestType = oldType;
        isopen = false;
        messageDisplayed = false;
        ator.SetBool("Open", false);
    }
}
