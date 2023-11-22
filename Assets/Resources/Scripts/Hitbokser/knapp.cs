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
    public GameObject dårTilÅpneDør;

    public Color avFarge;
    public Color påFarge;

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

    void EndreFarge()
    {

    }

}
