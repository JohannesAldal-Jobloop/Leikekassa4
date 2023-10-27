using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkadeOverTidSone : MonoBehaviour
{
    public float interval = 1f;
    public float skadePerInterval = 0.5f;

    public bool intervalFerdig = true;

    public TarSkade tarSkade;
    public TarSkadeHitboks hitboks;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SkadOverTid()
    {
        if (hitboks)
        {
            Debug.Log("hitboks");

            intervalFerdig = false;

            yield return new WaitForSeconds(interval);
            hitboks.tarSkadeParent.liv -= skadePerInterval;

            intervalFerdig = true;
        }
        else if (tarSkade)
        {
            Debug.Log("tarSkade");

            intervalFerdig = false;

            yield return new WaitForSeconds(interval);
            hitboks.tarSkadeParent.liv -= skadePerInterval;

            intervalFerdig = true;
        }
        else
        {
            Debug.Log("Ingen skadeskript.");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        tarSkade = other.GetComponent<TarSkade>();
        hitboks = other.GetComponent<TarSkadeHitboks>();

        if (intervalFerdig)
        {
            StartCoroutine(SkadOverTid());
        }
        
    }
}
