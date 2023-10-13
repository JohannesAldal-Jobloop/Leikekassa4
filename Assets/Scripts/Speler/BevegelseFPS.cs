using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BevegelseFPS : MonoBehaviour
{
    public GameObject playerFpsGO;
    public GameObject bakkeSjekkGO;
    public GameObject bodyTopHitboxGO;

    public Rigidbody playerFpsRB;

    public float g�FartOrginal = 10f;
    public float g�FartFaktisk = 0;
    public float sidelengsReduksjons = 0.5f;
    public float hoppeKraft = 10;
    public float hukingDistanse = -1;

    private float horisontalInput = 0f;
    private float vertikalInput = 0f;

    public bool holdHuker = false;
    public bool huker = false;

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
        Huking();
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

    void Huking()
    {
        if (!holdHuker)
        {
            //-----Virker ikkje-----
            // N�r du trykker p� C so skal spelaren huke til du trykker p� C ijen.
            if(Input.GetKeyDown(KeyCode.C) && !huker)
            {
                Debug.Log("Huker");
                bodyTopHitboxGO.SetActive(false);
                huker = true;
            }else if (Input.GetKeyDown(KeyCode.C) && huker)
            {
                bodyTopHitboxGO.SetActive(true);
                huker = false;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.C) && !huker)
            {
                bodyTopHitboxGO.SetActive(false);
                huker = true;
            }

            if (Input.GetKeyUp(KeyCode.C) && huker)
            {
                bodyTopHitboxGO.SetActive(true);
                huker = false;
            }
        }

        
    }
}
