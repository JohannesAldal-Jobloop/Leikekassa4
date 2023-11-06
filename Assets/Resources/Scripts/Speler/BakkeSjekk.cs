using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakkeSjekk : MonoBehaviour
{
    public GameObject bakkeSjekkGO;

    public bool paBakken = false;

    // Start is called before the first frame update
    void Start()
    {
        bakkeSjekkGO = GameObject.Find("BakkeSjekk");
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
