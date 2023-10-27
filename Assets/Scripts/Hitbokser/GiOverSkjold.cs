using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiOverSkjold : MonoBehaviour
{
    private bool harSattOverSkjold = false;

    public float giOverSkjoldMengde = 10;

    public LivFunksjoner livFunksjoner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!harSattOverSkjold)
        {
            harSattOverSkjold=true;

            livFunksjoner = other.gameObject.GetComponent<LivFunksjoner>();

            if (livFunksjoner.harOverSkjold)
            {
                livFunksjoner.FÂOverSkjold(giOverSkjoldMengde);
            }
            else
            {
                Debug.Log("har ikkje oversjold");
            }
        }
        
    }
}
