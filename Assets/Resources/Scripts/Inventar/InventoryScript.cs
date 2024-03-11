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

    public GameObject itemPrefab;

    private GameObject weaponInventory;
    private GameObject armorInventory;
    private GameObject itemsInventory;

    public List<ItemClass> weaponsInInvetoryList = new List<ItemClass>();
    public List<ItemClass> armorInInvetoryList = new List<ItemClass>();
    public List<ItemClass> itemsInInvetoryList = new List<ItemClass>();

    // Start is called before the first frame update
    void Start()
    {
        weaponInventory = GameObject.Find("ContentWeapons");
        armorInventory = GameObject.Find("ArmorPanel");
        itemsInventory = GameObject.Find("ItemsPanel");

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
        foreach (ItemClass item in itemList)
        {
            TextMeshProUGUI newItemNamePreFabText = null;
            Image newItemImagePreFab = null;
            TextMeshProUGUI newItemValuePreFabText = null;

            GameObject newItem = Instantiate(itemPrefab, inventoryParent.transform);
            newItem.name = item.itemName;

            newItemNamePreFabText = GameObject.Find(newItem.name + "/ItemNameTextBox").GetComponent<TextMeshProUGUI>();
            newItemImagePreFab = GameObject.Find(newItem.name + "/ItemImage").GetComponent<Image>();
            newItemValuePreFabText = GameObject.Find(newItem.name + "/ItemValueTextBox").GetComponent<TextMeshProUGUI>();

            newItemNamePreFabText.text = item.itemName;
            newItemImagePreFab.sprite = item.itemImage;
            newItemValuePreFabText.text = item.itemValue.ToString();

            // Flytte alle items i eit rutenett enten etter kvar er instaniata eller etter alle er.
        }
    }

}
