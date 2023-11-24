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

    // Start is called before the first frame update
    void Start()
    {
        fpsKamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit rayTreff;
            if (Physics.Raycast(fpsKamera.transform.position, fpsKamera.transform.forward, out rayTreff, interactRekkevidde))
            {
                Debug.Log(rayTreff.transform.name);
                if (rayTreff.transform.GetComponent<knapp>())
                {
                    knappSkript = rayTreff.transform.GetComponent<knapp>();

                    knappSkript.BlirTrykktStartIE();
                }
            }
        }
    }

    
}
