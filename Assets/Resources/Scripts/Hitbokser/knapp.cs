using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class knapp : MonoBehaviour
{
    public float lengdeP�Trykk = 0.1f;
    public float interactRekkevidde = 5;

    private int rayIgnorerLayer1 = 9;

    public GameObject fargeKnapp;
    public GameObject d�rTil�pneD�r;
    public GameObject fpsKamera;

    public Color avFarge;
    public Color p�Farge;

    private Renderer fargeKnappRendrerer;

    public InteractFunksjoner handlingSkript;

    // Start is called before the first frame update
    void Start()
    {
        fargeKnappRendrerer = fargeKnapp.GetComponent<Renderer>();
        fargeKnappRendrerer.material.SetColor("_Color", avFarge);
        fpsKamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        KjekkOmBlirTrykktIE(ApnDor());
    }

    public IEnumerator ApnDor()
    {
        Debug.Log("�ner d�r");

        fargeKnappRendrerer.material.SetColor("_Color", p�Farge);

        // Gjer ein funksjon fr� handlingsSkript.
        Debug.Log(d�rTil�pneD�r.activeInHierarchy);

        if (d�rTil�pneD�r.activeInHierarchy)
        {
            d�rTil�pneD�r.SetActive(false);
        }
        else
        {
            d�rTil�pneD�r.SetActive(true);
        }

        yield return new WaitForSeconds(lengdeP�Trykk);

        fargeKnappRendrerer.material.SetColor("_Color", avFarge);
        // avslutt det den gjer fr� handlingsSkript.
    }

    public void KjekkOmBlirTrykktIE(IEnumerator coroutine)
    {
        if (Physics.CheckSphere(transform.position, interactRekkevidde, 3))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Interact");
                RaycastHit rayTreff;
                if (Physics.Raycast(fpsKamera.transform.position, fpsKamera.transform.forward, out rayTreff, interactRekkevidde, rayIgnorerLayer1))
                {
                    StartCoroutine(coroutine);
                }
            }

        }
    }

}
