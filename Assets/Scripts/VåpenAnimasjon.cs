using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VåpenAnimasjon : MonoBehaviour
{
    public Animator animator;
    public List<GameObject> våpenList = new List<GameObject>();
    public List<GameObject> siktepunktList = new List<GameObject>();
    public GameObject aktivtSiktepunkt;
    public GameObject aktivtVåpen;

    // Start is called before the first frame update
    void Start()
    {
        FinnAktivtSiktepunkt();
        FinnAktivtVåpen();

        // Må endres til eit skript som finner aktivt våpen. Må kansje finne ein anna måte å gjere det på.
        animator = våpenList[1].GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        SjekkOmSikter();
        FinnAktivtSiktepunkt();
        FinnAktivtVåpen();
    }

    void SjekkOmSikter()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            animator.SetBool("Sikter", true);
            aktivtSiktepunkt.SetActive(false);
        }
        else
        {
            animator.SetBool("Sikter", false);
            aktivtSiktepunkt.SetActive(true);
        }
    }


    // Må lage om til å kunne finne fleire våpen.
    void FinnAktivtVåpen()
    {
        for (int i = 0; i < våpenList.Count; i++)
        {
            if (våpenList[i].activeSelf == true)
            {
                aktivtVåpen = våpenList[i];
            }
        }
    }

    void FinnAktivtSiktepunkt()
    {
        for (int i = 0; i < siktepunktList.Count; i++) 
        {
            if (siktepunktList[i].activeSelf == true)
            {
                aktivtSiktepunkt = siktepunktList[i];
            }
        }
    }
}
