using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TarSkadeHitboks : MonoBehaviour
{

    public TarSkade tarSkadeParent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RedirektSkadeTilTarSkadeParent(float skadeFråCollider)
    {
        tarSkadeParent.TaSkade(skadeFråCollider);
    }
}
