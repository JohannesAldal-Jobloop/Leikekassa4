using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VåpenAnimasjon : MonoBehaviour
{
    public Animator animator;

    private SkytevåpenScript skytevåpenScript;

    // Start is called before the first frame update
    void Start()
    {
        skytevåpenScript = GameObject.Find("VåpenHand").GetComponent<SkytevåpenScript>();
        animator = skytevåpenScript.aktivtVåpen.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        SjekkOmSikter();
        animator = skytevåpenScript.aktivtVåpen.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        
    }

    void SjekkOmSikter()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            animator.SetBool("Sikter", true);
            skytevåpenScript.aktivtSiktepunkt.SetActive(false);
        }
        else
        {
            animator.SetBool("Sikter", false);
            skytevåpenScript.aktivtSiktepunkt.SetActive(true);
        }
    }


    // Må lage om til å kunne finne fleire våpen.
    
}
