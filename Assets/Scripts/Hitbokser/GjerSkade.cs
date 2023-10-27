using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GjerSkade : MonoBehaviour
{
    public float skade = 10;

    private Skytev�penScript skytev�penScript;
    private TarSkade tarSkade;
    public TarSkadeHitboks tarskadeHitboks;

    // Start is called before the first frame update
    void Start()
    {
        skytev�penScript = GameObject.Find("V�penHand").GetComponent<Skytev�penScript>();

        skade = skytev�penScript.aktivV�penVariabler.skade;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "taSkadeHitboks")
        {
            tarskadeHitboks = other.GetComponent<TarSkadeHitboks>();

            tarskadeHitboks.RedirektSkadeTilTarSkadeParent(skade);
        }
    }
}
