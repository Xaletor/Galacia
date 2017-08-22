using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item {    

    /// Global Vars
    public Sprite icon;
    // The items id
    private int item_Id = -1;
    // The damage type of the item
    public Damage.DamageType d_Type;
    // The damageOT type of the item
    public Damage_OT.Damage_OTType do_Type;
    // The slot type of the items
    public Item_Slot.SlotType slotType;
    // The items type
    public ItemTypes itemType;
    // The Items set quality
    public ItemQualityModifiers itemQuality;
    // The items level
    public int itemLevel = 0;
    // The name of the item
    public string itemName = "";
    // The items description
    public string itemDesc = "";
    // The items grade desc
    private string gradeDesc = "";
    // The items value
    public float itemValue = 0.00f;
    // Added Damage
    public int bonusDamage = 0;

    // Min and Max damage
    public int minDamage = 0;
    public int maxDamage = 0;
    public int armor = 0;

    ///  Private Vars

    // Quality value + item Modifier
    float v_mod = 0.00f;
    float i_mod = 0.00f;

    // Amount of enchant types on item
    int type_Ones = 0;
    int type_Twos = 0;
    int type_Threes = 0;
    int type_Damage = 0;
    int type_Resist = 0;
    int e_type = -1;
    int se_type = -1;

    int qualityModifier = 0;

    // All the stats
    #region Item_Stats

    public int   
        strength = 0,
        dexterity = 0,
        intellect = 0,
        endurance = 0,
        vitality = 0,
        agility = 0,
        luck = 0,

        p_damage = 0,

        fire_damage = 0,
        water_damage = 0,
        ice_damage = 0,
        thunder_damage = 0,
        wind_damage = 0,
        earth_damage = 0,
        light_damage = 0,
        dark_damage = 0,
        
        soul_damage = 0,

        bleeding_damage = 0,
        poison_damage = 0,
        aether_damage = 0,

        p_Resist = 0,

        fire_Resist = 0,
        water_Resist = 0,
        ice_Resist = 0,
        thunder_Resist = 0,
        wind_Resist = 0,
        earth_Resist = 0,
        light_Resist = 0,
        dark_Resist = 0,

        soul_Resist = 0,

        bleeding_Resist = 0,
        poison_Resist = 0,
        aether_Resist = 0,

        healthPoints = 0,
        spellPoints = 0,
        energyPoints = 0,
        perception = 0,
        ferocity = 0,
        speed = 0,
        evasion = 0,
        spirit = 0,
        wisdom = 0,
        armor_Pen = 0,
        spell_Pen = 0,

        magic_chance = 0,
        currency_percent = 0,
        damage_percent = 0,
        life_percent = 0,
        spell_percent = 0,
        energy_percent = 0,
        lifesteal_percent = 0;

    #endregion

    // Max enchants the item can have
    private int maxEnchants = 0;

    // Can it have a quality grade
    private bool hasGrade = false;

    // Can it be enchanted
    private bool enchantable = false;

    // Get the items ID
    public int GetItemId()
    {
        return item_Id;
    }

    // Set the items ID
    public void SetItemId(int id)
    {
        item_Id = id;
    }

    // List of enchants the item has if any
    private List<Enchant> enchants = new List<Enchant>();

    // Item Types
    public enum ItemTypes
    {
        Weapon,
        Armor,
        Accessory,
        Potion,
        Monster,
        Quest,
        Food,
        Money,
        NONE = 1000
    }

    // Possible Item Qualities
    public enum ItemQualityModifiers
    {
        Poor,
        Basic,
        Fine,
        Great,
        Masterful,
        Epic,
        Legendary,
        Godlike
    }

    // Default Item Constructor
    public Item()
    {

    }

    // Item Constructor with itemtype arg passed
    public Item(ItemTypes _itemType, int _itemLevel = 0, int qualityMod = 0, int _id = -1)
    {
        if (_id != -1)
        {
            SetItemId(_id);
        }


        itemType = _itemType;
        itemLevel = _itemLevel;
        qualityModifier = qualityMod;
        InitializeItem();
    }

    // Can the item have a quality grade?
    public bool CanHaveGrade(ItemTypes t)
    {
        if (t == ItemTypes.Armor || t == ItemTypes.Weapon)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    // Can the item be enchanted?
    public bool CanBeEnchanted(ItemTypes t)
    {
        if (t == ItemTypes.Weapon || t == ItemTypes.Armor || t == ItemTypes.Accessory)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Gets the items Name
    public string GetItemName()
    {
        return itemName;
    }

    // Sets the name of the item
    public void SetName(string _name)
    {
        itemName = _name;
    }

    // Sets Item Description
    public void SetItemDescription()
    {
        itemDesc = GetQualityDescription() + " " + itemDesc;
        itemDesc = itemDesc + " " + enchants[0].GetEnchantDesc();  
    }

    // Sets Item Quality Description
    public void SetQualityDescription(ItemQualityModifiers quality)
    {
        int i = Random.Range(1, 11);

        if (quality == ItemQualityModifiers.Poor)
        {
            if (i == 1)
            {
                gradeDesc = "This should probably be scrapped or sold.";
            }
            else if (i == 2)
            {
                gradeDesc = "The quality of this item is terrible.";
            }
            else if (i == 3)
            {
                gradeDesc = "You had bad luck this time.";
            }
            else if (i == 4)
            {
                gradeDesc = "The vendors may not even take this from you.";
            }
            else if (i == 5)
            {
                gradeDesc = "Put this back where it came from or so help me.";
            }
            else if (i == 6)
            {
                gradeDesc = "Is this even salvagable..?";
            }
            else if (i == 7)
            {
                gradeDesc = "Very poor quality...";
            }
            else if (i == 8)
            {
                gradeDesc = "Not very good quality.";
            }
            else if (i == 9)
            {
                gradeDesc = "There are questionable stains on this.";
            }
            else if (i == 10)
            {
                gradeDesc = "Give this to someone you hate.";
            }
        }
        else if (quality == ItemQualityModifiers.Basic)
        {
            if (i == 1)
            {
                gradeDesc = "Very common to see around.";
            }
            else if (i == 2)
            {
                gradeDesc = "Standard quality item.";
            }
            else if (i == 3)
            {
                gradeDesc = "This item may have some use.";
            }
            else if (i == 4)
            {
                gradeDesc = "Atleast it isn't poor quality.";
            }
            else if (i == 5)
            {
                gradeDesc = "Look how basic this looks.";
            }
            else if (i == 6)
            {
                gradeDesc = "Can be salvaged for parts.";
            }
            else if (i == 7)
            {
                gradeDesc = "Can be sold for money.";
            }
            else if (i == 8)
            {
                gradeDesc = "Probably better items out there.";
            }
            else if (i == 9)
            {
                gradeDesc = "Maybe you'll find a use for this?";
            }
            else if (i == 10)
            {
                gradeDesc = "Looks pretty basic.";
            }
        }
        else if (quality == ItemQualityModifiers.Fine)
        {
            if (i == 1)
            {
                gradeDesc = "A fine quality item.";
            }
            else if (i == 2)
            {
                gradeDesc = "Higher quality than a basic item.";
            }
            else if (i == 3)
            {
                gradeDesc = "Looking pretty fine.";
            }
            else if (i == 4)
            {
                gradeDesc = "No stains on this item.";
            }
            else if (i == 5)
            {
                gradeDesc = "Will salvage for better parts than basic.";
            }
            else if (i == 6)
            {
                gradeDesc = "This item looks pretty fine.";
            }
            else if (i == 7)
            {
                gradeDesc = "Can be sold for money.";
            }
            else if (i == 8)
            {
                gradeDesc = "Probably still better items out there.";
            }
            else if (i == 9)
            {
                gradeDesc = "Looks pretty nice.";
            }
            else if (i == 10)
            {
                gradeDesc = "Has a nice shine to it.";
            }
        }
        else if (quality == ItemQualityModifiers.Great)
        {
            if (i == 1)
            {
                gradeDesc = "A great quality item.";
            }
            else if (i == 2)
            {
                gradeDesc = "Higher quality than a fine item.";
            }
            else if (i == 3)
            {
                gradeDesc = "Looking pretty great there.";
            }
            else if (i == 4)
            {
                gradeDesc = "This quality of item is uncommon.";
            }
            else if (i == 5)
            {
                gradeDesc = "Will salvage for better parts than fine.";
            }
            else if (i == 6)
            {
                gradeDesc = "You can tell there is some potential here.";
            }
            else if (i == 7)
            {
                gradeDesc = "Can be sold for money.";
            }
            else if (i == 8)
            {
                gradeDesc = "Probably even still better items out there.";
            }
            else if (i == 9)
            {
                gradeDesc = "This great item will serve someone well.";
            }
            else if (i == 10)
            {
                gradeDesc = "A better grade than usual.";
            }
        }
        else if (quality == ItemQualityModifiers.Masterful)
        {
            if (i == 1)
            {
                gradeDesc = "An item of masterful quality.";
            }
            else if (i == 2)
            {
                gradeDesc = "An item of much higher quality.";
            }
            else if (i == 3)
            {
                gradeDesc = "This item has a faint emitting glow.";
            }
            else if (i == 4)
            {
                gradeDesc = "This quality of item is pretty uncommon.";
            }
            else if (i == 5)
            {
                gradeDesc = "Will salvage for better parts than great items.";
            }
            else if (i == 6)
            {
                gradeDesc = "Give this to someone you like.";
            }
            else if (i == 7)
            {
                gradeDesc = "Can be sold for more money than usual.";
            }
            else if (i == 8)
            {
                gradeDesc = "Probably even still better items out there?";
            }
            else if (i == 9)
            {
                gradeDesc = "This item will serve someone very well.";
            }
            else if (i == 10)
            {
                gradeDesc = "A much better grade than usual.";
            }
        }
        else if (quality == ItemQualityModifiers.Epic)
        {
            if (i == 1)
            {
                gradeDesc = "An item of epic quality.";
            }
            else if (i == 2)
            {
                gradeDesc = "An item of very much higher quality.";
            }
            else if (i == 3)
            {
                gradeDesc = "This item has a solid emitting purple glow.";
            }
            else if (i == 4)
            {
                gradeDesc = "This quality of item is rare.";
            }
            else if (i == 5)
            {
                gradeDesc = "Will salvage for much better parts..";
            }
            else if (i == 6)
            {
                gradeDesc = "Give this to someone you really like.";
            }
            else if (i == 7)
            {
                gradeDesc = "Can be sold for much more money than usual.";
            }
            else if (i == 8)
            {
                gradeDesc = "Are there better item qualities than this one?";
            }
            else if (i == 9)
            {
                gradeDesc = "This item gives a faint humming sound.";
            }
            else if (i == 10)
            {
                gradeDesc = "This item is epic!";
            }
        }
        else if (quality == ItemQualityModifiers.Legendary)
        {
            if (i == 1)
            {
                gradeDesc = "An item of legendary quality!";
            }
            else if (i == 2)
            {
                gradeDesc = "This item is one of the best you have ever seen!";
            }
            else if (i == 3)
            {
                gradeDesc = "This item has power overflowing from it.";
            }
            else if (i == 4)
            {
                gradeDesc = "Holy smokes look at this thing.";
            }
            else if (i == 5)
            {
                gradeDesc = "Will salvage for top quality parts";
            }
            else if (i == 6)
            {
                gradeDesc = "Give this to someone you love, or maybe keep it.";
            }
            else if (i == 7)
            {
                gradeDesc = "Can be sold for much much more.";
            }
            else if (i == 8)
            {
                gradeDesc = "This may be the best item?";
            }
            else if (i == 9)
            {
                gradeDesc = "You can feel pressure from this item.";
            }
            else if (i == 10)
            {
                gradeDesc = "This item is legendary!";
            }
        }
        else if (quality == ItemQualityModifiers.Godlike)
        {
            if (i == 1)
            {
                gradeDesc = "GODLIKE!";
            }
            else if (i == 2)
            {
                gradeDesc = "Words cannot discribe how godlike the quality is!";
            }
            else if (i == 3)
            {
                gradeDesc = "This item has ridiculous power gushing from it.";
            }
            else if (i == 4)
            {
                gradeDesc = "Should such an item this powerful even exist?";
            }
            else if (i == 5)
            {
                gradeDesc = "Will salvage for alot of top quality parts!";
            }
            else if (i == 6)
            {
                gradeDesc = "Don't give this one away!";
            }
            else if (i == 7)
            {
                gradeDesc = "Can be sold for a fortune!";
            }
            else if (i == 8)
            {
                gradeDesc = "You wont find a better quality in the galaxy!";
            }
            else if (i == 9)
            {
                gradeDesc = "You can feel overwhelming pressure from this item.";
            }
            else if (i == 10)
            {
                gradeDesc = "This item is godlike!";
            }
        }
    }

    // Gets Item Quality Descrition
    public string GetQualityDescription()
    {
        return gradeDesc;
    }

    // Initializes the Item class object, then sets stats, and enchants.
    public void InitializeItem(bool isRandom = true)
    {
        for(int i = 0; i < 8; i++)
        {
            Enchant e = new Enchant();
            e.type = Enchant.EnchantTypes.NONE;
            enchants.Add(e);
        }

        hasGrade = CanHaveGrade(itemType);
        enchantable = CanBeEnchanted(itemType);
        if (itemType != ItemTypes.Money)
        {
            InitializeType();
        }
        else
        {
            float monies = 0;
            itemQuality = SetQuality(isRandom);
            SetQualityStats();

            Player_Main p_Main = GameObject.Find("Player").GetComponent<Player_Main>();
            monies = Random.Range((100 + (itemLevel * (v_mod * 4))) * 3,( 150 + (itemLevel * (v_mod * 5))) * 5);
            p_Main.pI.playerMoney += (int)monies;
            int[] mtx = Currency.ConvertValueToCredits(monies);
            itemName = Currency.ConvertCreditsToText(mtx);
            
            return;
        }

        if (hasGrade)
        {
            itemQuality = SetQuality(isRandom);
            SetQualityStats();
            SetQualityDescription(itemQuality);
        }
        else
        {
            maxEnchants = 2;
        }

        if (enchantable && hasGrade)
        {
            SetEnchants();
        }
        else if(enchantable && !hasGrade)
        {
            enchants[0].GetNewEnchant(this, itemLevel);
            e_type = Random.Range(0,3);
            se_type = -1;
            enchants[1].GetNewEnchant(this, itemLevel);
            ApplyEnchant(0);
            ApplyEnchant(1);
        }
        if(itemType == ItemTypes.Weapon || itemType == ItemTypes.Armor)
        {
            ModifyStats();
        }
        SetItemIcon();
        SetItemDescription();
        SetItemValue();
        SetPrimaryWeaponEnchantAttributes();
    }

    // Checks to see which enchant is the most powerful
    public void SetPrimaryWeaponEnchantAttributes()
    {
        Enchant primary = null;
        if (enchants != null)
        {
            foreach (Enchant e in enchants)
            {
                if (e.type == Enchant.EnchantTypes.Damage_T1 || e.type == Enchant.EnchantTypes.Damage_T2 || e.type == Enchant.EnchantTypes.Damage_T3)
                {
                    if (primary != null)
                    {
                        if (e.power > primary.power)
                        {
                            primary = e;
                            if (primary != null)
                            {
                                d_Type = primary.e_dType;
                                if (do_Type == Damage_OT.Damage_OTType.Normal && e.e_doType != Damage_OT.Damage_OTType.Normal)
                                {
                                    do_Type = primary.e_doType;
                                }
                            }
                        }
                    }
                    else
                    {
                        primary = e;
                        if (primary != null)
                        {
                            d_Type = primary.e_dType;
                            if (do_Type == Damage_OT.Damage_OTType.Normal && e.e_doType != Damage_OT.Damage_OTType.Normal)
                            {
                                do_Type = primary.e_doType;
                            }
                        }
                    }
                }

            }
        }
    }
    // Modify stats on weapon
    public void ModifyStats()
    {
        if (itemType == ItemTypes.Weapon)
        {
            minDamage = (int)(minDamage * (i_mod/2));
            maxDamage = (int)(maxDamage * (i_mod/2));
            if(minDamage < 1)
            {
                minDamage = 1;
            }
            if(maxDamage < 2)
            {
                maxDamage = 2;
            }
        }
        else
        {
            armor = (int)(armor * (i_mod/2));
            if (armor < 1 && item_Id >= 301 && item_Id < 305)
            {
                armor = 1;
            }
            else if (armor < 2 && item_Id >= 305 && item_Id < 309)
            {
                armor = 2;
            }
            else if (armor < 3 && item_Id >= 309 && item_Id < 313)
            {
                armor = 3;
            }
        }
    }

    // Set Item Value
    public void SetItemValue()
    {
        if (!hasGrade && !enchantable)
        {
            
        }
        else
        {
            itemValue += Random.Range((itemLevel * 0.05f),(itemLevel * 0.35f));
        }
        if (enchantable && maxEnchants != 0)
        {
            for (int i = 0; i < enchants.Count; i++)
            {
                if (enchants[i].type != Enchant.EnchantTypes.NONE)
                {
                    itemValue += enchants[i].enchantValue;
                }
                else
                {
                    continue;
                }
            }
        }
        if (hasGrade)
        {
            itemValue = itemValue * v_mod;
            itemValue = itemValue / 4;
        }
        
    }

    public Sprite GetItemIcon()
    {
        return (icon != null)?icon:new Sprite();
    }

    // Set Item icon
    public void SetItemIcon()
    {
        if(itemType == ItemTypes.Accessory)
        {
            Accessory_Database ac = GameObject.Find("Database_Accessory").GetComponent<Accessory_Database>();
            icon = ac.GetIcon(item_Id);
        }
        else if (itemType == ItemTypes.Armor)
        {
            if(item_Id == -1)
            {
                item_Id = Random.Range(301, 395);
            }
            Armor_Database ab = GameObject.Find("Database_Armor").GetComponent<Armor_Database>();
            var abi = ab.GetIcon(item_Id, itemQuality);
            Debug.Log(item_Id);
            icon = abi.image;
            slotType = abi.Itemtype;
        }
        else if (itemType == ItemTypes.Monster)
        {
            Miscellaneous_Database mb = GameObject.Find("Database_Miscellaneous").GetComponent<Miscellaneous_Database>();
            icon = mb.GetIcon(item_Id);
        }
        else if (itemType == ItemTypes.Potion)
        {
            Potion_Database pb = GameObject.Find("Database_Potion").GetComponent<Potion_Database>();
            icon = pb.GetIcon(item_Id);
        }
        else if (itemType == ItemTypes.Quest)
        {

        }
        else if (itemType == ItemTypes.Weapon)
        {
            Weapon_Database wb = GameObject.Find("Database_Weapon").GetComponent<Weapon_Database>();
            icon = wb.GetIcon(item_Id, itemQuality);
        }
        else if (itemType == ItemTypes.Food)
        {
            Food_Database fb = GameObject.Find("Database_Food").GetComponent<Food_Database>();
            icon = fb.GetIcon(item_Id);
        }
    }

    // Initialized the Items Type
    public void InitializeType()
    {
        if (itemType == ItemTypes.Accessory)
        {
            Accessory accessory = new Accessory();
            if (item_Id == -1)
            {
                accessory.InitializeAccessory(Item_Database.GetRandomAccessory(itemLevel), this);
            }
            else
            {
                accessory.InitializeAccessory(Item_Database.GetAccessory(item_Id), this);
            }
        }
        else if (itemType == ItemTypes.Armor)
        {
            Armor armor = new Armor();
            if (item_Id == -1)
            {
                armor.InitializeArmor(Item_Database.GetRandomArmor(itemLevel), this);
            }
            else
            {
                armor.InitializeArmor(Item_Database.GetArmor(item_Id), this);
            }
        }
        else if (itemType == ItemTypes.Monster)
        {
            Miscellaneous misc = new Miscellaneous();
            if (item_Id == -1)
            {
                misc.InitializeMiscellaneous(Item_Database.GetRandomMobDrop(), this);
            }
            else
            {
                misc.InitializeMiscellaneous(Item_Database.GetMobDrop(item_Id), this);
            }
        }
        else if (itemType == ItemTypes.Potion)
        {
            Potion potion = new Potion();
            if (item_Id == -1)
            {
                potion.InitializePotion(Item_Database.GetRandomPotion(), this);
            }
            else
            {
                potion.InitializePotion(Item_Database.GetPotion(item_Id), this);
            }
        }
        else if (itemType == ItemTypes.Quest)
        {

        }
        else if (itemType == ItemTypes.Weapon)
        {

            Weapon weapon = new Weapon();
            if (item_Id == -1)
            {
                weapon.InitializeWeapon(Item_Database.GetRandomWeapon(itemLevel), this);
            }
            else
            {
                weapon.InitializeWeapon(Item_Database.GetWeapon(item_Id), this);
            }
        }
        else if (itemType == ItemTypes.Food)
        {

            Food food = new Food();
            if (item_Id == -1)
            {
                food.InitializeFood(Item_Database.GetRandomFoodDrop(), this);
            }
            else
            {
                food.InitializeFood(Item_Database.GetFoodDrop(item_Id), this);
            }
        }
    }

    // Start the process of setting enchants to item
    public void SetEnchants()
    {
        int errorCount = 0;
        if (maxEnchants != 0)
        {
            for (int i = 0; i < maxEnchants; i++)
            {
                bool runAgain = true;
                while (runAgain)
                {
                    errorCount++;
                    if(errorCount > 1000)
                    {
                        Debug.Log("ERROR :: Error Finding Enchant");
                        runAgain = false;
                    }
                    enchants[i] = new Enchant(itemType);
                    
                    if(i == 0)
                    {
                        e_type = 0;
                        enchants[i].GetNewEnchant(this,itemLevel, false);
                        e_type = -1;
                    }
                    else if (type_Damage > 0)
                    {
                        enchants[i].GetNewEnchant(this,itemLevel, true);
                    }
                    else
                    {
                        enchants[i].GetNewEnchant(this,itemLevel);
                    }

                    if (IsOkToProceedWithEnchant(enchants[i]))
                    {
                        runAgain = false;
                        ApplyEnchant(i);
                    }
                }
            }
            SetEnchantedName();
            ConsolidateEnchants();
            RejectPoorEnchants();
            GetBonusDamage();
        }
    }

    // Get Bonus Damage
    public void GetBonusDamage()
    {
        foreach(Enchant e in enchants)
        {
            if (e.type == Enchant.EnchantTypes.Damage_T1 || e.type == Enchant.EnchantTypes.Damage_T2 || e.type == Enchant.EnchantTypes.Damage_T3)
            {
                if(e.power != 0)
                {
                    bonusDamage += e.power;
                }
            }
        }
    }

    // Reject Poor Enchants
    public void RejectPoorEnchants()
    {
        foreach(Enchant e in enchants)
        {
            if(e.power == 0)
            {
                e.rejected = true;
            }
        }
    }

    // Consolidates enchants
    public void ConsolidateEnchants()
    {
        Enchant a = null;
        Enchant b = null;

        for (int i = 0; i < maxEnchants; i++)
        {
            for (int j = 0; j < maxEnchants; j++)
            {
                a = enchants[i];
                b = enchants[j];

                if (i != j)
                {
                    if ((a.GetEnchantName() == b.GetEnchantName() && (!a.consolidated && !b.consolidated)) || 
                        (a.GetEnchantName() == b.GetEnchantName() && (!a.consolidated && b.consolidated && !b.rejected)) ||
                        (a.GetEnchantName() == b.GetEnchantName() && (a.consolidated && !b.consolidated && !a.rejected)))
                    {
                        if (b.consolidated)
                        {
                            enchants[j].SetBonusStatText((a.power + b.power).ToString() + " " + a.GetEnchantName());
                            enchants[j].power = a.power + b.power;
                            enchants[j].consolidated = true;
                            enchants[i].power = 0;
                            enchants[i].consolidated = true;
                            enchants[i].SetBonusStatText("");
                            enchants[i].rejected = true;
                        }
                        else
                        {
                            enchants[i].SetBonusStatText((a.power + b.power).ToString() + " " + a.GetEnchantName());
                            enchants[i].power = a.power + b.power;
                            enchants[i].consolidated = true;
                            enchants[j].power = 0;
                            enchants[j].consolidated = true;
                            enchants[j].SetBonusStatText("");
                            enchants[j].rejected = true;
                        }      
                    }
                }
            }
        }
    }

    // Apply the enchants to the name
    public void SetEnchantedName()
    {
        // If there are no damage enchants, only put the first enchants name
        if(type_Damage == 0)
        {
            itemName = itemName + " Of " + enchants[0].GetEnchantName();
        }
        // If there is only one damage enchant, Set the damage enchant, and then the first other stats name if not damage
        else if(type_Damage == 1)
        {
            foreach(Enchant e in enchants)
            {
                if(e.type == Enchant.EnchantTypes.Damage_T1 || e.type == Enchant.EnchantTypes.Damage_T2 || e.type == Enchant.EnchantTypes.Damage_T3)
                {
                    itemName = itemName + " Of " + e.GetEnchantName(true) + " " + enchants[0].GetEnchantName();
                }
            }
        }
        else if(type_Damage == 2)
        {
            Enchant first = null;
            Enchant second = null;

            foreach (Enchant e in enchants)
            {
                if (e.type == Enchant.EnchantTypes.Damage_T1 || e.type == Enchant.EnchantTypes.Damage_T2 || e.type == Enchant.EnchantTypes.Damage_T3)
                {
                    second = e;
                }
            }

            foreach (Enchant e in enchants)
            {
                if (e.type == Enchant.EnchantTypes.Damage_T1 || e.type == Enchant.EnchantTypes.Damage_T2 || e.type == Enchant.EnchantTypes.Damage_T3)
                {
                    if(second != e)
                    {
                        first = e;
                    }
                }
            }

            itemName = itemName + " Of " + first.GetEnchantName(true) + " " + second.GetEnchantName();

        }

    }

    // Apply the Quality to the name
    public void SetQualityName(string s)
    {
        itemName = s + " " + itemName;
    }

    // Actually Change the stats of the item
    public void ApplyEnchant(int i)
    {
        strength += enchants[i].strength;
        dexterity += enchants[i].dexterity;
        intellect += enchants[i].intellect;
        endurance += enchants[i].endurance;
        vitality += enchants[i].vitality;
        agility += enchants[i].agility;
        luck += enchants[i].luck;

        p_damage += enchants[i].p_damage;

        fire_damage += enchants[i].fire_damage;
        water_damage += enchants[i].water_damage;
        ice_damage += enchants[i].ice_damage;
        thunder_damage += enchants[i].thunder_damage;
        wind_damage += enchants[i].wind_damage;
        earth_damage += enchants[i].earth_damage;
        light_damage += enchants[i].light_damage;
        dark_damage += enchants[i].dark_damage;


        soul_damage += enchants[i].soul_damage;

        bleeding_damage += enchants[i].bleeding_damage;
        poison_damage += enchants[i].poison_damage;
        aether_damage += enchants[i].aether_damage;

        p_Resist += enchants[i].p_Resist;

        fire_Resist += enchants[i].fire_Resist;
        water_Resist += enchants[i].water_Resist;
        ice_Resist += enchants[i].ice_damage;
        thunder_Resist += enchants[i].thunder_Resist;
        wind_Resist += enchants[i].wind_Resist;
        earth_Resist += enchants[i].earth_Resist;
        light_Resist += enchants[i].light_Resist;
        dark_Resist += enchants[i].dark_Resist;

        soul_Resist += enchants[i].soul_Resist;

        bleeding_Resist += enchants[i].bleeding_Resist;
        poison_Resist += enchants[i].poison_Resist;
        aether_Resist += enchants[i].aether_Resist;


        healthPoints += enchants[i].healthPoints;
        spellPoints += enchants[i].spellPoints;
        energyPoints += enchants[i].energyPoints;
        perception += enchants[i].perception;
        ferocity += enchants[i].ferocity;
        speed += enchants[i].speed;
        evasion += enchants[i].evasion;
        spirit += enchants[i].spirit;
        wisdom += enchants[i].wisdom;
        armor_Pen += enchants[i].armor_Pen;
        spell_Pen += enchants[i].spell_Pen;

        magic_chance += enchants[i].magic_chance;
        currency_percent += enchants[i].currency_percent;
        damage_percent += enchants[i].damage_percent;
        life_percent += enchants[i].life_percent;
        spell_percent += enchants[i].spell_percent;
        energy_percent += enchants[i].energy_percent;
        lifesteal_percent += enchants[i].lifesteal_percent;

    }

    // Make sure the item is within the rules of the game
    public bool IsOkToProceedWithEnchant(Enchant e)
    {

        /// Enchant Rules :
        ///
        /// MAX_PRIMARY = 1
        /// MAX_SECONDARY = 4
        /// MAX_DAMAGE_ENCHANTS = 2
        /// MAX_TERTIARY_ENCHANTS = 1
        /// MAX_RESISTANCE_ENCHANTS = 7

        /// DMG Enchant Rules
        /// 
        /// Teir 1 = [  1 - 15 ] 
        /// Teir 2 = [ 16 - 45 ] 
        /// Teir 3 = [ 45 - 70 ] 
        /// Teir 4 = [   70+   ]

        /// Resistance Rules
        /// 
        /// Teir 1 = [ 4+ ] Unlocks Core Resistances
        /// Teir 2 = [ 10+] Unlocks Special Resistances
        /// Teir 3 = [ 20+] Unlocks Elite Resistance

        type_Ones = 0;
        type_Twos = 0;
        type_Threes = 0;
        type_Damage = 0;
        type_Resist = 0;


        foreach (Enchant en in enchants)
        {
            // Enchant Counter
            if (en.type == Enchant.EnchantTypes.NONE) continue;

            if (en.type == Enchant.EnchantTypes.Primary)
            {
                type_Ones++;
            }
            else if (en.type == Enchant.EnchantTypes.Secondary)
            {
                type_Twos++;
            }
            else if (en.type == Enchant.EnchantTypes.Tertiary)
            {
                type_Threes++;
            }
            else if (en.type == Enchant.EnchantTypes.Damage_T1 ||
                     en.type == Enchant.EnchantTypes.Damage_T2 ||
                     en.type == Enchant.EnchantTypes.Damage_T3)
            {
                type_Damage++;
            }
            else if (en.type == Enchant.EnchantTypes.Resistance)
            {
                type_Resist++;
            }
            

        }

        // Enchant Rules

        if (type_Ones > 1 && e.type == Enchant.EnchantTypes.Primary)
        {
            return false;
        }
        else if (type_Twos > 4 && e.type == Enchant.EnchantTypes.Secondary)
        {
            return false;
        }
        else if (type_Threes > 1 && e.type == Enchant.EnchantTypes.Tertiary)
        {
            return false;
        }
        else if (type_Resist > 7 && e.type == Enchant.EnchantTypes.Resistance)
        {
            return false;
        }
        else if (type_Damage > 2 &&
                 (e.type == Enchant.EnchantTypes.Damage_T1 ||
                  e.type == Enchant.EnchantTypes.Damage_T2 ||
                  e.type == Enchant.EnchantTypes.Damage_T3))
        {
            return false;
        }

        // DMG Enchant Rules

        if (itemLevel < 16 && (e.type == Enchant.EnchantTypes.Damage_T2 || e.type == Enchant.EnchantTypes.Damage_T3))
        {
            return false;
        }
        else if ((itemLevel >= 16 && itemLevel < 45) && (e.type == Enchant.EnchantTypes.Damage_T3))
        {
            return false;
        }

        return true;
    }

    // Get The Stats Text
    public List<string> GetStats()
    {
        List<string> strs = new List<string>(100);

        if (itemType == ItemTypes.Weapon)
        {
            if (bonusDamage != 0)
            {
                strs.Add("DMG : (" + minDamage + " - " + maxDamage + ") + " + bonusDamage);
            }
            else
            {
                strs.Add("DMG : (" + minDamage + " - " + maxDamage + ")");
            }
        }
        else if (itemType == ItemTypes.Armor)
        {
           strs.Add("ARMOR : " + armor);
        }
        if (enchants.Count != 0)
        {
            if (enchants[0].type != Enchant.EnchantTypes.NONE && !enchants[0].rejected)
            {
                strs.Add(enchants[0].GetEnchantStatText());
            }
            if (enchants[1].type != Enchant.EnchantTypes.NONE && !enchants[1].rejected)
            {
                strs.Add(enchants[1].GetEnchantStatText());
            }
            if (enchants[2].type != Enchant.EnchantTypes.NONE && !enchants[2].rejected)
            {
                strs.Add(enchants[2].GetEnchantStatText());
            }
            if (enchants[3].type != Enchant.EnchantTypes.NONE && !enchants[3].rejected)
            {
                strs.Add(enchants[3].GetEnchantStatText());
            }
            if (enchants[4].type != Enchant.EnchantTypes.NONE && !enchants[4].rejected)
            {
                strs.Add(enchants[4].GetEnchantStatText());
            }
            if (enchants[5].type != Enchant.EnchantTypes.NONE && !enchants[5].rejected)
            {
                strs.Add(enchants[5].GetEnchantStatText());
            }
            if (enchants[6].type != Enchant.EnchantTypes.NONE && !enchants[6].rejected)
            {
                strs.Add(enchants[6].GetEnchantStatText());
            }
            if (enchants[7].type != Enchant.EnchantTypes.NONE && !enchants[7].rejected)
            {
                strs.Add(enchants[7].GetEnchantStatText());
            }
        }
        return strs;
    }

    // Gets The Dice Roll
    public int GetDiceRoll()
    {
        int roll = 0;

        if (itemLevel < 5) // Roll Max Basic
        {
            roll = RollDice(0, 95001);
        }
        else if (itemLevel >= 5 && itemLevel < 10) // Roll Fine Max
        {
            roll = RollDice(0, 99001);
        }
        else if (itemLevel >= 10 && itemLevel < 15) // Roll Great Max
        {
            roll = RollDice(0, 99501);
        }
        else if (itemLevel >= 15 && itemLevel < 20) // Roll Masterful Max
        {
            roll = RollDice(0, 99901);
        }
        else if (itemLevel >= 20 && itemLevel < 25) // Roll Epic Max
        {
            roll = RollDice(0, 99956);
        }
        else if (itemLevel >= 25 && itemLevel < 30) // Roll Legendary Max
        {
           roll = RollDice(0, 99995);
        }
        else if (itemLevel >= 30) // Roll Godlike Max
        {
            roll = RollDice(0, 100000);
        }
        
        return roll;
    }

    // Roll Da Dice
    public int RollDice(int min, int max)
    {
        if( min > max)
        {
            int temp = min;
            min = max;
            max = temp;
        }
        return Random.Range(min, max);
    }

    /// ========================================================================================================================================================================= ROLL MODS
    // Sets the quality of the item
    public ItemQualityModifiers SetQuality(bool isRandom = true, ItemQualityModifiers iqm = ItemQualityModifiers.Poor )
    {
        if (!isRandom)
        {
            return iqm;
        }
        else
        {
            int i = 0;//GetDiceRoll();
            if (!IsFindOverload())
            {
                if (qualityModifier == 0)
                {
                    i = RollDice((1 + (10 * Player_Stats.Lucky)), 100000);
                }
                else if (qualityModifier == 1)  // Box      (poor -> basic)
                {
                    i = Random.Range(50000, 95000);
                }
                else if (qualityModifier == 2)  // Wood     (poor -> great)
                {
                    i = Random.Range(60000, 99500);
                }
                else if (qualityModifier == 3)  // Bronze   (fine -> masterful)
                {
                    i = Random.Range(95000, 99900);
                }
                else if (qualityModifier == 4)  // Silver   (fine -> epic)
                {
                    i = Random.Range(95000, 99955);
                }
                else if (qualityModifier == 5)  // Gold     (fine -> legendary)
                {
                    i = Random.Range(95000, 99995);
                }
                else if (qualityModifier == 6)  // Purple   (masterful -> godlike)  
                {
                    i = Random.Range(99500, 100000);
                }
                else if (qualityModifier == 7)  // Black     (epic -> godlike)   Epic: 55%, Legendary: 40%, Godlike: 5%
                {
                    i = Random.Range(99900, 100000);
                }
            }


            //i = RollDice((1+(10 * Player_Stats.Lucky)) , 100000);
            //i = RollDice(95000,99000); // Fine
            //i = RollDice(99900, 99955); // EPIC
            //i = RollDice(99999,100000); // GODLIKE
            //Debug.Log(i);

            if (i < 70000)
            {
                iqm = ItemQualityModifiers.Poor;        // 70%
                SetQualityName("Poor");
            }
            else if (i >= 70000 && i < 95000)
            {
                iqm = ItemQualityModifiers.Basic;       // 25%
                SetQualityName("Basic");
            }
            else if (i >= 95000 && i < 99000)
            {
                iqm = ItemQualityModifiers.Fine;        // 04%
                SetQualityName("Fine");
            }
            else if (i >= 99000 && i < 99500)
            {
                iqm = ItemQualityModifiers.Great;       // 0.50%
                SetQualityName("Great");
            }
            else if (i >= 99500 && i < 99900)
            {
                iqm = ItemQualityModifiers.Masterful;   // 0.40%
                SetQualityName("Masterful");
            }
            else if (i >= 99900 && i < 99955)
            {
                iqm = ItemQualityModifiers.Epic;        // 0.055%
                SetQualityName("Epic");
            }
            else if (i >= 99955 && i < 99995)
            {
                iqm = ItemQualityModifiers.Legendary;   // 0.04%
                SetQualityName("Legendary");
            }
            else if (i >= 99995 && i < 100000)
            {
                iqm = ItemQualityModifiers.Godlike;     // 0.005%
                SetQualityName("Godlike");
            }
            else
            {
                iqm = ItemQualityModifiers.Poor;        // Whoops
                SetQualityName("Poor");
            }
            return iqm;
        }
    }

    bool IsFindOverload()
    {
        return (1 + (10 * Player_Stats.Lucky)) >= 99999;
    }

    // Sets the stats of the item based on quality
    public void SetQualityStats()
    {
        if (itemQuality == ItemQualityModifiers.Poor)
        {
            maxEnchants = 0; // NONE
            v_mod = 0.75f;
            i_mod = 0.5f;
        }
        else if (itemQuality == ItemQualityModifiers.Basic)
        {
            maxEnchants = 1; // 1 x Primary Stat
            v_mod = 1;
            i_mod = 1;
        }
        else if (itemQuality == ItemQualityModifiers.Fine)
        {
            maxEnchants = 2; // 1 x Primary Stat, 1 x Any
            v_mod = 2f;
            i_mod = 1.1f;
        }
        else if (itemQuality == ItemQualityModifiers.Great)
        {
            maxEnchants = 3; // 1 x Primary Stat, 1 x Secondary Stat, 1 x Any
            v_mod = 4f;
            i_mod = 1.2f;
        }
        else if (itemQuality == ItemQualityModifiers.Masterful)
        {
            maxEnchants = 4; // 1 x Primary Stat, 1 x Secondary Stat, 2 x Any
            v_mod = 8f;
            i_mod = 1.3f;
        }
        else if (itemQuality == ItemQualityModifiers.Epic)
        {
            maxEnchants = 5; // 1 x Primary Stat, 1 x Secondary Stat, 1 x Damage Stat, 2 x Any
            v_mod = 16f;
            i_mod = Random.Range(1.4f,1.9f);
        }
        else if (itemQuality == ItemQualityModifiers.Legendary)
        {
            maxEnchants = 6; // 2 x Primary Stat, 1 x Secondary Stat, 1 x Damage Stat, 2 x Any
            v_mod = 32f;
            i_mod = Random.Range(2f, 2.8f);
        }
        else if (itemQuality == ItemQualityModifiers.Godlike)
        {
            maxEnchants = 8; // 2 x Primary Stat, 2 x Secondary Stat, 2 x Damage Stat, 2 x Any
            v_mod = 64f;
            i_mod = Random.Range(3f, 3.8f);
        }
    }

    public void SetEnchantTypeNum(int i)
    {
        e_type = i;
    }
    public void SetSpecificEnchantTypeNum(int i)
    {
        se_type = i;
    }

    public int GetEnchantTypeNum()
    {
        return e_type;
    }
    public int GetSpecificEnchantTypeNum()
    {
        return se_type;
    }
}
