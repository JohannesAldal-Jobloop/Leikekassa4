using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemClass : MonoBehaviour
{
    public bool interactPickup = false;
    public string[] itemTags = { };
    public string itemName;
    public string itemDescription;
    public Sprite itemPreviewImage;
    public Sprite itemDescriptionImage;
    public int itemValue;
    public int damagePhysical   = 0;
    public int damageMagic      = 0;
    public int damageFire       = 0;
    public int damageSpectral   = 0;

    private InventoryScript inventoryScript;

    // Start is called before the first frame update
    void Start()
    {
        inventoryScript = GameObject.Find("SpelSjef").GetComponent<InventoryScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.name == "SpelerFPS")
    //    {
    //        inventoryScript.weaponsInInvetoryList.Add(this);
    //        gameObject.SetActive(false);
    //    }
    //}

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.name == "SpelerFPS")
    //    {
    //        inventoryScript.weaponsInInvetoryList.Add(this);
    //        gameObject.SetActive(false);
    //    }
    //}
}
