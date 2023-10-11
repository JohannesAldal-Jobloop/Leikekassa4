using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BevegelseFPS : MonoBehaviour
{
    public GameObject playerFpsGO;
    public GameObject bakkeSjekkGO;
    public Rigidbody playerFpsRB;

    public float gåFartOrginal = 10f;
    public float gåFartFaktisk = 0;
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
        gåFartFaktisk = gåFartOrginal;
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

        playerFpsGO.transform.Translate(Vector3.forward * Time.deltaTime * gåFartFaktisk * vertikalInput);
        playerFpsGO.transform.Translate(Vector3.right * Time.deltaTime * gåFartFaktisk * horisontalInput);

        ReduserSidelengsFart();
    }

    void ReduserSidelengsFart()
    {
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            gåFartFaktisk = gåFartOrginal * sidelengsReduksjons;
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            gåFartFaktisk = gåFartOrginal * sidelengsReduksjons;
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            gåFartFaktisk = gåFartOrginal * sidelengsReduksjons;
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            gåFartFaktisk = gåFartOrginal * sidelengsReduksjons;
        }
        else
        {
            gåFartFaktisk = gåFartOrginal;
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
