using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{
    public bool inventoryOpen = false;
    public bool weaponsShown = false;
    public bool armorShown = false;
    public bool itemsShown = false;

    private int indexInList = 0;

    private GameObject buttonClicked;

    public GameObject itemPrefab;

    private GameObject weaponInventory;
    private GameObject armorInventory;
    private GameObject itemsInventory;

    private Image itemPreviewImg;
    private TextMeshProUGUI itemIndex;

    private TextMeshProUGUI itemDescrName;
    private  Image           itemDescrImg;
    private TextMeshProUGUI itemDescrDescription;
    private TextMeshProUGUI itemDescrStats;
    

    public List<ItemClass> weaponsInInvetoryList = new List<ItemClass>();
    public List<ItemClass> armorInInvetoryList = new List<ItemClass>();
    public List<ItemClass> itemsInInvetoryList = new List<ItemClass>();

    // Start is called before the first frame update
    void Start()
    {
        weaponInventory = GameObject.Find("ContentWeapons");
        armorInventory = GameObject.Find("ArmorPanel");
        itemsInventory = GameObject.Find("ItemsPanel");

        itemDescrName = GameObject.Find("ItemName_Description").GetComponent<TextMeshProUGUI>();
        itemDescrImg = GameObject.Find("ItemImg_Description").GetComponent<Image>();
        itemDescrDescription = GameObject.Find("ItemDescriptionText_Description").GetComponent<TextMeshProUGUI>();
        itemDescrStats = GameObject.Find("ItemStats_Description").GetComponent<TextMeshProUGUI>();

        weaponInventory.SetActive(false);
        armorInventory.SetActive(false);
        itemsInventory.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I) && inventoryOpen == false)
        {
            inventoryOpen = true;
        }
        else if(Input.GetKeyDown(KeyCode.I) && inventoryOpen == true)
        {
            inventoryOpen = false;
        }
    }

    public void ShowWeaponsInInventory()
    {
        weaponInventory.SetActive(true);
        armorInventory.SetActive(false);
        itemsInventory.SetActive(false);

        if (!weaponsShown)
        {
            ShowItems(weaponsInInvetoryList, weaponInventory);
            weaponsShown = true;
        }
    }
    public void ShowArmorInInventory()
    {
        weaponInventory.SetActive(false);
        armorInventory.SetActive(true);
        itemsInventory.SetActive(false);
    }
    public void ShowItemsInInventory()
    {
        weaponInventory.SetActive(false);
        armorInventory.SetActive(false);
        itemsInventory.SetActive(true);
    }

    public void ShowItems(List<ItemClass> itemList, GameObject inventoryParent)
    {
        indexInList = 0;
        foreach (ItemClass item in itemList)
        {
            itemPreviewImg = null;

            GameObject newItem = Instantiate(itemPrefab, inventoryParent.transform);
            newItem.name = item.itemName;

            itemPreviewImg = newItem.transform.Find("ItemImage").GetComponent<Image>();
            itemIndex = newItem.transform.Find("ItemIndexText").GetComponent<TextMeshProUGUI>();

            itemPreviewImg.sprite = item.itemPreviewImage;
            itemIndex.text = indexInList.ToString();


            Button newItemButton = newItem.GetComponent<Button>();


            newItemButton.onClick.AddListener(ShowItemDescription);
            indexInList++;
        }
    }

    public void ShowItemDescription()
    {
        string indexString = itemIndex.text.ToString();

        ItemClass itemClass = weaponsInInvetoryList[int.Parse(indexString)];

        itemDescrName.text = itemClass.itemName;
        itemDescrImg.sprite = itemClass.itemDescriptionImage;
        itemDescrDescription.text = itemClass.itemDescription;
        itemDescrStats.text = 
            "Damage: " + itemClass.damagePhysical + "<br>" +
            "Damage: " + itemClass.damageMagic + "<br>" +
            "Damage: " + itemClass.damageFire + "<br>" +
            "Damage: " + itemClass.damageSpectral ;
    }
}
