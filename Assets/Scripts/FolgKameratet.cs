using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolgKameratet : MonoBehaviour
{
    private GameObject kameraGO;

    // Start is called before the first frame update
    void Start()
    {
        kameraGO = GameObject.Find("Main Camera");

        transform.parent = kameraGO.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
