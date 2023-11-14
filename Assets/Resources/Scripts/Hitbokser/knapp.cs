using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knapp : MonoBehaviour
{
    public float lengdePåTrykk = 0.1f;

    private GameObject fargeKnapp;
    public GameObject dårTilÅpneDør;

    public Material avMatrialet;
    public Material påMatrialet;

    public InteractFunksjoner handlingSkript;

    // Start is called before the first frame update
    void Start()
    {
        fargeKnapp = GameObject.Find("fargeKnapp");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator GjerHandling()
    {
        // Endre farge til fargeKnapp til påMatrialet.
        // Gjer ein funksjon frå handlingsSkript.

        handlingSkript.ÅpnDør(dårTilÅpneDør);

        yield return new WaitForSeconds(lengdePåTrykk);
        // Ta fargen tilbake til avMatrialet.
        // avslutt det den gjer frå handlingsSkript.
    }
}
