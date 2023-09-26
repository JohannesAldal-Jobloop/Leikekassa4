using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakkeSjekk : MonoBehaviour
{
    public GameObject bakkeSjekkGO;

    public bool p�Bakken = true;

    // Start is called before the first frame update
    void Start()
    {
        bakkeSjekkGO = GameObject.Find("BakkeSjekk");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Er borti noko.");
        if (collision.gameObject.layer == 3 && !p�Bakken)
        {
            p�Bakken = true;
            Debug.Log("Er borti bakken.");
        }
    }

    void OnCollisionExit(Collision collision)
    {
        p�Bakken = false;
        Debug.Log("Har forlatt bakken.");

        if (collision.gameObject.layer == 3 && p�Bakken)
        {
            
        }
    }

}
