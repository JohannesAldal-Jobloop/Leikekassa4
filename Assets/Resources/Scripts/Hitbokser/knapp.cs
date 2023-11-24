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

    private bool erP� = false;

    // M� ha alle IEnumeratorene sine navn inni {} til funksjoner
    // for at dei skal kunne velges i inspektoren.
    enum funksjoner { ApnDor, EndreFarge, Kodel�s }
    [SerializeField] funksjoner funksjonSomBrukes;

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

    // Start is called before the first frame update
    void Start()
    {
        fargeKnappRendrerer = fargeKnapp.GetComponent<Renderer>();
        fargeKnappRendrerer.material.SetColor("_Color", avFarge);
        handlingSkript = GameObject.Find("SpelSjef").GetComponent<InteractFunksjoner>();

        if(kodel�sGO != null)
        {
            kodel�sSkript = kodel�sGO.GetComponent<Kodel�sSkript>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        VelgRiktigFunksjonsArray();
    }

    void VelgRiktigFunksjonsArray()
    {
        handlingSkript.KjekkOmBlirTrykktIE(funksjonSomBrukes.ToString(), gameObject.name);
    }

    //-------------------- Interact funksjoner til Knapper --------------------
    public IEnumerator ApnDor()
    {
        EndreFarge();

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
    }

    public void EndreFarge()
    {
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

    public IEnumerator Kodel�s()
    {
        if (!kodel�sSkript.erRiktig || kodel�sSkript.inputaKode.Length != kodel�sSkript.riktigKode.Length)
        {
            kodel�sSkript.inputaKode += knappVerdi;
        }

        EndreFarge();
        yield return new WaitForSeconds(lengdeP�Trykk);
        EndreFarge();

    }
    //-------------------------------------------------------------------------
}
