using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FiendeBevegelse : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform spelerFPSTransform;

    public LayerMask bakke, speler;

    public Vector3 gåPunkt;

    public bool gåPunktSett, spelerInanforSjåRekkevidde, spelerInanforAngrepRekkevidde;
    public bool harAngrepe;
    public float gåPunktRekevidde, sjåRekevidde, angrepsRekkevidde;
    public float angrepshastigheit;

    public SkytevåpenScript skytevåpenScript;

    public GameObject skadeHitboks;

    private SjåAngrepRekkevidde sjåRekkeviddeSkript;

    // Start is called before the first frame update
    void Start()
    {
        spelerFPSTransform = GameObject.Find("SpelerFPS").transform;
        agent = GetComponent<NavMeshAgent>();
        sjåRekkeviddeSkript = GetComponent<SjåAngrepRekkevidde>();
    }

    // Update is called once per frame
    void Update()
    {
    //    spelerInanforSjåRekkevidde = Physics.CheckSphere(transform.position, sjåRekevidde, speler);
    //    spelerInanforAngrepRekkevidde = Physics.CheckSphere(transform.position, angrepsRekkevidde, speler);


        if (!sjåRekkeviddeSkript.serLayerTarget && !sjåRekkeviddeSkript.angripLayerTarget)
        {
            Patruljering();
        }
        else if (sjåRekkeviddeSkript.serLayerTarget && !sjåRekkeviddeSkript.angripLayerTarget)
        {
            BevegMotSpeler();
        }
        else if (sjåRekkeviddeSkript.serLayerTarget && sjåRekkeviddeSkript.angripLayerTarget)
        {
            AngripSpeler();
        }
    }

    void Patruljering()
    {
        
        if (!gåPunktSett)
        {
            FinnGåPunkt();
        }
        if (gåPunktSett)
        {
            agent.SetDestination(gåPunkt);
        }

        Vector3 distanseTilGåPunkt = transform.position - gåPunkt;

        if(distanseTilGåPunkt.magnitude < 1)
        {
            gåPunktSett = false;
        }
    }

    void FinnGåPunkt()
    {
        float tilfeldigX = Random.Range(-gåPunktRekevidde, gåPunktRekevidde);
        float tilfeldigZ = Random.Range(-gåPunktRekevidde, gåPunktRekevidde);

        gåPunkt = new Vector3(transform.position.x + tilfeldigX, transform.position.y, transform.position.z + tilfeldigZ);

        if(Physics.Raycast(gåPunkt, -transform.up, 2f, bakke))
        {
            gåPunktSett = true;
        }
    }

    void BevegMotSpeler()
    {
        agent.SetDestination(spelerFPSTransform.position);
    }

    void AngripSpeler()
    {
        agent.SetDestination(transform.position);
    }

    private void ResetAngrep()
    {
        harAngrepe = false;
        skadeHitboks.SetActive(false);
    }
}
