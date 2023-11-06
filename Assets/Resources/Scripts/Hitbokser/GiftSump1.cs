using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftSump1 : MonoBehaviour
{
    private bool harGittGiftoppbygging;

    public int giftOppbyggingMengde = 10;
    public float gjerLSkadeOverTidInterval = 1;

    LivFunksjoner livFunksjoner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        livFunksjoner = other.gameObject.GetComponent<LivFunksjoner>();

        if (livFunksjoner != null)
        {
            if (!harGittGiftoppbygging && (livFunksjoner.giftOppbygging < livFunksjoner.giftResistanse) && !livFunksjoner.erForgifta)
            {
                StartCoroutine(GirGiftOppbyggingOverTid());
            }
        }

    }

    IEnumerator GirGiftOppbyggingOverTid()
    {
        livFunksjoner.giftOppbygging += giftOppbyggingMengde;
        harGittGiftoppbygging = true;
        yield return new WaitForSeconds(gjerLSkadeOverTidInterval);
        harGittGiftoppbygging = false;
    }
}
