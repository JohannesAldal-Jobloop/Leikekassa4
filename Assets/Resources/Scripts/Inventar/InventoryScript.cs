using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{
    private int indexInList = 0;
    public int listCount;
    public int scrollViewContentActive;
    private int itemPrefabIndex;

    [HideInInspector] public string[] inventoryCategoryTags = new string[3];

    public bool inventoryOpen = false;
    public bool weaponsShown = false;
    public bool armorShown = false;
    public bool itemsShown = false;

    //private GameObject buttonClicked;

    public GameObject itemPrefab;

    private GameObject[] scrollViewContent = new GameObject[3];

    private GameObject weaponInventory;
    private GameObject armorInventory;
    private GameObject itemsInventory;

    private Image itemPreviewImg;
    private TextMeshProUGUI itemIndex;

    private TextMeshProUGUI itemDescrName;
    private  Image          itemDescrImg;
    private TextMeshProUGUI itemDescrDescription;
    private TextMeshProUGUI itemDescrStats;

    public List<GameObject> itemsShownInInventory = new List<GameObject>();

    public List<ItemClass> weaponsInInvetoryList = new List<ItemClass>();
    public List<ItemClass> armorInInvetoryList = new List<ItemClass>();
    public List<ItemClass> itemsInInvetoryList = new List<ItemClass>();

    // Start is called before the first frame update
    void Start()
    {
        // Finds all the requerd GameObjects and components.
        FindGameObjects_Components();

        inventoryCategoryTags[0] = "weapon";
        inventoryCategoryTags[1] = "armor";
        inventoryCategoryTags[2] = "item";
        

        // Opens the weapon inventory by default.
        scrollViewContentActive = 0;
        weaponInventory.SetActive(true);
        armorInventory.SetActive(false);
        itemsInventory.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if the player presses I and opens the inventory
        // and shows all items in their respective places.
        if(Input.GetKeyUp(KeyCode.I) && inventoryOpen == false)
        {
            // Sets the bool inventoryOpen to make SpelerUISkript show the inventory
            inventoryOpen = true;

            // Shows all the items the player has.
            ShowItems(weaponsInInvetoryList, scrollViewContent[0]);
            ShowItems(armorInInvetoryList, scrollViewContent[1]);
            ShowItems(itemsInInvetoryList, scrollViewContent[2]);
            
        }
        else if(Input.GetKeyUp(KeyCode.I) && inventoryOpen == true)
        {
            // Sets the bool inventoryOpen to make SpelerUISkript hide the inventory
            inventoryOpen = false;

            // Deletes all the inventory preFabs for the items the player has.
            DestroyItemPrefabs(itemsShownInInventory);
        }
    }

    // Function that defines all the variables that needs stuff from the hierarchy.
    private void FindGameObjects_Components()
    {
        scrollViewContent[0] = GameObject.Find("ContentWeapons");
        scrollViewContent[1] = GameObject.Find("ContentArmor");
        scrollViewContent[2] = GameObject.Find("ContentItems");

        weaponInventory = GameObject.Find("ScrollViewWeapons");
        armorInventory = GameObject.Find("ScrollViewArmor");
        itemsInventory = GameObject.Find("ScrollViewItems");

        itemDescrName = GameObject.Find("ItemName_Description").GetComponent<TextMeshProUGUI>();
        itemDescrImg = GameObject.Find("ItemImg_Description").GetComponent<Image>();
        itemDescrDescription = GameObject.Find("ItemDescriptionText_Description").GetComponent<TextMeshProUGUI>();
        itemDescrStats = GameObject.Find("ItemStats_Description").GetComponent<TextMeshProUGUI>();
    }

    // Functions for the buttons in the inventory UI.
    // Changes between the difrent item type inventories.
    public void ShowWeaponsInInventory()
    {
        scrollViewContentActive = 0;
        weaponInventory.SetActive(true);
        armorInventory.SetActive(false);
        itemsInventory.SetActive(false);
    }
    public void ShowArmorInInventory()
    {
        scrollViewContentActive = 1;
        weaponInventory.SetActive(false);
        armorInventory.SetActive(true);
        itemsInventory.SetActive(false);
    }
    public void ShowItemsInInventory()
    {
        scrollViewContentActive = 2;
        weaponInventory.SetActive(false);
        armorInventory.SetActive(false);
        itemsInventory.SetActive(true);
    }

    /// <summary>
    /// Function that shows the items from a ItemClass list 
    /// as children off the inventoryParent
    /// </summary>
    /// <param name="itemList"> The liste off items for showing. </param>
    /// <param name="inventoryParent"> The parent GameObject for the items </param>
    public void ShowItems(List<ItemClass> itemList, GameObject inventoryParent)
    {
        // A forech loop that goes thru all teh items in itemList
        // and Instantiates a itemPrefab with all the correct item info
        // as a child of inventoryParent.
        indexInList = 0;
        foreach (ItemClass item in itemList)
        {
            itemPreviewImg = null;

            // Instantiates the prefab and sets its name to the name of the item
            GameObject newItem = Instantiate(itemPrefab, inventoryParent.transform);
            newItem.name = item.itemName;

            // Ads the newItem to the list weaponsShownInInventory
            // for all the prefabs that shows items.
            itemsShownInInventory.Add(newItem);

            // Finds the imgae and index text from the newly instantiated prefab.
            itemPreviewImg = newItem.transform.Find("ItemImage").GetComponent<Image>();
            itemIndex = newItem.transform.Find("ItemIndexText").GetComponent<TextMeshProUGUI>();

            // Sets the preview image for the newItem
            // and the index off the itemclass the info comes from.
            itemPreviewImg.sprite = item.itemPreviewImage;
            itemIndex.text = indexInList.ToString();

            // Gets the button component of newItem
            Button newItemButton = newItem.GetComponent<Button>();

            // Sets the newItemButton to execute the function
            // ShowItemDescription when clicked.
            if (item.itemTags[0] == "weapon")
            {
                newItemButton.onClick.AddListener(ShowItemDescription);
            }else if(item.itemTags[0] == "armor")
            {
                newItemButton.onClick.AddListener(ShowItemDescription);
            }else if(item.itemTags[0] == "item")
            {
                newItemButton.onClick.AddListener(ShowItemDescription);
            }
           
            // Ups the index of what ItemClass in itemList the infor comes from.
            indexInList++;
        }

        
        weaponsShown = true;
    }

    // Function that shows the description of the item clicked.
    private void ShowItemDescription()
    {
        // Finds the text of the itemindex text.
        string indexString = itemIndex.text.ToString();

        // Finds the correct itemclass the info came from
        // by parsing the indexString into an int.
        ItemClass itemClass = weaponsInInvetoryList[int.Parse(indexString)];

        // Sets all the info needed into their respective UI elements.
        itemDescrName.text = itemClass.itemName;
        itemDescrImg.sprite = itemClass.itemDescriptionImage;
        itemDescrDescription.text = itemClass.itemDescription;

        itemDescrStats.text = 
            "Damage: " + itemClass.damagePhysical + "<br>" +
            "Damage: " + itemClass.damageMagic + "<br>" +
            "Damage: " + itemClass.damageFire + "<br>" +
            "Damage: " + itemClass.damageSpectral ;
    }

    /// <summary>
    /// Destroyes all the GameObjects in itemsToDestroyList.
    /// Then removes everything from itemsToDestroyList to have an empty list.
    /// </summary>
    /// <param name="itemsToDestroyList"> List off the GameObjects that will be destroyed </param>
    private void DestroyItemPrefabs(List<GameObject> itemsToDestroyList)
    {
        // gets the number of items in the itemsToDestroyList list
        listCount = itemsToDestroyList.Count;

        // Destroyes all GameObjects in itemsToDestroyList
        for (int i = 0; i < listCount; i++)
        {
            Destroy(itemsToDestroyList[i]);
        }

        // Removes everything from itemsToDestroyList to have an empty list.
        for (int i = 0; i < listCount; i++)
        {
            itemsToDestroyList.Remove(itemsToDestroyList[0]);
        }

        
        weaponsShown = false;
    }
}
