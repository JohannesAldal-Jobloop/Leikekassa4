using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SjåAngrepRekkevidde : MonoBehaviour
{
   [SerializeField] public float sjåRekkevidde = 20;
    public float angrepRekkevidde = 10;

    public bool serLayerTarget;
    public bool angripLayerTarget;

    public LayerMask layerTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        serLayerTarget = Physics.CheckSphere(transform.position, sjåRekkevidde, layerTarget);
        angripLayerTarget = Physics.CheckSphere(transform.position, angrepRekkevidde, layerTarget);
    }
}
