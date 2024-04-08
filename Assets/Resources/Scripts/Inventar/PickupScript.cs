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
    private float TestSeconds = 5;
    private float TestAmountGoal = 1;
    private float TestAmountCounter = 0;
    private float nextRepetitionMinus = 0.01f;
    private float TestTime;
    private float TestValueEichRepetition;
    private bool TestComplete;

    [SerializeField] private float opacity = 0;
    [SerializeField] private float interactWaitForSeconds;
    private float repetitionRate = 0.1f;
    private float nextRepetition = 0f;
    private float opacityEichRepetition;
    private Color newOpacity;

    [SerializeField] private GameObject interactPromptGO;
    [SerializeField] private TextMeshProUGUI interactPromptText;
    [SerializeField] private Image interactProgressImg;

    private InventoryScript inventoryScript;
    private KeyBindsClass keyBindsClass;

    // Start is called before the first frame update
    void Start()
    {
        // Gets all the recuired components.
        inventoryScript = GameObject.Find("SpelSjef").GetComponent<InventoryScript>();
        keyBindsClass = GameObject.Find("SpelSjef").GetComponent<KeyBindsClass>();
        interactPromptText.text = keyBindsClass.interactKeyCode.ToString();
        newOpacity = interactProgressImg.GetComponent<Image>().color;

        // Disables the interact prompt.
        interactPromptGO.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        ItemClass itemToPickUp;

        // If the trigger thats enterd is an item,
        // set the opacity of the interact promt image to 0.
        // And if the item has interactPickup set to false
        // the item will be picked up on trigger enter.
        if (other.transform.tag == "PickupItem")
        {
            // Finds the ItemClass on the GameObject collided with.
            itemToPickUp = other.transform.GetComponent<ItemClass>();

            // Sets the opacity of interact promt image to 0.
            opacity = 0;
            newOpacity.a = opacity;
            interactProgressImg.color = newOpacity;

            // Checks if the item has interactPickup set to false.
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
        // If the trigger thats exited is an item, disable the interact prompt.
        if (other.transform.tag == "PickupItem")
        {
            interactPromptGO.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        ItemClass itemToPickUp;

        // Checks if other has tag "PickupItem"
        // since only GameObjects with that tag work with this code.
        if (other.transform.tag == "PickupItem")
        {
            // Finds the ItemClass on the GameObject collided with.
            itemToPickUp = other.transform.GetComponent<ItemClass>();

            // Checks if the item should be picked up with an interaction.
            if (itemToPickUp.interactPickup)
            {
                //---------- Interact pickup ----------

                interactPromptGO.SetActive(true);

                if (itemToPickUp.holdInteract)
                {
                    //---------- Hold interact ----------
                    if (Input.GetKey(keyBindsClass.interactKeyCode))
                    {
                        // Calculates how much the opacity needs to be changed eich repetition.
                        opacityEichRepetition = (1 / itemToPickUp.holdInteractLenghtSec) * repetitionRate;

                        // Starts the HoldPickupHeld() with all nessesery values.
                        HoldPickupHeld( itemToPickUp.holdInteractLenghtSec, itemToPickUp, other);
                    }
                    // If interactKey is not held and opacity is less than 1
                    // and more than 0 reduce opacity with same speed.
                    else if (opacity < 1 && opacity > 0)
                    {
                        HoldPickupReleased();
                    }

                    //-----------------------------------
                }
                else
                {
                    //---------- Instant interact ----------
                    if (Input.GetKeyDown(keyBindsClass.interactKeyCode))
                    {
                        // Adds itemToPickUp to inventory and makes the interact prompt inviseble.
                        AddItemToInventoryList(itemToPickUp, other);
                        interactPromptGO.SetActive(false);
                    }
                    //--------------------------------------
                }

                //------------------------------------
            }
        }

    }


    /// <summary>
    /// Adds the ItemClass itemToPickUp into the correct inventory
    /// based on its tags. And disables its GameObject.
    /// </summary>
    /// <param name="itemToPickUp"> The item to pick up.        </param>
    /// <param name="other">        The GameObject of the item. </param>
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

    /// <summary>
    /// Gradualy increses opacity of interactProgressImg
    /// and if its adds item to inventory.
    /// </summary>
    /// <param name="holdTimeSeconds">  How many seconds to hold    </param>
    /// <param name="itemToPickUp">     What item to pickup         </param>
    /// <param name="other">            The GameObject to the item  </param>
    private void HoldPickupHeld(float holdTimeSeconds, ItemClass itemToPickUp, Collider other)
    {
        // Checks if enouch time has passed for the nest repetition.
        if (Time.time >= nextRepetition)
        {
            // Calculates the time of the next repetition.
            nextRepetition = Time.time + repetitionRate - nextRepetitionMinus;

            // Increases the opacity of the color got from the progress image.
            opacity += opacityEichRepetition;
            newOpacity.a = opacity;

            // If opacity is 1 or less
            // sett progress images color to the newOpacity color.
            if (opacity <= 1)
                interactProgressImg.color = newOpacity;

            // If opacity is 1 or more,
            // add the item to inventorty and disable the items GameObject.
            if (opacity >= 1)
            {
                AddItemToInventoryList(itemToPickUp, other);
                interactPromptGO.SetActive(false);
            }
        }
        
    }

    /// <summary>
    /// Gradualy decreses opacity of interactProgressImg.
    /// </summary>
    private void HoldPickupReleased()
    {
        // Checks if enouch time has passed for the nest repetition.
        if (Time.time >= nextRepetition)
        {
            // Calculates the time of the next repetition.
            nextRepetition = Time.time + repetitionRate - 0.01f;

            // decreses the opacity of the color got from the progress image.
            opacity -= opacityEichRepetition;
            newOpacity.a = opacity;

            // If opacity is 1 or less
            // sett progress images color to the newOpacity color.
            if (opacity <= 1)
                interactProgressImg.color = newOpacity;

        }
    }



    /// <summary>
    /// Counts up to a certan float in a certain time
    /// </summary>
    private void HoldPickupHeldTest(float TestAmountGoal, float TestSeconds, float repetitionRate)
    {
        float TestValueEichRepetition;

        TestValueEichRepetition = (TestAmountGoal / TestSeconds) * repetitionRate;

        // Checks if enouch time has passed for the nest repetition.
        if (Time.time >= nextRepetition)
        {
            // Calculates the time of the next repetition.
            nextRepetition = Time.time + repetitionRate - nextRepetitionMinus;

            TestAmountCounter += TestValueEichRepetition;

            Debug.Log($"Target: {TestAmountGoal}. Current: {TestAmountCounter}");

            if(TestAmountCounter >= TestAmountGoal)
            {
                TestAmountCounter = TestAmountGoal;
                Debug.Log($"Target: {TestAmountGoal}. Current{TestAmountCounter}. Total time: {TestTime = Time.time - TestTime}");
                TestComplete = true;
            }

        }

    }

}
