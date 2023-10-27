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
    public float tidUtanSkadeMål = 12f;
    public float tidGåttUtenSkade = 0f;
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
            if (tidGåttUtenSkade == tidUtanSkadeMål)
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
        tidGåttUtenSkade = 0;

        while(tidGåttUtenSkade != tidUtanSkadeMål)
        {
            tidGåttUtenSkade++;
            yield return new WaitForSeconds(1);
        }

        if(tidGåttUtenSkade == tidUtanSkadeMål)
        {
            StartCoroutine(TidUtenSkade());
        }
    }

    void FåOverSkjold(float mengdeSkjold)
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
