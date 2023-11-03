using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KuleSkript : MonoBehaviour
{
    public float fart = 1;
    public float skade = 10;
    public float tilbakeslagKraft = 30;

    private float spawnPositionX;
    private float spawnPositionY;
    private float spawnPositionZ;

    public VåpenVariabler våpenVariabler;
    public TarSkade tarSkade;

    // Start is called before the first frame update
    void Start()
    {
        transform.parent = null;

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

        if (transform.transform.position.x > (spawnPositionX + våpenVariabler.maksRekkevidde))
        {
            Destroy(gameObject);
        }
        else if (transform.transform.position.y > (spawnPositionY + våpenVariabler.maksRekkevidde))
        {
            Destroy(gameObject);
        }
        else if (transform.transform.position.z > (spawnPositionZ + våpenVariabler.maksRekkevidde))
        {
            Destroy(gameObject);
        }
        else if (transform.transform.position.x < (spawnPositionX - våpenVariabler.maksRekkevidde))
        {
            Destroy(gameObject);
        }
        else if (transform.transform.position.y < (spawnPositionY - våpenVariabler.maksRekkevidde))
        {
            Destroy(gameObject);
        }
        else if (transform.transform.position.z < (spawnPositionZ - våpenVariabler.maksRekkevidde))
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

    public void FinnVåpenVariabler(string GOMedVåpenvariablerNavn)
    {
        våpenVariabler = GameObject.Find(GOMedVåpenvariablerNavn).GetComponent<VåpenVariabler>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (tarSkade != null)
        {
            tarSkade.TaSkade(våpenVariabler.skade);
            Debug.Log("Kula1 traff:" + other.name);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
