using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivFunksjoner : MonoBehaviour
{
    //***** Variabler til Regenerering()*****
    public bool LivRegenererer;
    public float LivRegenerererFart;
    public float LivRegenerererMengde;
    //***************************************

    public bool HarOverSkjold;
    public bool ErForgifta;

    public TarSkade tarSkade;

    // Start is called before the first frame update
    void Start()
    {
        tarSkade = gameObject.GetComponent<TarSkade>();
    }

    // Update is called once per frame
    void Update()
    {
        if (LivRegenererer)
        {
            StartCoroutine(Regenerering());
        }

        if(HarOverSkjold)
        {
            OverSkjold();
        }

        if(ErForgifta)
        {
            Forgifta();
        }
    }

    IEnumerator Regenerering()
    {
        if(tarSkade.liv < tarSkade.maksLiv)
        {
            Debug.Log("Regenererer liv");
            if((tarSkade.liv + LivRegenerererMengde) <= tarSkade.maksLiv)
            {
                tarSkade.liv += LivRegenerererMengde;
            }
            yield return new WaitForSeconds(LivRegenerererFart);
        }
    }

    void OverSkjold()
    {

    }

    void Forgifta()
    {

    }
}
