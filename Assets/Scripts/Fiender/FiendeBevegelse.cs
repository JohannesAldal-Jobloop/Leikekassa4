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

    public bool g�PunktSett, spelerInanforSj�Rekkevidde, spelerInanforAngrepRekkevidde;
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
        spelerInanforSj�Rekkevidde = Physics.CheckSphere(transform.position, sj�Rekevidde, speler);
        spelerInanforAngrepRekkevidde = Physics.CheckSphere(transform.position, angrepsRekkevidde, speler);

        if(!spelerInanforSj�Rekkevidde && !spelerInanforAngrepRekkevidde)
        {
            Patruljering();
        }else if (spelerInanforSj�Rekkevidde && !spelerInanforAngrepRekkevidde)
        {
            BevegMotSpeler();
        }else if(spelerInanforSj�Rekkevidde && spelerInanforAngrepRekkevidde)
        {
            AngripSpeler();
        }
    }

    void Patruljering()
    {
        
        if (!g�PunktSett)
        {
            FinnG�Punkt();
        }
        if (g�PunktSett)
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

        if(Physics.Raycast(g�Punkt, -transform.up, 2f, bakke))
        {
            g�PunktSett = true;
        }
    }

    void BevegMotSpeler()
    {
        agent.SetDestination(spelerFPSTransform.position);
    }

    void AngripSpeler()
    {

    }
}
