using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausSpel : MonoBehaviour
{
    public bool erPausa = false;

    InventoryScript inventoryScript;
    KeyBindsClass keyBindClass;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Leikekassa")
        {
            erPausa = false;
            //Time.timeScale = 0.5f;
            inventoryScript = GameObject.Find("SpelSjef").GetComponent<InventoryScript>();
            keyBindClass = GameObject.Find("SpelSjef").GetComponent<KeyBindsClass>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(keyBindClass.pauseGameKeyCode) && !inventoryScript.inventoryOpen)
        {
            PauseFunksjon();
        }
    }

    public void PauseFunksjon()
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
