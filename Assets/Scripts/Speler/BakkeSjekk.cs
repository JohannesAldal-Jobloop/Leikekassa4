using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakkeSjekk : MonoBehaviour
{
    public GameObject bakkeSjekkGO;

    public bool paBakken = true;

    // Start is called before the first frame update
    void Start()
    {
        //bakkeSjekkGO = GameObject.Find("BakkeSjekk");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 3 && !paBakken)
        {
            paBakken = true;
        }
        
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 3 && paBakken)
        {
            paBakken = false;
        }
            
    }

}
