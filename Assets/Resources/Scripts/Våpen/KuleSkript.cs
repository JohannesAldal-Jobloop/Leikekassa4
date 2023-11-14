using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class KuleSkript : MonoBehaviour
{
    // TRENGER IKKJE GjerSkade SKRIPTET FOR Å GJERE SKADE TIL TarSkade SKRIPTET.

    public float fart = 1;
    public float skade = 10;
    public float tilbakeslagKraft = 30;
    public float maksRekkevidde = 10;
    public int skyteModus = 0;

    private float spawnPositionX;
    private float spawnPositionY;
    [SerializeField] private float spawnPositionZ;

    [SerializeField] private bool erInnanforMaksRekkevidde = true;

    [SerializeField] private Rigidbody sinRB;

    public Vector3 ophavPosisjon;

    private LayerMask kuleLayer = 6;

    public TarSkade tarSkade;

    // Start is called before the first frame update
    void Start()
    {
        sinRB = gameObject.GetComponent<Rigidbody>();

        if (skyteModus != 3)
        {
            transform.parent = null;
        }

        FinnSpawnPosisjon();
        BevegFramover();
        BulletRestriksjoner();
        
    }

    // Update is called once per frame
    void Update()
    {
        BevegFramover();
        BulletRestriksjoner();
    }

    void BevegFramover()
    {
        sinRB.AddRelativeForce(Vector3.forward * fart * Time.deltaTime, ForceMode.Force);
    }

    void BulletRestriksjoner()
    {
        /* Sjekker om skuddet har reist ein viss lengde framover baser på maxRekevidde 
         * vareabelen frå VåpenVariabler skriptet frå det aktive våpenet + start posisjonen til skuddet. 
         * Viss det er sant so sletter skuddet seg sjølv.
         */

        

        //if (transform.transform.position.x > (spawnPositionX + maksRekkevidde))
        //{
        //    Destroy(gameObject);
        //}
        //else if (transform.transform.position.y > (spawnPositionY + maksRekkevidde))
        //{
        //    Destroy(gameObject);
        //}
        //else if (transform.transform.position.z > (spawnPositionZ + maksRekkevidde))
        //{
        //    Destroy(gameObject);
        //}
        //else if (transform.transform.position.x < (spawnPositionX - maksRekkevidde))
        //{
        //    Destroy(gameObject);
        //}
        //else if (transform.transform.position.y < (spawnPositionY - maksRekkevidde))
        //{
        //    Destroy(gameObject);
        //}
        //else if (transform.transform.position.z < (spawnPositionZ - maksRekkevidde))
        //{
        //    Destroy(gameObject);
        //}



        //---------- Virker ikkje----------
        erInnanforMaksRekkevidde = Physics.CheckSphere(ophavPosisjon, maksRekkevidde*2, kuleLayer);
        Debug.Log(Physics.CheckSphere(ophavPosisjon, maksRekkevidde, kuleLayer));

        if (!erInnanforMaksRekkevidde)
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

        if (tarSkade != null && other.tag != "Kula")
        {
            tarSkade.TaSkade(skade);
            Destroy(gameObject);
        }
        else if(other.tag != "Kula")
        {
            Destroy(gameObject);
        }
    }
}
