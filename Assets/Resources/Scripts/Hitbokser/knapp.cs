using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class knapp : MonoBehaviour
{
    // FOR � VIRKE M� KVAR KNAPP HA EIT FORSJELIG NAVN GLOBALT!!

    public float lengdeP�Trykk = 0.1f;
    public float interactRekkevidde = 5;
    public float funksjonVentetid = 0;

    private int rayIgnorerLayer1 = 9;

    public int funksjonerBlirBruktIndex = 0;

    public bool brukeIEnumerator = false;
    [SerializeField] private string[] funksjoner;
    [SerializeField] private string[] IEnumeratorer;

    public bool erP� = false;
    

    public GameObject fargeKnapp;
    public GameObject d�rTil�pneD�r;
    public GameObject knappHitboksGO;

    public Color avFarge;
    public Color p�Farge;

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
