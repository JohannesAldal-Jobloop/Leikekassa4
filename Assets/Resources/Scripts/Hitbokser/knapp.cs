using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class knapp : MonoBehaviour
{
    // FOR Å VIRKE MÅ KVAR KNAPP HA EIT FORSJELIG NAVN GLOBALT!!

    public float lengdePåTrykk = 0.1f;
    public float interactRekkevidde = 5;
    public float funksjonVentetid = 0;

    private int rayIgnorerLayer1 = 9;

    public int funksjonerBlirBruktIndex = 0;

    public bool brukeIEnumerator = false;
    [SerializeField] private string[] funksjoner;
    [SerializeField] private string[] IEnumeratorer;

    public bool erPå = false;
    

    public GameObject fargeKnapp;
    public GameObject dårTilÅpneDør;
    public GameObject knappHitboksGO;

    public Color avFarge;
    public Color påFarge;

    private Renderer fargeKnappRendrerer;

    private InteractFunksjoner handlingSkript;
    private KnappHitboks knappHitboks;

    //private delegate interactDeligate;

    // Start is called before the first frame update
    void Start()
    {
        fargeKnappRendrerer = fargeKnapp.GetComponent<Renderer>();
        fargeKnappRendrerer.material.SetColor("_Color", avFarge);
        handlingSkript = GameObject.Find("SpelSjef").GetComponent<InteractFunksjoner>();
        knappHitboks = knappHitboksGO.GetComponent<KnappHitboks>();

    
    }

    // Update is called once per frame
    void Update()
    {
        VelgRiktigFunksjonsArray();

        //handlingSkript.KjekkOmBlirTrykktIE("ApnDor", gameObject.name, knappHitboks.spelerInnanforHitboks);
        //handlingSkript.KjekkOmBlirTrykktFunk("EndreFarge", gameObject.name, funksjonVentetid);
    }

    public IEnumerator ApnDor()
    {
        Debug.Log("ÅpnDør");
        EndreFarge();

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

        EndreFarge();
        // avslutt det den gjer frå handlingsSkript.
    }

    public void EndreFarge()
    {
        Debug.Log("endrer farge");
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

    void VelgRiktigFunksjonsArray()
    {
        if (brukeIEnumerator)
        {
            handlingSkript.KjekkOmBlirTrykktIE(IEnumeratorer[funksjonerBlirBruktIndex], gameObject.name);
        }
        else
        {
            handlingSkript.KjekkOmBlirTrykktFunk(funksjoner[funksjonerBlirBruktIndex], gameObject.name, funksjonVentetid);
        }
    }

}
