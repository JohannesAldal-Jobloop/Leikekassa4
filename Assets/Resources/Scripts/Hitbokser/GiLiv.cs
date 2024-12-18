using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiLiv : MonoBehaviour
{
    private bool harGittLiv = false;
    public bool eingang = false;
    public bool overTid = false;
    public bool falsk   = false;

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
        if (eingang)
        {
            overTid = false;
            falsk = false;
        }
        else if (overTid)
        {
            eingang = false;
            falsk = false;
        }else if (falsk)
        {
            eingang = false;
            overTid = false;
        }
    }


    //********** Gi liv ein gang so sletter seg sj�lv **********
    private void OnTriggerEnter(Collider other)
    {
        tarSkade = other.gameObject.GetComponent<TarSkade>();

        if (!harGittLiv && eingang && tarSkade.liv < tarSkade.maksLiv)
        {
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

    //********** Gir falsk liv over tid **********
    //private void OnTriggerStay(Collider other)
    //{
    //    tarSkade = other.gameObject.GetComponent<TarSkade>();

    //    if (tarSkade != null)
    //    {
    //        if (!harGittLiv && overTid && (tarSkade.liv <= tarSkade.maksLiv))
    //        {
    //            StartCoroutine(GiFalskLivOverTid());
    //        }
    //    }

    //}

    //IEnumerator GiFalskLivOverTid()
    //{
    //    tarSkade.liv += giLivMengde;
    //    harGittLiv = true;
    //    yield return new WaitForSeconds(giLivOverTidInterval);
    //    harGittLiv = false;
    //}
    //*********************************************


}
