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
    public bool harAngrepe;
    public float g�PunktRekevidde, sj�Rekevidde, angrepsRekkevidde;
    public float angrepshastigheit;

    public Skytev�penScript skytev�penScript;

    public GameObject skadeHitboks;

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
            skadeHitboks.SetActive(false);
        }
        else if (spelerInanforSj�Rekkevidde && !spelerInanforAngrepRekkevidde)
        {
            BevegMotSpeler();
            skadeHitboks.SetActive(false);
        }
        else if(spelerInanforSj�Rekkevidde && spelerInanforAngrepRekkevidde)
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
        agent.SetDestination(transform.position);
        transform.LookAt(spelerFPSTransform);

        skytev�penScript.FullAutoSkyting();


        if (!harAngrepe)
        {
            skadeHitboks.SetActive(true);

            harAngrepe = true;
            Invoke(nameof(ResetAngrep), angrepshastigheit);
        }
    }

    private void ResetAngrep()
    {
        harAngrepe = false;
        skadeHitboks.SetActive(false);
    }
}
