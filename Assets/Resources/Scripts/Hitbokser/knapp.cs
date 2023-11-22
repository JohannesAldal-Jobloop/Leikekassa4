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

    public Color avFarge;
    public Color p�Farge;

    private Renderer fargeKnappRendrerer;

    public InteractFunksjoner handlingSkript;

    public delegate void TestDelegate();
    public TestDelegate funkParameter;

    // Start is called before the first frame update
    void Start()
    {
        fargeKnappRendrerer = fargeKnapp.GetComponent<Renderer>();
        fargeKnappRendrerer.material.SetColor("_Color", avFarge);
        handlingSkript = GameObject.Find("SpelSjef").GetComponent<InteractFunksjoner>();

        funkParameter = EndreFarge;
    
    }

    // Update is called once per frame
    void Update()
    {
        handlingSkript.KjekkOmBlirTrykktIE(ApnDor(), gameObject.name);
        //handlingSkript.KjekkOmBlirTrykktFunk(funkParameter, gameObject.name)
    }

    public IEnumerator ApnDor()
    {
        Debug.Log("�pnD�r");
        fargeKnappRendrerer.material.SetColor("_Color", p�Farge);

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

        fargeKnappRendrerer.material.SetColor("_Color", avFarge);
        // avslutt det den gjer fr� handlingsSkript.
    }

    void EndreFarge()
    {

    }

}
