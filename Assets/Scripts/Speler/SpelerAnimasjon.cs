using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpelerAnimasjon : MonoBehaviour
{
    public Animator spelerAnimator;

    public BevegelseFPS bevegelseFPS;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HukingAnimasjon();
    }

    void HukingAnimasjon()
    {
        spelerAnimator.SetBool("Huker", bevegelseFPS.huker);
    }
}
