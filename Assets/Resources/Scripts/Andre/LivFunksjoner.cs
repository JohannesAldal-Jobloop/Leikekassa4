using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public float tidUtanSkadeMål = 12f;
    public float tidGåttUtenSkade = 0f;
    private float tidGåttUtenSkadeInterval = 0;
    //***************************************

    //***** Variabler til OverSkjold()*****
    public bool startMedOverSkjold = false;
    public bool kanFåOverSkjold = false;
    public float overSkjoldMaks = 100;
    public float overSkjoldMengde;
    //***************************************

    //***** Variabler til Forgifta() *****
    public bool erForgifta = false;
    public bool erBortidSomp = false;
    public bool redusererGiftoppbygging = false;
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
        giftOppbygging = 0;

        if (startMedOverSkjold)
        {
            StartMedOverSkjold();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(tarSkade.erDød == false)
        {
            TidUtenSkade();

            if (livRegenererer)
            {
                if (tidGåttUtenSkade == tidUtanSkadeMål && tarSkade.liv < tarSkade.maksLiv && !livRegenerererStarta)
                {
                    StartCoroutine(Regenerering());
                }
            }

            if (giftOppbygging == giftResistanse)
            {
                StopCoroutine("FjernGiftOppbyggingOverTid");
                redusererGiftoppbygging = false;

                StartCoroutine(Forgifta());
            }

            if (!erBortidSomp && !redusererGiftoppbygging && !erForgifta && giftOppbygging != 0)
            {
                StartCoroutine(FjernGiftOppbyggingOverTid());
                
            }
            else
            {
                StopCoroutine("FjernGiftOppbyggingOverTid");
            }

            if(giftOppbygging < 0)
            {
                giftOppbygging = 0;
            }
        }
        
    }

    IEnumerator Regenerering()
    {
        livRegenerererStarta = true;
        Debug.Log("Regenerering starta");

        while(tarSkade.liv != tarSkade.maksLiv && tidGåttUtenSkade == tidUtanSkadeMål)
        {
            if(tidGåttUtenSkade != tidUtanSkadeMål)
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
        if(tidGåttUtenSkade != tidUtanSkadeMål && Time.time >= tidGåttUtenSkadeInterval)
        {
            tidGåttUtenSkade++;
            tidGåttUtenSkadeInterval = Time.time + 1f / 1;
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

    IEnumerator FjernGiftOppbyggingOverTid()
    {
        redusererGiftoppbygging = true;

        while(giftOppbygging > 0 && !erBortidSomp)
        {
            giftOppbygging -= giftReduksjonMengde;

            yield return new WaitForSeconds(giftReduksjonFart);
        }
        
        redusererGiftoppbygging = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Sump")
        {
            erBortidSomp = true;
            StopCoroutine("FjernGiftOppbyggingOverTid");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Sump" && !erForgifta)
        {
            erBortidSomp = false;
            
        }
    }
}
