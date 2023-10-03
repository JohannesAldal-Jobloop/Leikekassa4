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

    private SkytevåpenScript skytevåpenScript;


    // Start is called before the first frame update
    void Start()
    {
        skytevåpenScript = GameObject.Find("VåpenHand").GetComponent<SkytevåpenScript>();

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
    /* Finn kva våpen som skyter.
     * Juster Variabler som fart, skade etter kvart våpen.
     * So skyt.
     */


    void BulletSpawn()
    {
        transform.Translate(Vector3.forward * skytevåpenScript.aktivVåpenVariabler.fart * Time.deltaTime);
    }

    void BulletRestrictions()
    {
        /* Sjekker om skuddet har reist ein viss lengde framover baser på maxRekevidde 
         * vareabelen frå VåpenVariabler skriptet frå det aktive våpenet + start posisjonen til skuddet. 
         * Viss det er sant so sletter skuddet seg sjølv.
         */

        if (transform.transform.position.x > (spawnPositionX + skytevåpenScript.aktivVåpenVariabler.maxRekevidde))
        {
            Destroy(gameObject);
        }else if(transform.transform.position.y > (spawnPositionY + skytevåpenScript.aktivVåpenVariabler.maxRekevidde))
        {
            Destroy(gameObject);
        }else if(transform.transform.position.z > (spawnPositionZ + skytevåpenScript.aktivVåpenVariabler.maxRekevidde))
        {
            Destroy(gameObject);
        }else if(transform.transform.position.x < (spawnPositionX - skytevåpenScript.aktivVåpenVariabler.maxRekevidde))
        {
            Destroy(gameObject);
        }else if(transform.transform.position.y < (spawnPositionY - skytevåpenScript.aktivVåpenVariabler.maxRekevidde))
        {
            Destroy(gameObject);
        }else if(transform.transform.position.z < (spawnPositionZ - skytevåpenScript.aktivVåpenVariabler.maxRekevidde))
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
