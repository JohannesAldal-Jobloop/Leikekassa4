using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiLiv : MonoBehaviour
{
    private bool harGittLiv = false;
    public bool eingang = false;
    public bool overTid = false;

    public float giLivMengde = 10;
    public float giLivOverTidInterval = 1;

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
        OpptaterStatus();
    }


    //********** Gi liv ein gang so sletter seg sjølv **********
    private void OnCollisionEnter(Collision collision)
    {
        if (!harGittLiv && eingang)
        {
            tarSkade = collision.gameObject.GetComponent<TarSkade>();

            if (tarSkade != null)
            {
                GiLivEinGang();
            }
        }
    }
    void GiLivEinGang()
    {
        tarSkade.liv += giLivMengde;
        harGittLiv = true;
        Destroy(gameObject);
    }
    //*****************************************************************



    //********** Gir liv over tid **********
    private void OnTriggerStay(Collider other)
    {
        tarSkade = other.gameObject.GetComponent<TarSkade>();

        if (tarSkade != null)
        {
            if (!harGittLiv && overTid && (tarSkade.liv <= tarSkade.maksLiv))
            {
                StartCoroutine(GiLivOverTid());
            }
        }

    }

    IEnumerator GiLivOverTid()
    {
        tarSkade.liv += giLivMengde;
        harGittLiv = true;
        yield return new WaitForSeconds(giLivOverTidInterval);
        harGittLiv = false;
    }
    //*********************************************

    void OpptaterStatus()
    {
        if (eingang)
        {
            //overTid = false;
            colliderOnGO.isTrigger = false;
        }
        if (overTid)
        {
            //eingang = false;
            colliderOnGO.isTrigger = true;
        }
    }
}
