using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{
    public bool inventortOpen = false;

    private GameObject weaponInventory;
    private GameObject armorInventory;
    private GameObject itemsInventory;

    public TextMeshProUGUI weaponNameShowTest;
    public Image weaponImageShowTest;
    public TextMeshProUGUI weaponValueShowTest;

    public List<ItemClass> weaponsInInvetoryList = new List<ItemClass>();
    public List<ItemClass> armorInInvetoryList = new List<ItemClass>();
    public List<ItemClass> itemsInInvetoryList = new List<ItemClass>();

    // Start is called before the first frame update
    void Start()
    {
        weaponInventory = GameObject.Find("Weapons");
        armorInventory = GameObject.Find("Armor");
        itemsInventory = GameObject.Find("Items");

        weaponInventory.SetActive(false);
        armorInventory.SetActive(false);
        itemsInventory.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I) && inventortOpen == false)
        {
            inventortOpen = true;
        }
        else if(Input.GetKeyDown(KeyCode.I) && inventortOpen == true)
        {
            inventortOpen = false;
        }
    }

    public void ShowWeaponsInInventory()
    {
        weaponInventory.SetActive(true);
        armorInventory.SetActive(false);
        itemsInventory.SetActive(false);

        weaponNameShowTest.text = weaponsInInvetoryList[0].itemName;
        weaponImageShowTest.sprite = weaponsInInvetoryList[0].itemImage;
        weaponValueShowTest.text = weaponsInInvetoryList[0].itemValue.ToString();
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

}
