using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;

public class knapp : MonoBehaviour
{
    //---------- Globale Varabler ----------
    public float lengdePåTrykk = 0.1f;
    public float funksjonVentetid = 0;

    private bool erPå = false;

    public string knappTekst;

    private TextMeshPro knappTMP;
    private Transform knappTextTransform;

    public Font font;

    // Må ha alle IEnumeratorene sine navn inni {} til funksjoner
    // for at dei skal kunne velges i inspektoren.
    enum funksjoner { ApnDor, EndreFarge, Kodelås }
    [SerializeField] funksjoner funksjonSomBrukes;
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
        knappTextTransform = gameObject.transform.Find("fargeKnapp").transform.Find("Text (TMP)");
        knappTMP = knappTextTransform.GetComponent<TextMeshPro>();

        if(kodelåsGO != null)
        {
            kodelåsSkript = kodelåsGO.GetComponent<KodelåsSkript>();
        }

        if(knappTekst != null)
        {
            knappTMP.text = knappTekst;
        }

        //knappTMP.font = 
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
        // Sjekker om knappen er backspace eller ein med tall.
        if(gameObject.name == "KodelåsKnappBackspace")
        {
            // Removes the last Char of the inputaKode from the KodelåsSkript script.
            kodelåsSkript.inputaKode = kodelåsSkript.inputaKode.Remove(kodelåsSkript.inputaKode.Length-1);
        }
        else if (kodelåsSkript.inputaKode.Length != kodelåsSkript.riktigKode.Length)
        {
            kodelåsSkript.inputaKode += knappTekst;
            kodelåsSkript.riktigViserTekst.text += knappTekst;
            
        }

        // Changes the color temporarly
        EndreFarge();
        yield return new WaitForSeconds(lengdePåTrykk);
        EndreFarge();

    }
    
    //-------------------------------------------------------------------------
}
