using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class PickupScript : MonoBehaviour
{
    [SerializeField] private float opacity = 0;
    [SerializeField] private float interactWaitForSeconds;
    private float repetitionRate = 0.1f;
    private float nextRepetition = 0f;
    private float opacityEichRepetition;

    [SerializeField] private KeyCode interactKey = KeyCode.E;
    private Color newOpacity;

    private GameObject interactPromptGO;
    private TextMeshProUGUI interactPromptText;
    [SerializeField] private Image interactProgressImg;

    private InventoryScript inventoryScript;

    // Start is called before the first frame update
    void Start()
    {
        interactPromptGO = GameObject.Find("SingleKey2");
        interactPromptText = interactPromptGO.GetComponentInChildren<TextMeshProUGUI>();
        interactPromptText.text = interactKey.ToString();
        inventoryScript = GameObject.Find("SpelSjef").GetComponent<InventoryScript>();
        newOpacity = interactProgressImg.GetComponent<Image>().color;

        interactPromptGO.SetActive(false);
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

            opacity = 0;
            newOpacity = interactProgressImg.GetComponent<Image>().color;
            newOpacity.a = opacity;
            interactProgressImg.color = newOpacity;

            if (!itemToPickUp.interactPickup)
            {
                //--------- On collision pickup ----------
                AddItemToInventoryList(itemToPickUp, other);
                //----------------------------------------
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "PickupItem")
        {
            interactPromptGO.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        ItemClass itemToPickUp;
        if (other.transform.tag == "PickupItem")
        {
            itemToPickUp = other.transform.GetComponent<ItemClass>();

            if (itemToPickUp.interactPickup)
            {
                //---------- Interact pickup ----------

                interactPromptGO.SetActive(true);

                if (itemToPickUp.holdInteract)
                {
                    //---------- Hold interact ----------
                    if (Input.GetKey(interactKey))
                    {
                        opacityEichRepetition = (1 / itemToPickUp.holdInteractLenghtSec) * repetitionRate;
                        HoldPickupHeld( itemToPickUp.holdInteractLenghtSec, itemToPickUp, other);
                    }

                    if (opacity <= 1 && opacity > 0)
                    {
                        HoldPickupReleased(itemToPickUp.holdInteractLenghtSec, itemToPickUp);
                    }

                    //-----------------------------------
                }
                else
                {
                    //---------- Instant interact ----------
                    if (Input.GetKeyDown(interactKey))
                    {
                        AddItemToInventoryList(itemToPickUp, other);
                        interactPromptGO.SetActive(false);
                        interactPromptGO.SetActive(false);
                    }
                    //--------------------------------------
                }

                //------------------------------------
            }
        }

    }

    

    private void AddItemToInventoryList(ItemClass itemToPickUp, Collider other)
    {
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
    }
    
    private void HoldPickupHeld(float holdTimeSeconds, ItemClass itemToPickUp, Collider other)
    {

        if (Time.time >= nextRepetition)
        {
            nextRepetition = Time.time + repetitionRate - 0.01f;

            newOpacity = interactProgressImg.GetComponent<Image>().color;

            opacity += opacityEichRepetition;
            newOpacity.a = opacity;

            if (opacity <= 1)
                interactProgressImg.color = newOpacity;


            if (opacity >= 1)
            {
                AddItemToInventoryList(itemToPickUp, other);
                interactPromptGO.SetActive(false);
            }
        }
        
    }

    private void HoldPickupReleased(float holdTimeSeconds, ItemClass itemToPickUp)
    {
        if (Time.time >= nextRepetition)
        {
            nextRepetition = Time.time + repetitionRate - 0.01f;

            opacity -= opacityEichRepetition;
            newOpacity.a = opacity;

            if (opacity <= 1)
                interactProgressImg.color = newOpacity;

        }
    }


}
