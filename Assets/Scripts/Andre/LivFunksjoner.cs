using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivFunksjoner : MonoBehaviour
{
    //***** Variabler til Regenerering()*****
    public bool livRegenererer;
    private bool livIntervallFerdig = true;
    private bool livRegenerererStarta = false;
    public float livRegenerererFart;
    public float livRegenerererMengde;
    public float tidUtanSkadeMÂl = 12f;
    public float tidGÂttUtenSkade = 0f;
    private float tidGÂttUtenSkadeInterval = 0;
    //***************************************

    //***** Variabler til OverSkjold()*****
    public bool startMedOverSkjold = false;
    public bool kanFÂOverSkjold = false;
    public float overSkjoldMaks = 100;
    public float overSkjoldMengde;
    //***************************************

    public bool erForgifta;

    private TarSkade tarSkade;

    // Start is called before the first frame update
    void Start()
    {
        tarSkade = GetComponent<TarSkade>();
        TidUtenSkade();

        if (startMedOverSkjold)
        {
            StartMedOverSkjold();
        }
    }

    // Update is called once per frame
    void Update()
    {
        TidUtenSkade();

        if (livRegenererer)
        {
            if (tidGÂttUtenSkade == tidUtanSkadeMÂl && tarSkade.liv < tarSkade.maksLiv && !livRegenerererStarta)
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
        livRegenerererStarta = true;


        if (tarSkade.liv < tarSkade.maksLiv)
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
            livRegenerererStarta = false;
        }
    }
    public void TidUtenSkade()
    {
        if(tidGÂttUtenSkade != tidUtanSkadeMÂl && Time.time >= tidGÂttUtenSkadeInterval)
        {
            
            tidGÂttUtenSkade++;
            tidGÂttUtenSkadeInterval = Time.time + 1f / 1;
        }
    }

    public void FaOverSkjold(float mengdeSkjold)
    {
        if ((overSkjoldMengde + mengdeSkjold) <= overSkjoldMaks)
        {
            overSkjoldMengde += mengdeSkjold;
        }
        else
        {
            overSkjoldMengde = overSkjoldMaks;
        }
    }
    void StartMedOverSkjold()
    {
        overSkjoldMengde = overSkjoldMaks;
    }

    void Forgifta()
    {

    }
}
