using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GiOverSkjold : MonoBehaviour
{
    private bool harSattOverSkjold = false;
    public bool eingang = false;
    public bool overTid = false;

    public float giOverSkjoldMengde = 10;
    public float giOverSkjoldOverTidInterval = 1;

    private CapsuleCollider colliderOnGO;

    public LivFunksjoner livFunksjoner;

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


    //********** Gi OverSkjold Ein gang so sletter seg sjølv **********
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);

        if (!harSattOverSkjold && eingang)
        {
            livFunksjoner = collision.gameObject.GetComponent<LivFunksjoner>();

            if (livFunksjoner.harOverSkjold != null)
            {
                GiOverSkjoldEinGang();
            }
        }
    }
    void GiOverSkjoldEinGang()
    {
        livFunksjoner.FaOverSkjold(giOverSkjoldMengde);
        harSattOverSkjold = true;
        Destroy(gameObject);
    }
    //*****************************************************************


    //********** Gir OverSkjold over tid **********
    private void OnTriggerStay(Collider other)
    {
        livFunksjoner = other.gameObject.GetComponent<LivFunksjoner>();

        if (livFunksjoner.harOverSkjold != null)
        {
            if (!harSattOverSkjold && overTid && (livFunksjoner.overSkjoldMengde <= livFunksjoner.overSkjoldMaks))
            {
                    StartCoroutine(GiOverSkjoldOverTid());
            }
        }
        
    }

    IEnumerator GiOverSkjoldOverTid()
    {
        livFunksjoner.FaOverSkjold(giOverSkjoldMengde);
        harSattOverSkjold = true;
        yield return new WaitForSeconds(giOverSkjoldOverTidInterval);
        harSattOverSkjold = false;
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
