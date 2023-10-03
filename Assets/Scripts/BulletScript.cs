using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float fart = 10;
    public float maxRekevidde = 10;
    public float skade = 10;

    private float spawnPositionX;
    private float spawnPositionY;
    private float spawnPositionZ;

    private Skytev�penScript skytev�penScript;


    // Start is called before the first frame update
    void Start()
    {
        skytev�penScript = GameObject.Find("V�penHand").GetComponent<Skytev�penScript>();

        BulletSpawn();
        FinnSpawnPosisjon();
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        BulletSpawn();
        BulletRestrictions();
    }
    /* Finn kva v�pen som skyter.
     * Juster Variabler som fart, skade etter kvart v�pen.
     * So skyt.
     */


    void BulletSpawn()
    {
        transform.Translate(Vector3.forward * skytev�penScript.aktivV�penVariabler.fart * Time.deltaTime);
    }

    void BulletRestrictions()
    {
        /* Sjekker om skuddet har reist ein viss lengde framover baser p� maxRekevidde 
         * vareabelen fr� V�penVariabler skriptet fr� det aktive v�penet + start posisjonen til skuddet. 
         * Viss det er sant so sletter skuddet seg sj�lv.
         */

        if (transform.transform.position.x > (spawnPositionX + skytev�penScript.aktivV�penVariabler.maxRekevidde))
        {
            Destroy(gameObject);
        }else if(transform.transform.position.y > (spawnPositionY + skytev�penScript.aktivV�penVariabler.maxRekevidde))
        {
            Destroy(gameObject);
        }else if(transform.transform.position.z > (spawnPositionZ + skytev�penScript.aktivV�penVariabler.maxRekevidde))
        {
            Destroy(gameObject);
        }else if(transform.transform.position.x < (spawnPositionX - skytev�penScript.aktivV�penVariabler.maxRekevidde))
        {
            Destroy(gameObject);
        }else if(transform.transform.position.y < (spawnPositionY - skytev�penScript.aktivV�penVariabler.maxRekevidde))
        {
            Destroy(gameObject);
        }else if(transform.transform.position.z < (spawnPositionZ - skytev�penScript.aktivV�penVariabler.maxRekevidde))
        {
            Destroy(gameObject);
        }
    }

    void FinnSpawnPosisjon()
    {
        spawnPositionX = transform.position.x;
        spawnPositionY = transform.position.y;
        spawnPositionZ = transform.position.z;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag != "Kula")
        {
            Debug.Log("Kula Traf noko.");
            Destroy(gameObject);
        }
        
    }
}
