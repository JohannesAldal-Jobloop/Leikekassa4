using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GjerSkade : MonoBehaviour
{
    public float skade = 10;

    private SkytevåpenScript skytevåpenScript;
    private TarSkade tarSkade;
    public TarSkadeHitboks tarskadeHitboks;

    // Start is called before the first frame update
    void Start()
    {
        skytevåpenScript = GameObject.Find("VåpenHand").GetComponent<SkytevåpenScript>();

        skade = skytevåpenScript.aktivVåpenVariabler.skade;
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
