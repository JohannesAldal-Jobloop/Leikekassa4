using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class knapp : MonoBehaviour
{
    // FOR Å VIRKE MÅ KVAR KNAPP HA EIT FORSJELIG NAVN GLOBALT!!

    //---------- Globale Varabler ----------
    public float lengdePåTrykk = 0.1f;
    public float funksjonVentetid = 0;

    public int funksjonerBlirBruktIndex = 0;

    public bool brukeIEnumerator = false;
    public bool erPå = false;

    [SerializeField] private string[] funksjoner;
    [SerializeField] private string[] IEnumeratorer;

    private InteractFunksjoner handlingSkript;
    //--------------------------------------

    //---------- Variabler til ApnDor() ----------
    public GameObject dårTilÅpneDør;
    //--------------------------------------------

    //---------- Variabler til EndreFarge() ----------
    public GameObject fargeKnapp;

    public Color avFarge;
    public Color påFarge;

    private Renderer fargeKnappRendrerer;
    //------------------------------------------------

    //---------- Varabler til Kodelås() ----------
    public string knappVerdi;

    public GameObject kodelåsGO;

    private KodelåsSkript kodelåsSkript;
    //--------------------------------------------

    //---------- Varabler til _____() ----------

    //----------------------------------------


    //private delegate interactDeligate;

    // Start is called before the first frame update
    void Start()
    {
        fargeKnappRendrerer = fargeKnapp.GetComponent<Renderer>();
        fargeKnappRendrerer.material.SetColor("_Color", avFarge);
        handlingSkript = GameObject.Find("SpelSjef").GetComponent<InteractFunksjoner>();
        kodelåsSkript = kodelåsGO.GetComponent<KodelåsSkript>();
    }

    // Update is called once per frame
    void Update()
    {
        VelgRiktigFunksjonsArray();
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

    //-------------------- Interact funksjoner til Knapper --------------------
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

    void Kodelås()
    {
        kodelåsSkript.inputaKode += knappVerdi;
    }
    //-------------------------------------------------------------------------
}
