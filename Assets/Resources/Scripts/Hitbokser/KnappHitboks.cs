using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnappHitboks : MonoBehaviour
{
    public bool spelerInnanforHitboks;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            spelerInnanforHitboks = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            spelerInnanforHitboks = false;
        }
    }
}
