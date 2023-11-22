using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class knapp : MonoBehaviour
{
    public float lengdePåTrykk = 0.1f;
    public float interactRekkevidde = 5;

    private int rayIgnorerLayer1 = 9;

    public GameObject fargeKnapp;
    public GameObject dørTilÅpneDør;
    public GameObject fpsKamera;

    public Color avFarge;
    public Color påFarge;

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
        Debug.Log("Åner dør");

        fargeKnappRendrerer.material.SetColor("_Color", påFarge);

        // Gjer ein funksjon frå handlingsSkript.
        Debug.Log(dørTilÅpneDør.activeInHierarchy);

        if (dørTilÅpneDør.activeInHierarchy)
        {
            dørTilÅpneDør.SetActive(false);
        }
        else
        {
            dørTilÅpneDør.SetActive(true);
        }

        yield return new WaitForSeconds(lengdePåTrykk);

        fargeKnappRendrerer.material.SetColor("_Color", avFarge);
        // avslutt det den gjer frå handlingsSkript.
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
