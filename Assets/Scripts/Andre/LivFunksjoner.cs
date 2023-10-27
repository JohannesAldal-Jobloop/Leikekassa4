using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivFunksjoner : MonoBehaviour
{
    //***** Variabler til Regenerering()*****
    public bool livRegenererer;
    private bool livIntervallFerdig = true;
    public float livRegenerererFart;
    public float livRegenerererMengde;
    public float tidUtanSkadeM�l = 12f;
    public float tidG�ttUtenSkade = 0f;
    //***************************************

    //***** Variabler til OverSkjold()*****
    public bool harOverSkjold;
    public float overSkjoldMaks = 100;
    public float overSkjoldMengde;
    //***************************************

    public bool erForgifta;

    private TarSkade tarSkade;

    // Start is called before the first frame update
    void Start()
    {
        tarSkade = GetComponent<TarSkade>();
        StartCoroutine(TidUtenSkade());

        if (harOverSkjold)
        {
            StartMedOverSkjold();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (livRegenererer)
        {
            if (tidG�ttUtenSkade == tidUtanSkadeM�l)
            {
                if (livIntervallFerdig)
                {
                    StartCoroutine(Regenerering());
                }
            }
        }

        if(erForgifta)
        {
            Forgifta();
        }
    }

    IEnumerator Regenerering()
    {

        if(tarSkade.liv < tarSkade.maksLiv)
        {
            livIntervallFerdig = false;

            if((tarSkade.liv + livRegenerererMengde) <= tarSkade.maksLiv)
            {
                tarSkade.liv += livRegenerererMengde;
            }
            else
            {
                tarSkade.liv = tarSkade.maksLiv;
            }
            yield return new WaitForSeconds(livRegenerererFart);

            livIntervallFerdig = true;
        }
    }
    public IEnumerator TidUtenSkade()
    {
        tidG�ttUtenSkade = 0;

        while(tidG�ttUtenSkade != tidUtanSkadeM�l)
        {
            tidG�ttUtenSkade++;
            yield return new WaitForSeconds(1);
        }

        if(tidG�ttUtenSkade == tidUtanSkadeM�l)
        {
            StartCoroutine(TidUtenSkade());
        }
    }

    void F�OverSkjold(float mengdeSkjold)
    {
        overSkjoldMengde += mengdeSkjold;
    }
    void StartMedOverSkjold()
    {
        overSkjoldMengde = overSkjoldMaks;
    }

    void Forgifta()
    {

    }
}
