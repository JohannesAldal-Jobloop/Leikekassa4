using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    public bool inventortOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        
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


}
