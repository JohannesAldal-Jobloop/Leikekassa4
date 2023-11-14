using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactSkript : MonoBehaviour
{
    public float maksRekkevidde = 10;

    private int rayIgnorerLayer1 = 9;

    public GameObject fpsKamera;

    public knapp knapp;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit rayTreff;
            if (Physics.Raycast(fpsKamera.transform.position, fpsKamera.transform.forward, out rayTreff, maksRekkevidde, rayIgnorerLayer1))
            {
                Debug.Log(rayTreff.transform.name);

                knapp = rayTreff.transform.GetComponent<knapp>();

                StartCoroutine(knapp.GjerHandling());
            }
        }

    }
}
