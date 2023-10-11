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
        if (skytev�penScript.aktivV�penVariabler.skyteModus != 3)
        {
            transform.parent = null;
        }
        else
        {
            if(Input.GetKeyUp(KeyCode.Mouse0))
            {
                transform.parent = null;
            }
        }
        
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
        if(skytev�penScript.aktivV�penVariabler.kulaBrukt == 0)
        {
            gameObject.transform.Translate(Vector3.forward * skytev�penScript.aktivV�penVariabler.fart * Time.deltaTime);
        }
        else if(skytev�penScript.aktivV�penVariabler.kulaBrukt == 1)
        {
            gameObject.transform.Translate(Vector3.forward * skytev�penScript.aktivV�penVariabler.fart * Time.deltaTime);
        }
        
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
        Rigidbody hitRB =  other.GetComponent<Rigidbody>();
        if(other.tag != "Kula")
        {
            Debug.Log("Kula Traf noko.");

            if (hitRB != null)
            {
                hitRB.AddForce(gameObject.transform.forward * skytev�penScript.aktivV�penVariabler.tilbakeslagKraft);
            }

            StartCoroutine(SlettKulaEtterVenting());
        }
        
    }

    IEnumerator SlettKulaEtterVenting()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
