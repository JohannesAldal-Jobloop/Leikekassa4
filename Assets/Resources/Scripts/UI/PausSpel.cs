using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausSpel : MonoBehaviour
{
    public bool erPausa = false;

    InventoryScript inventoryScript;

    // Start is called before the first frame update
    void Start()
    {
        erPausa = false;
        Time.timeScale = 0.5f;
        inventoryScript = GameObject.Find("SpelSjef").GetComponent<InventoryScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape) && !inventoryScript.inventoryOpen)
        {
            PauseFunksjon();
        }
    }

    void PauseFunksjon()
    {
        if(!erPausa)
        { 
            erPausa = true; 
            Time.timeScale = 0;
        }
        else
        {
            erPausa = false;
            Time.timeScale = 1;
        }
        
    }
}
