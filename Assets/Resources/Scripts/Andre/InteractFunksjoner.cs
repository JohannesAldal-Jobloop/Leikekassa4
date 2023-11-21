using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InteractFunksjoner : MonoBehaviour
{
    public float interactRekkevidde = 5;

    private int rayIgnorerLayer1 = 9;

    public GameObject fpsKamera;
    // Start is called before the first frame update
    void Start()
    {
        fpsKamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Denne funksjonen tar ein IEnumerator og kjøyrer den viss den får ein raycast hit frå speleren sitt kamera.
    public void KjekkOmBlirTrykktIE(string coroutine)
    {
        RaycastHit rayTreff;
        if (Physics.CheckSphere(transform.position, interactRekkevidde, 3))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Physics.Raycast(fpsKamera.transform.position, fpsKamera.transform.forward, out rayTreff, interactRekkevidde, rayIgnorerLayer1))
                {
                    StartCoroutine(coroutine);
                }
            }

        }
    }

    // Denne funksjonen tar ein funksjon og kjøyrer den viss den får ein raycast hit frå speleren sitt kamera.
    public void KjekkOmBlirTrykktFunk()
    {
        RaycastHit rayTreff;
        if (Physics.CheckSphere(transform.position, interactRekkevidde, 3))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Physics.Raycast(fpsKamera.transform.position, fpsKamera.transform.forward, out rayTreff, interactRekkevidde, rayIgnorerLayer1))
                {

                }
            }

        }
    }
}
