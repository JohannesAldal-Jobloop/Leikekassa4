using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TarSkade : MonoBehaviour
{
    public float liv = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TaSkade(float skade)
    {
        liv -= skade;

        if(liv <= 0)
        {
            SlettSegSjølv();
        }
    }

    void SlettSegSjølv()
    {
        Destroy(gameObject);
    }
}
