using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
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

    public GameObject itemPrefab;

    private GameObject[] scrollViewContent = new GameObject[3];

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

    PausSpel pausSpel;

    // Start is called before the first frame update
    void Start()
    {
        // Finds all the requerd GameObjects and components.
        FindGameObjects_Components();

        inventoryCategoryTags[0] = "weapon";
        inventoryCategoryTags[1] = "armor";
        inventoryCategoryTags[2] = "item";
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if the player presses I and opens the inventory
        // and shows all items in their respective places.
        if(Input.GetKeyUp(KeyCode.I) && inventoryOpen == false && !pausSpel.erPausa)
        {
            // Sets the bool inventoryOpen to make SpelerUISkript show the inventory
            inventoryOpen = true;

            // Shows all the items the player has.
            ShowItems(weaponsInInvetoryList, scrollViewContent[0]);
            ShowItems(armorInInvetoryList, scrollViewContent[1]);
            ShowItems(itemsInInvetoryList, scrollViewContent[2]);

            Time.timeScale = 0;
        }
        else if(inventoryOpen == true)
        {
            if(Input.GetKeyUp(KeyCode.I) || Input.GetKeyUp(KeyCode.Escape))
            {
                Time.timeScale = 1.0f;

                // Sets the bool inventoryOpen to make SpelerUISkript hide the inventory
                inventoryOpen = false;

                // Deletes all the inventory preFabs for the items the player has.
                DestroyItemPrefabs(itemsShownInInventory);
            }
            
        }
    }

    // Function that defines all the variables that needs stuff from the hierarchy.
    private void FindGameObjects_Components()
    {
        scrollViewContent[0] = GameObject.Find("ContentWeapons");
        scrollViewContent[1] = GameObject.Find("ContentArmor");
        scrollViewContent[2] = GameObject.Find("ContentItems");

        itemDescrName = GameObject.Find("ItemName_Description").GetComponent<TextMeshProUGUI>();
        itemDescrImg = GameObject.Find("ItemImg_Description").GetComponent<Image>();
        itemDescrDescription = GameObject.Find("ItemDescriptionText_Description").GetComponent<TextMeshProUGUI>();
        itemDescrStats = GameObject.Find("ItemStats_Description").GetComponent<TextMeshProUGUI>();

        pausSpel = GameObject.Find("SpelSjef").GetComponent<PausSpel>();
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

            // Gets the button component of newItem
            Button newItemButton = newItem.GetComponent<Button>();

            // Sets the newItemButton to execute the function
            // ShowItemDescription when clicked.
            if (item.itemTags[0] == "weapon")
            {
                newItemButton.onClick.AddListener(delegate { ShowItemDescription(weaponsInInvetoryList, newItem.transform.Find("ItemIndexText")); });
            }
            else if (item.itemTags[0] == "armor")
            {
                newItemButton.onClick.AddListener(delegate { ShowItemDescription(armorInInvetoryList, newItem.transform.Find("ItemIndexText")); });
            }
            else if (item.itemTags[0] == "item")
            {
                newItemButton.onClick.AddListener(delegate { ShowItemDescription(itemsInInvetoryList, newItem.transform.Find("ItemIndexText")); });
            }

            // Sets the preview image for the newItem
            // and the index off the itemclass the info comes from.
            itemPreviewImg.sprite = item.itemPreviewImage;
            itemIndex.text = indexInList.ToString();

            // Ups the index of what ItemClass in itemList the infor comes from.
            indexInList++;
        }

        
        weaponsShown = true;
    }

    // Function that shows the description of the item clicked.
    /// <summary>
    /// Function that showes the description of the item you cliked in the innentory.
    /// </summary>
    /// <param name="itemClassList"> The list of itemclasses the item is part off </param>
    /// <param name="indexText"> the transform of the GameObject that contains the
    ///                          index of the item in the itemClassList </param>
    private void ShowItemDescription(List<ItemClass> itemClassList, Transform indexText)
    {
        // Finds the TexMeshProUGUI from the transform indexText.
        TextMeshProUGUI indexTextMeshPro = indexText.GetComponent<TextMeshProUGUI>();
        string indexString = indexTextMeshPro.text.ToString();

        // Finds the correct itemclass the info came from
        // by parsing the indexString into an int.
        ItemClass itemClass = itemClassList[int.Parse(indexString)];

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
