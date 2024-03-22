using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PickupScript : MonoBehaviour
{
    [SerializeField] private int opacity;
    [SerializeField] private float interactWaitForSeconds;

    public bool interactPickup = false;

    private KeyCode interactKey = KeyCode.E;

    private GameObject interactPromptGO;
    private TextMeshProUGUI interactPromptText;
    private Image interactProgressImg;

    private InventoryScript inventoryScript;

    // Start is called before the first frame update
    void Start()
    {
        interactPromptGO = GameObject.Find("SingleKey");
        interactPromptText = interactPromptGO.GetComponentInChildren<TextMeshProUGUI>();
        interactProgressImg = interactPromptGO.GetComponentInChildren<Image>();
        interactPromptText.text = interactKey.ToString();
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

                interactPromptGO.SetActive(true);
                if (Input.GetKey(interactKey) && opacity <= 255)
                {
                    Color newOpacity = interactProgressImg.GetComponent<Color>();

                    opacity++;
                    newOpacity.a = opacity;

                    if(opacity <= 255)
                        interactProgressImg.color = newOpacity;
                }

                if(opacity >= 255)
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

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "PickupItem")
        {
            interactPromptGO.SetActive(false);
        }
    }

    IEnumerator InteractProgress()
    {
        opacity++;
        yield return new WaitForSeconds(interactWaitForSeconds);
    }

}
