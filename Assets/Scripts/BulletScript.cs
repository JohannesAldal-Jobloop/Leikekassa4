using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float fart = 10;
    public int skade = 10;


    // Start is called before the first frame update
    void Start()
    {
        BulletSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        BulletSpawn();
    }
    /* Finn kva våpen som skyter.
     * Juster Variabler som fart, skade etter kvart våpen.
     * So skyt.
     */


    void BulletSpawn()
    {
        transform.Translate(Vector3.forward * fart * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
