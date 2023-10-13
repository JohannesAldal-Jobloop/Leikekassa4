using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TarSkade : MonoBehaviour
{
    /* Lag ein liste som inneholder GameObjects med colliders.
     * Dette blir hitboksene til det GameObjectet som dett skripte er koble til.
     */

    /* For at dette skripte skal virke:
     * Collider.
     */

    public float liv = 10;

    public List<Collider> list = new List<Collider>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TaSkade(float skade)
    {
        liv -= skade;

        if(liv <= 0)
        {
            SlettSegSjølv();
        }
    }

    void SlettSegSjølv()
    {
        Destroy(gameObject);
    }

    void FinnAlleHitbokserTilChildren()
    {

    }
}
