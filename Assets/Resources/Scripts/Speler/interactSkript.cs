using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class interactSkript : MonoBehaviour
{
    public float interactRekkevidde = 5;

    [SerializeField] private Camera fpsKamera;

    private knapp knappSkript; 
    private KeyBindsClass keyBindsClass;

    // Start is called before the first frame update
    void Start()
    {
        keyBindsClass = GameObject.Find("SpelSjef").GetComponent<KeyBindsClass>();
        fpsKamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyBindsClass.interactKeyCode))
        {
            RaycastHit rayTreff;
            if (Physics.Raycast(fpsKamera.transform.position, fpsKamera.transform.forward, out rayTreff, interactRekkevidde))
            {
                if (rayTreff.transform.GetComponent<knapp>())
                {
                    knappSkript = rayTreff.transform.GetComponent<knapp>();

                    knappSkript.BlirTrykktStartIE();
                }
            }
        }
    }

    
}
