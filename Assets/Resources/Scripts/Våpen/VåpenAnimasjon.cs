using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VåpenAnimasjon : MonoBehaviour
{
    public Animator animator;

    private SkytevåpenScript skytevåpenScript;
    private KeyBindsClass keyBindsClass;

    // Start is called before the first frame update
    void Start()
    {
        keyBindsClass = GameObject.Find("SpelSjef").GetComponent<KeyBindsClass>();
        skytevåpenScript = GameObject.Find("VåpenHand").GetComponent<SkytevåpenScript>();
        FinnAnimator();
    }

    // Update is called once per frame
    void Update()
    {
        SjekkOmSikter();
        animator = skytevåpenScript.aktivtVåpen.GetComponent<Animator>();
    }

    void SjekkOmSikter()
    {
        if (Input.GetKey(keyBindsClass.aimKeyCode))
        {
            skytevåpenScript.sikter = true;
            animator.SetBool("Sikter", true);
            skytevåpenScript.aktivtSiktepunkt.SetActive(false);
        }
        else
        {
            skytevåpenScript.sikter = false;
            animator.SetBool("Sikter", false);
            skytevåpenScript.aktivtSiktepunkt.SetActive(true);
        }
    }

    IEnumerator FinnAnimator()
    {
        yield return new WaitForSeconds(0.5f);
        animator = skytevåpenScript.aktivtVåpen.GetComponent<Animator>();
    }

}
