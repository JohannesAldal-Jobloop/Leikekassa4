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
    private float repetitionRate = 0.05f;
    private float nextRepetition = 0f;
    private float holdActualTimeTesting = 0f;

    private bool holdingteract = false;

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
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        holdActualTimeTesting = Time.time;
                    }

                    //---------- Hold interact ----------
                    if (Input.GetKey(interactKey))
                    {
                        holdingteract = true;
                        HoldPickupHeld( itemToPickUp.holdInteractLenghtSec, itemToPickUp, other);
                        //StartCoroutine(HoldPickup(itemToPickUp.holdInteractLenghtSec, itemToPickUp, other));
                    }
                    else 
                    {
                       holdingteract = false;
                    }

                    if (!holdingteract && opacity <= 1 && opacity > 0)
                    {
                        //HoldPickupReleased(itemToPickUp.holdInteractLenghtSec, itemToPickUp);
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

    private IEnumerator HoldPickup(float holdTimeSeconds, ItemClass itemToPickUp, Collider other)
    {
        float opacityEichSec = 10 / holdTimeSeconds;

        for(int i = 0; i < holdTimeSeconds; i++)
        {
            newOpacity = interactProgressImg.GetComponent<Image>().color;

            opacity += 0.2f;
            newOpacity.a = opacity;
            Debug.Log(newOpacity);

            if (opacity <= 1)
                interactProgressImg.color = newOpacity;

            Debug.Log(i);
            yield return new WaitForSeconds(1);
        }

        AddItemToInventoryList(itemToPickUp, other);
        interactPromptGO.SetActive(false);

    }
    
    private void HoldPickupHeld(float holdTimeSeconds, ItemClass itemToPickUp, Collider other)
    {
        float opacityEichSec = (1 / holdTimeSeconds) * repetitionRate;
        if (Time.time > nextRepetition)
        {
            nextRepetition = Time.time + repetitionRate;
            Debug.Log($"Time.time: {Time.time}.         nextRepetition: {nextRepetition}.       Difrence: {nextRepetition-Time.time}");

            newOpacity = interactProgressImg.GetComponent<Image>().color;

            opacity += opacityEichSec;
            newOpacity.a = opacity;
            //Debug.Log(newOpacity);

            if (opacity <= 1)
                interactProgressImg.color = newOpacity;


            if (opacity >= 1)
            {
                holdActualTimeTesting -= Time.time;
                Debug.Log($"Hold time: {holdActualTimeTesting}");
                AddItemToInventoryList(itemToPickUp, other);
                interactPromptGO.SetActive(false);
            }
        }
        
    }

    private void HoldPickupReleased(float holdTimeSeconds, ItemClass itemToPickUp)
    {
        float opacityEichSec = holdTimeSeconds / 100;
        float repetitionRate = 1f;
        float nextRepetition = 0f;

        if (Time.time >= nextRepetition)
        {
            nextRepetition = Time.time + 1 / repetitionRate;
            Debug.Log($"Time.time: {Time.time}.         nextRepetition: {nextRepetition}.       Difrence: {nextRepetition - Time.time}");

            Color newOpacity = interactProgressImg.GetComponent<Image>().color;
            opacity -= opacityEichSec;
            newOpacity.a = opacity;
            Debug.Log(newOpacity);

            if (opacity <= 1)
                interactProgressImg.color = newOpacity;

        }
    }


}
