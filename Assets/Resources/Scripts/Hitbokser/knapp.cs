using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knapp : MonoBehaviour
{
    public float lengdePåTrykk = 0.1f;

    public GameObject fargeKnapp;
    public GameObject dårTilÅpneDør;

    public Color avFarge;
    public Color påFarge;

    private Renderer fargeKnappRendrerer;

    public InteractFunksjoner handlingSkript;

    // Start is called before the first frame update
    void Start()
    {
        fargeKnappRendrerer = fargeKnapp.GetComponent<Renderer>();
        fargeKnappRendrerer.material.SetColor("_Color", avFarge);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator GjerHandling()
    {
        fargeKnappRendrerer.material.SetColor("_Color", påFarge);
        
        // Gjer ein funksjon frå handlingsSkript.

        handlingSkript.ÅpnDør(dårTilÅpneDør);

        yield return new WaitForSeconds(lengdePåTrykk);

        fargeKnappRendrerer.material.SetColor("_Color", avFarge);
        // avslutt det den gjer frå handlingsSkript.
    }
}
