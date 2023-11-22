using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class knapp : MonoBehaviour
{
    public float lengdePåTrykk = 0.1f;
    public float interactRekkevidde = 5;
    public float funksjonVentetid = 0;

    private int rayIgnorerLayer1 = 9;

    private bool erPå = false;

    public GameObject fargeKnapp;
    public GameObject dårTilÅpneDør;

    public Color avFarge;
    public Color påFarge;

    private Renderer fargeKnappRendrerer;

    public InteractFunksjoner handlingSkript;

    //private delegate interactDeligate;

    // Start is called before the first frame update
    void Start()
    {
        fargeKnappRendrerer = fargeKnapp.GetComponent<Renderer>();
        fargeKnappRendrerer.material.SetColor("_Color", avFarge);
        handlingSkript = GameObject.Find("SpelSjef").GetComponent<InteractFunksjoner>();

        //interactDeligate = handlingSkript.interactFunksjon;

        //funkParameter = EndreFarge;
    
    }

    // Update is called once per frame
    void Update()
    {
        //handlingSkript.KjekkOmBlirTrykktIE(ApnDor(), gameObject.name);
        handlingSkript.KjekkOmBlirTrykktFunk("EndreFarge", gameObject.name, funksjonVentetid);
    }

    public IEnumerator ApnDor()
    {
        Debug.Log("ÅpnDør");
        fargeKnappRendrerer.material.SetColor("_Color", påFarge);

        // Gjer ein funksjon frå handlingsSkript.

        if (dårTilÅpneDør.activeInHierarchy)
        {
            dårTilÅpneDør.SetActive(false);
        }
        else
        {
            dårTilÅpneDør.SetActive(true);
        }

        yield return new WaitForSeconds(lengdePåTrykk);

        fargeKnappRendrerer.material.SetColor("_Color", avFarge);
        // avslutt det den gjer frå handlingsSkript.
    }

    public void EndreFarge()
    {
        if (erPå)
        {
            fargeKnappRendrerer.material.SetColor("_Color", avFarge);
            erPå = false;
        }
        else
        {
            fargeKnappRendrerer.material.SetColor("_Color", påFarge);
            erPå = true;
        }
    }

}
