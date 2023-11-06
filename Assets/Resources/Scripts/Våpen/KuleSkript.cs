using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KuleSkript : MonoBehaviour
{
    // TRENGER IKKJE GjerSkade SKRIPTET FOR Å GJERE SKADE

    public float fart = 1;
    public float skade = 10;
    public float tilbakeslagKraft = 30;
    public float maksRekkevidde = 10;
    public int skyteModus = 0;

    private float spawnPositionX;
    private float spawnPositionY;
    private float spawnPositionZ;

    public TarSkade tarSkade;

    // Start is called before the first frame update
    void Start()
    {
        if(skyteModus != 3)
        {
            transform.parent = null;
        }

        FinnSpawnPosisjon();
        BevegFramover();

    }

    // Update is called once per frame
    void Update()
    {
        BevegFramover();
        BulletRestriksjoner();
    }

    void BevegFramover()
    {
        gameObject.transform.Translate(Vector3.forward * fart * Time.deltaTime);
    }

    void BulletRestriksjoner()
    {
        /* Sjekker om skuddet har reist ein viss lengde framover baser på maxRekevidde 
         * vareabelen frå VåpenVariabler skriptet frå det aktive våpenet + start posisjonen til skuddet. 
         * Viss det er sant so sletter skuddet seg sjølv.
         */

        if (transform.transform.position.x > (spawnPositionX + maksRekkevidde))
        {
            Destroy(gameObject);
        }
        else if (transform.transform.position.y > (spawnPositionY + maksRekkevidde))
        {
            Destroy(gameObject);
        }
        else if (transform.transform.position.z > (spawnPositionZ + maksRekkevidde))
        {
            Destroy(gameObject);
        }
        else if (transform.transform.position.x < (spawnPositionX - maksRekkevidde))
        {
            Destroy(gameObject);
        }
        else if (transform.transform.position.y < (spawnPositionY - maksRekkevidde))
        {
            Destroy(gameObject);
        }
        else if (transform.transform.position.z < (spawnPositionZ - maksRekkevidde))
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
        tarSkade = other.GetComponent<TarSkade>();

        if (tarSkade != null)
        {
            tarSkade.TaSkade(skade);
            Debug.Log("Kula1 traff:" + other.name);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
