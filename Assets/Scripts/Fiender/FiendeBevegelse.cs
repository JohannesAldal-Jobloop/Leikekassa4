using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FiendeBevegelse : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform spelerFPSTransform;

    public LayerMask bakke, speler;

    public Vector3 g�Punkt;

    private bool g�PunktSett, spelerInanforSj�Rekkevidde, spelerInanforAngrepRekkevidde;
    public float g�PunktRekevidde, sj�Rekevidde, angrepsRekkevidde;

    // Start is called before the first frame update
    void Start()
    {
        spelerFPSTransform = GameObject.Find("SpelerFPS").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        BevegMotSpeler();
        spelerInanforSj�Rekkevidde = Physics.CheckSphere(transform.position, sj�Rekevidde, speler);

        if(!spelerInanforSj�Rekkevidde)
        {
            Patruljering();
        }else if (spelerInanforSj�Rekkevidde)
        {
            BevegMotSpeler();
        }
    }

    void Patruljering()
    {
        if (!g�PunktSett)
        {
            FinnG�Punkt();
        }
        else
        {
            agent.SetDestination(g�Punkt);
        }

        Vector3 distanseTilG�Punkt = transform.position - g�Punkt;

        if(distanseTilG�Punkt.magnitude < 1)
        {
            g�PunktSett = false;
        }
    }

    void FinnG�Punkt()
    {
        float tilfeldigX = Random.Range(-g�PunktRekevidde, g�PunktRekevidde);
        float tilfeldigZ = Random.Range(-g�PunktRekevidde, g�PunktRekevidde);

        g�Punkt = new Vector3(transform.position.x + tilfeldigX, transform.position.y, transform.position.z + tilfeldigZ);


    }

    void BevegMotSpeler()
    {
        agent.SetDestination(spelerFPSTransform.position);
    }
}
