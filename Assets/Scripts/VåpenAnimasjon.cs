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

        // Må endres til eit skript som finner aktivt våpen. Må kansje finne ein anna måte å gjere det på.
        animator = skytevåpenScript. våpenList[1].GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        SjekkOmSikter();
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
