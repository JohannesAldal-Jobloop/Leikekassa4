using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KuleSkript : MonoBehaviour
{
    public float fart = 1;

    // Start is called before the first frame update
    void Start()
    {
        BevegFramover();
    }

    // Update is called once per frame
    void Update()
    {
        BevegFramover();
    }

    void BevegFramover()
    {
        //gameObject.transform.Translate(Vector3.forward * fart * Time.deltaTime);
    }
}
