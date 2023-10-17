using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FiendeBevegelse : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform spelerFPSTransform;

    public LayerMask bakke, speler;

    public Vector3 gÂPunkt;

    public bool gÂPunktSett, spelerInanforSjÂRekkevidde, spelerInanforAngrepRekkevidde;
    public float gÂPunktRekevidde, sjÂRekevidde, angrepsRekkevidde;

    // Start is called before the first frame update
    void Start()
    {
        spelerFPSTransform = GameObject.Find("SpelerFPS").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        spelerInanforSjÂRekkevidde = Physics.CheckSphere(transform.position, sjÂRekevidde, speler);
        spelerInanforAngrepRekkevidde = Physics.CheckSphere(transform.position, angrepsRekkevidde, speler);

        if(!spelerInanforSjÂRekkevidde && !spelerInanforAngrepRekkevidde)
        {
            Patruljering();
        }else if (spelerInanforSjÂRekkevidde && !spelerInanforAngrepRekkevidde)
        {
            BevegMotSpeler();
        }else if(spelerInanforSjÂRekkevidde && spelerInanforAngrepRekkevidde)
        {
            AngripSpeler();
        }
    }

    void Patruljering()
    {
        
        if (!gÂPunktSett)
        {
            FinnGÂPunkt();
        }
        if (gÂPunktSett)
        {
            agent.SetDestination(gÂPunkt);
        }

        Vector3 distanseTilGÂPunkt = transform.position - gÂPunkt;

        if(distanseTilGÂPunkt.magnitude < 1)
        {
            gÂPunktSett = false;
        }
    }

    void FinnGÂPunkt()
    {
        float tilfeldigX = Random.Range(-gÂPunktRekevidde, gÂPunktRekevidde);
        float tilfeldigZ = Random.Range(-gÂPunktRekevidde, gÂPunktRekevidde);

        gÂPunkt = new Vector3(transform.position.x + tilfeldigX, transform.position.y, transform.position.z + tilfeldigZ);

        if(Physics.Raycast(gÂPunkt, -transform.up, 2f, bakke))
        {
            gÂPunktSett = true;
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
