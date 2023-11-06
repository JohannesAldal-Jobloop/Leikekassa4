using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivFunksjoner : MonoBehaviour
{
    //***** Variabler til Regenerering()*****
    public bool livRegenererer;
    private bool livIntervallFerdig = true;
    private bool livRegenerererStarta = false;
    public float livRegenerererFart;
    public float livRegenerererMengde;
    public float tidUtanSkadeM�l = 12f;
    public float tidG�ttUtenSkade = 0f;
    private float tidG�ttUtenSkadeInterval = 0;
    //***************************************

    //***** Variabler til OverSkjold()*****
    public bool startMedOverSkjold = false;
    public bool kanF�OverSkjold = false;
    public float overSkjoldMaks = 100;
    public float overSkjoldMengde;
    //***************************************

    //***** Variabler til Forgifta() *****
    public bool erForgifta = false;
    private bool giftOppbyggingReduksjonIntervalFerdig = true;
    public bool erBortidSomp = false;
    public int giftResistanse = 100;
    public int giftOppbygging = 0;
    public float giftSkade = 5;
    public float giftInterval = 0.01f;
    public int giftReduksjonMengde;
    public float giftReduksjonFart;
    //************************************

    private TarSkade tarSkade;

    // Start is called before the first frame update
    void Start()
    {
        tarSkade = GetComponent<TarSkade>();
        TidUtenSkade();
        StartCoroutine(FjernGiftOppbyggingOverTid());

        if (startMedOverSkjold)
        {
            StartMedOverSkjold();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(tarSkade.erD�d == false)
        {
            TidUtenSkade();

            if (livRegenererer)
            {
                if (tidG�ttUtenSkade == tidUtanSkadeM�l && tarSkade.liv < tarSkade.maksLiv && !livRegenerererStarta)
                {
                    StartCoroutine(Regenerering());
                }
            }

            if (giftOppbygging == giftResistanse)
            {
                StartCoroutine(Forgifta());
            }
        }
        
    }

    IEnumerator Regenerering()
    {
        livRegenerererStarta = true;
        Debug.Log("Regenerering starta");

        while(tarSkade.liv != tarSkade.maksLiv && tidG�ttUtenSkade == tidUtanSkadeM�l)
        {
            if(tidG�ttUtenSkade != tidUtanSkadeM�l)
            {
                livRegenerererStarta = false;
            }

            livIntervallFerdig = false;

            if ((tarSkade.liv + livRegenerererMengde) <= tarSkade.maksLiv)
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

        livRegenerererStarta = false;
    }
    public void TidUtenSkade()
    {
        if(tidG�ttUtenSkade != tidUtanSkadeM�l && Time.time >= tidG�ttUtenSkadeInterval)
        {
            tidG�ttUtenSkade++;
            tidG�ttUtenSkadeInterval = Time.time + 1f / 1;
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
    public void StartMedOverSkjold()
    {
        overSkjoldMengde = overSkjoldMaks;
    }

    IEnumerator Forgifta()
    {
        erForgifta = true;

        giftOppbygging = giftResistanse;

        for (int i = 0; i < giftResistanse; i++)
        {
            tarSkade.TaSkade(giftSkade);
            giftOppbygging--;

            yield return new WaitForSeconds(giftInterval);
        }

        erForgifta = false;
    }

    public IEnumerator FjernGiftOppbyggingOverTid()
    {
        while(!erBortidSomp && !erForgifta && giftOppbygging > 0)
        {
            giftOppbygging -= giftReduksjonMengde;

            Debug.Log("Reduserer oppbygning");

            yield return new WaitForSeconds(giftReduksjonFart);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Sump")
        {
            erBortidSomp = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Sump")
        {
            erBortidSomp = false;
            StartCoroutine(FjernGiftOppbyggingOverTid());
        }
    }
}
