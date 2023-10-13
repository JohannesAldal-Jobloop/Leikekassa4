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

    private bool gÂPunktSett, spelerInanforSjÂRekkevidde, spelerInanforAngrepRekkevidde;
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
        BevegMotSpeler();
        spelerInanforSjÂRekkevidde = Physics.CheckSphere(transform.position, sjÂRekevidde, speler);

        if(!spelerInanforSjÂRekkevidde)
        {
            Patruljering();
        }else if (spelerInanforSjÂRekkevidde)
        {
            BevegMotSpeler();
        }
    }

    void Patruljering()
    {
        if (!gÂPunktSett)
        {
            FinnGÂPunkt();
        }
        else
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


    }

    void BevegMotSpeler()
    {
        agent.SetDestination(spelerFPSTransform.position);
    }
}
