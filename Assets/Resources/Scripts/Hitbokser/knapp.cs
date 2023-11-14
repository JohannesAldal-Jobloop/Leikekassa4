using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knapp : MonoBehaviour
{
    public float lengdeP�Trykk = 0.1f;

    private GameObject fargeKnapp;
    public GameObject d�rTil�pneD�r;

    public Material avMatrialet;
    public Material p�Matrialet;

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
        // Endre farge til fargeKnapp til p�Matrialet.
        // Gjer ein funksjon fr� handlingsSkript.

        handlingSkript.�pnD�r(d�rTil�pneD�r);

        yield return new WaitForSeconds(lengdeP�Trykk);
        // Ta fargen tilbake til avMatrialet.
        // avslutt det den gjer fr� handlingsSkript.
    }
}
