using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class knapp : MonoBehaviour
{
    // FOR � VIRKE M� KVAR KNAPP HA EIT FORSJELIG NAVN GLOBALT!!

    //---------- Globale Varabler ----------
    public float lengdeP�Trykk = 0.1f;
    public float funksjonVentetid = 0;

    public int funksjonerBlirBruktIndex = 0;

    public bool brukeIEnumerator = false;
    public bool erP� = false;

    [SerializeField] private string[] funksjoner;
    [SerializeField] private string[] IEnumeratorer;

    private InteractFunksjoner handlingSkript;
    //--------------------------------------

    //---------- Variabler til ApnDor() ----------
    public GameObject d�rTil�pneD�r;
    //--------------------------------------------

    //---------- Variabler til EndreFarge() ----------
    public GameObject fargeKnapp;

    public Color avFarge;
    public Color p�Farge;

    private Renderer fargeKnappRendrerer;
    //------------------------------------------------

    //---------- Varabler til Kodel�s() ----------
    public string knappVerdi;

    public GameObject kodel�sGO;

    private Kodel�sSkript kodel�sSkript;
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
        kodel�sSkript = kodel�sGO.GetComponent<Kodel�sSkript>();
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
        Debug.Log("�pnD�r");
        EndreFarge();

        // Gjer ein funksjon fr� handlingsSkript.

        if (d�rTil�pneD�r.activeInHierarchy)
        {
            d�rTil�pneD�r.SetActive(false);
        }
        else
        {
            d�rTil�pneD�r.SetActive(true);
        }

        yield return new WaitForSeconds(lengdeP�Trykk);

        EndreFarge();
        // avslutt det den gjer fr� handlingsSkript.
    }

    public void EndreFarge()
    {
        Debug.Log("endrer farge");
        if (erP�)
        {
            fargeKnappRendrerer.material.SetColor("_Color", avFarge);
            erP� = false;
        }
        else
        {
            fargeKnappRendrerer.material.SetColor("_Color", p�Farge);
            erP� = true;
        }
    }

    void Kodel�s()
    {
        kodel�sSkript.inputaKode += knappVerdi;
    }
    //-------------------------------------------------------------------------
}
