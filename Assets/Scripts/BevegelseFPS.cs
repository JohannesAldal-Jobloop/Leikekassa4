using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BevegelseFPS : MonoBehaviour
{
    public GameObject playerFpsGO;
    public GameObject bakkeSjekkGO;
    public Rigidbody playerFpsRB;

    public float g�FartOrginal = 10f;
    public float g�FartFaktisk = 0;
    public float sidelengsReduksjons = 0.5f;
    public float hoppeKraft = 10;

    private float horisontalInput = 0f;
    private float vertikalInput = 0f;

    private BakkeSjekk bakkeSjekk;

    // Start is called before the first frame update
    void Start()
    {
        playerFpsGO = GameObject.Find("PlayerFPS");
        bakkeSjekkGO = GameObject.Find("PlayerFPS");
        //playerFpsRB = playerFpsGO.GetComponent<Rigidbody>();
        g�FartFaktisk = g�FartOrginal;
        bakkeSjekk = playerFpsGO.GetComponent<BakkeSjekk>();
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

        playerFpsGO.transform.Translate(Vector3.forward * Time.deltaTime * g�FartFaktisk * vertikalInput);
        playerFpsGO.transform.Translate(Vector3.right * Time.deltaTime * g�FartFaktisk * horisontalInput);

        ReduserSidelengsFart();
    }

    void ReduserSidelengsFart()
    {
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            g�FartFaktisk = g�FartOrginal * sidelengsReduksjons;
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            g�FartFaktisk = g�FartOrginal * sidelengsReduksjons;
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            g�FartFaktisk = g�FartOrginal * sidelengsReduksjons;
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            g�FartFaktisk = g�FartOrginal * sidelengsReduksjons;
        }
        else
        {
            g�FartFaktisk = g�FartOrginal;
        }
    }

    void Hopping()
    {
        if (Input.GetKey(KeyCode.Space) && bakkeSjekk.paBakken == true)
        {
            playerFpsRB.AddForce(0, hoppeKraft, 0);
        }
    }


}
