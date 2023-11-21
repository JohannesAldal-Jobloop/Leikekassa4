using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakkeSjekk : MonoBehaviour
{
    public GameObject bakkeSjekkGO;

    public bool paBakken = false;

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

}
