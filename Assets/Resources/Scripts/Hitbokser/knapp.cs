using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class knapp : MonoBehaviour
{
    //---------- Globale Varabler ----------
    public float lengdePåTrykk = 0.1f;
    public float funksjonVentetid = 0;

    private bool erPå = false;

    // Må ha alle IEnumeratorene sine navn inni {} til funksjoner
    // for at dei skal kunne velges i inspektoren.
    enum funksjoner { ApnDor, EndreFarge, Kodelås }
    [SerializeField] funksjoner funksjonSomBrukes;

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

    // Start is called before the first frame update
    void Start()
    {
        fargeKnappRendrerer = fargeKnapp.GetComponent<Renderer>();
        fargeKnappRendrerer.material.SetColor("_Color", avFarge);
        handlingSkript = GameObject.Find("SpelSjef").GetComponent<InteractFunksjoner>();

        if(kodelåsGO != null)
        {
            kodelåsSkript = kodelåsGO.GetComponent<KodelåsSkript>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //VelgRiktigFunksjonsArray();
    }

    public void VelgRiktigFunksjonsArray()
    {
        //KjekkOmBlirTrykktIE(funksjonSomBrukes.ToString(), gameObject.name);
    }

    public void BlirTrykktStartIE()
    {
        StartCoroutine(funksjonSomBrukes.ToString());
    }

    //-------------------- Interact funksjoner til Knapper --------------------
    public IEnumerator ApnDor()
    {
        EndreFarge();

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

    public IEnumerator Kodelås()
    {
        if (!kodelåsSkript.erRiktig || kodelåsSkript.inputaKode.Length != kodelåsSkript.riktigKode.Length)
        {
            kodelåsSkript.inputaKode += knappVerdi;
            kodelåsSkript.riktigViserTekst.text += knappVerdi;
        }

        EndreFarge();
        yield return new WaitForSeconds(lengdePåTrykk);
        EndreFarge();

    }
    //-------------------------------------------------------------------------
}
