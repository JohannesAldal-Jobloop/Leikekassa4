using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    public bool interactPickup = false;

    InventoryScript inventoryScript;

    // Start is called before the first frame update
    void Start()
    {
        inventoryScript = GameObject.Find("SpelSjef").GetComponent<InventoryScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    
    private void OnCollisionEnter(Collision collision)
    {
        ItemClass itemToPickUp;

        if(collision.transform.tag == "PickupItem")
        {
            itemToPickUp = collision.transform.GetComponent<ItemClass>();

            if(itemToPickUp.itemTags[0] == inventoryScript.inventoryCategoryTags[0])
            {
                // weapons
                inventoryScript.weaponsInInvetoryList.Add(itemToPickUp);

                collision.gameObject.SetActive(false);

            }
            else if(itemToPickUp.itemTags[0] == inventoryScript.inventoryCategoryTags[1])
            {

                // armor
                inventoryScript.armorInInvetoryList.Add(itemToPickUp);

                collision.gameObject.SetActive(false);
            }
            else if(itemToPickUp.itemTags[0] == inventoryScript.inventoryCategoryTags[2])
            {
                // items
                inventoryScript.itemsInInvetoryList.Add(itemToPickUp);

                collision.gameObject.SetActive(false);
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        ItemClass itemToPickUp;

        if (other.transform.tag == "PickupItem")
        {

            itemToPickUp = other.transform.GetComponent<ItemClass>();

            if (interactPickup)
            {
                //--------- Interact pickup ----------



                //------------------------------------
            }
            else
            {
                //--------- On collision pickup ----------

                // Checks what type of item itemToPickUp and
                // adds the item to the correct inventory list.
                if (itemToPickUp.itemTags[0] == inventoryScript.inventoryCategoryTags[0])
                {
                    // weapons
                    inventoryScript.weaponsInInvetoryList.Add(itemToPickUp);

                    other.gameObject.SetActive(false);

                }
                else if (itemToPickUp.itemTags[0] == inventoryScript.inventoryCategoryTags[1])
                {

                    // armor
                    inventoryScript.armorInInvetoryList.Add(itemToPickUp);

                    other.gameObject.SetActive(false);
                }
                else if (itemToPickUp.itemTags[0] == inventoryScript.inventoryCategoryTags[2])
                {
                    // items
                    inventoryScript.itemsInInvetoryList.Add(itemToPickUp);

                    other.gameObject.SetActive(false);
                }
                //----------------------------------------
            }


        }
    }

}
