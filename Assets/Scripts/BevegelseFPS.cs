using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BevegelseFPS : MonoBehaviour
{
    public GameObject playerFpsGO;
    public Rigidbody playerFpsRB;

    public float g�Fart = 10;
    public float hoppeKraft = 10;

    private float horisontalInput = 0f;
    private float vertikalInput = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //playerFpsGO = GameObject.Find("PlayerFPS");
        //playerFpsRB = playerFpsGO.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        BevegWASD();
        Hopping();
    }

    void BevegWASD()
    {
        horisontalInput = Input.GetAxis("Horizontal");
        vertikalInput = Input.GetAxis("Vertical");

        playerFpsGO.transform.Translate(Vector3.forward * Time.deltaTime * g�Fart * vertikalInput);
        playerFpsGO.transform.Translate(Vector3.right * Time.deltaTime * g�Fart * horisontalInput);

        /*
        if (Input.GetKey(KeyCode.W))
        {
            playerFpsRB.AddForce(g�Fart, 0, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            playerFpsRB.AddForce(0, 0, g�Fart);
        }
        else if (Input.GetKey(KeyCode.S)) 
        {
            playerFpsRB.AddForce(-g�Fart, 0, 0);
        }
        else if(Input.GetKey(KeyCode.D)) 
        {
            playerFpsRB.AddForce(0, 0, -g�Fart);
        }
        */
    }

    void Hopping()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            playerFpsRB.AddForce(0, hoppeKraft, 0);
        }
    }
}
