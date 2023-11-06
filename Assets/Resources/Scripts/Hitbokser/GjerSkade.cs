using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GjerSkade : MonoBehaviour
{
    /*
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
    */

    private bool harGittSkade = false;
    public bool eingang = false;
    public bool overTid = false;

    public float gjerSkadeMengde = 10;
    public float gjerLSkadeOverTidInterval = 1;

    private CapsuleCollider colliderOnGO;

    public TarSkade tarSkade;

    // Start is called before the first frame update
    void Start()
    {
        colliderOnGO = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //********** Gjer skade ein gang so sletter seg sjølv **********
    private void OnTriggerEnter(Collider other)
    {
        if (!harGittSkade && eingang)
        {
            tarSkade = other.gameObject.GetComponent<TarSkade>();

            if (tarSkade != null)
            {
                GjerSkadeEinGang();
            }
        }
    }

    void GjerSkadeEinGang()
    {
        tarSkade.TaSkade(gjerSkadeMengde);
        harGittSkade = true;
        Destroy(gameObject);
    }
    //*****************************************************************



    //********** Gjer skade over tid **********
    private void OnTriggerStay(Collider other)
    {
        tarSkade = other.gameObject.GetComponent<TarSkade>();

        if (tarSkade != null)
        {
            if (!harGittSkade && overTid && (tarSkade.liv <= tarSkade.maksLiv))
            {
                StartCoroutine(GjerSkadeOverTid());
            }
        }

    }

    IEnumerator GjerSkadeOverTid()
    {
        tarSkade.TaSkade(gjerSkadeMengde);
        harGittSkade = true;
        yield return new WaitForSeconds(gjerLSkadeOverTidInterval);
        harGittSkade = false;
    }
    //*********************************************

}
