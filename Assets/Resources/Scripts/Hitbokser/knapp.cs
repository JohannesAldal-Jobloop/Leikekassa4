using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knapp : MonoBehaviour
{
    public float lengdeP�Trykk = 0.1f;

    public GameObject fargeKnapp;
    public GameObject d�rTil�pneD�r;

    public Material avMatrialet;
    public Material p�Matrialet;

    private Renderer fargeKnappRendrerer;

    public InteractFunksjoner handlingSkript;

    // Start is called before the first frame update
    void Start()
    {
        fargeKnappRendrerer = fargeKnapp.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator GjerHandling()
    {
        fargeKnappRendrerer.material.SetColor("_Color", Color.green);
        
        // Gjer ein funksjon fr� handlingsSkript.

        handlingSkript.�pnD�r(d�rTil�pneD�r);

        yield return new WaitForSeconds(lengdeP�Trykk);

        fargeKnappRendrerer.material.SetColor("_Color", Color.red);
        // avslutt det den gjer fr� handlingsSkript.
    }
}
