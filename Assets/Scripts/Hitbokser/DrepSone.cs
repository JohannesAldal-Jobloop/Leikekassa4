using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrepSone : MonoBehaviour
{
    TarSkade tarSkade;
    TarSkadeHitboks hitboks;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(hitboks = other.GetComponent<TarSkadeHitboks>())
        {
            hitboks.tarSkadeParent.liv = 0;
        }
        else if(tarSkade = other.gameObject.GetComponent<TarSkade>())
        {
            tarSkade.liv = 0;
        }
        else
        {
            Debug.Log("Ingen skadeskript.");
        }
    }
}
