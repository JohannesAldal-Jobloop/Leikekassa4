using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakkeSjekk : MonoBehaviour
{
    public float maksRekkevidde = 0.1f;

    public bool paBakken = false;

    public GameObject bakkeSjekkGO;
    public GameObject raycastOrigin;

    private BevegelseFPS bevegelseFPS;

    // Start is called before the first frame update
    void Start()
    {
        bakkeSjekkGO = GameObject.Find("BakkeSjekk");
        bevegelseFPS = GameObject.Find("SpelerFPS").GetComponent<BevegelseFPS>();
    }

    // Update is called once per frame
    void Update()
    {
        KjekkOmErOverBakke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9 && !paBakken)
        {
            paBakken = true;
            bevegelseFPS.hoppILufta = bevegelseFPS.hoppILuftaMaks;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 9 && paBakken)
        {
            paBakken = false;
        }
    }

    void KjekkOmErOverBakke()
    {
        RaycastHit rayTreff;
        if (Physics.Raycast(raycastOrigin.transform.position, -raycastOrigin.transform.up, out rayTreff, maksRekkevidde))
        {
            paBakken = true;
            bevegelseFPS.velocity.y = 0;
        }         
        else
        {
            paBakken = false;
        }
    }

}
