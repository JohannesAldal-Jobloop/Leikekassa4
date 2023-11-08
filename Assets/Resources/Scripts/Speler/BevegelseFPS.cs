using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BevegelseFPS : MonoBehaviour
{
    public GameObject playerFpsGO;
    public GameObject bakkeSjekkGO;
    public GameObject spelarKroppGO;

    public Rigidbody playerFpsRB;

    public CapsuleCollider bodyHitbox;

    public float g�FartOrginal = 10f;
    public float g�FartMaks;
    public float springeFartModifier = 1.5f;
    public float g�FartFaktisk = 0;
    public float sidelengsReduksjons = 0.5f;
    public float hoppeKraft = 10;
    public float hukingDistanse = -1;

    private float horisontalInput = 0f;
    private float vertikalInput = 0f;

    public bool holdHuker = false;
    public bool holdSpringer = false;
    public bool huker = false;
    public bool springer = false;

    private BakkeSjekk bakkeSjekk;
    private SpelerD�dSkript spelerD�dSkript;

    // Start is called before the first frame update
    void Start()
    {
        g�FartMaks = g�FartOrginal;
        playerFpsGO = GameObject.Find("SpelerFPS");
        bakkeSjekkGO = GameObject.Find("BakkeSjekk");
        bodyHitbox = playerFpsGO.GetComponent<CapsuleCollider>();
        g�FartFaktisk = g�FartOrginal;
        bakkeSjekk = bakkeSjekkGO.GetComponent<BakkeSjekk>();
        spelerD�dSkript = GetComponent<SpelerD�dSkript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spelerD�dSkript.respawner == false)
        {
            Hopping();
            Huking();
            Springing();
            BevegWASD();
        }
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
            g�FartFaktisk = g�FartMaks * sidelengsReduksjons;
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            g�FartFaktisk = g�FartMaks * sidelengsReduksjons;
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            g�FartFaktisk = g�FartMaks * sidelengsReduksjons;
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            g�FartFaktisk = g�FartMaks * sidelengsReduksjons;
        }
        else if(!springer)
        {
            g�FartFaktisk = g�FartOrginal;
        }
        else
        {
            g�FartFaktisk = g�FartMaks;
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
            if(Input.GetKeyDown(KeyCode.C) && !huker)
            {
                Debug.Log("Huker");
                spelarKroppGO.transform.Translate(0, -hukingDistanse, 0);
                bakkeSjekkGO.transform.Translate(0, -hukingDistanse, 0);
                bodyHitbox.center = new Vector3(-0.00544756651f, -0.136718869f, 1.15092519e-10f);
                bodyHitbox.height = 2.854548f;

                huker = true;
            }else if (Input.GetKeyDown(KeyCode.C) && huker)
            {
                spelarKroppGO.transform.Translate(0, hukingDistanse, 0);
                bakkeSjekkGO.transform.Translate(0, hukingDistanse, 0);

                bodyHitbox.center = new Vector3(-0.00544756651f, -0.657192826f, -6.46199205e-11f);
                bodyHitbox.height = 3.884056f;

                huker = false;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.C) && !huker)
            {
                spelarKroppGO.transform.Translate(0, -hukingDistanse, 0);
                bakkeSjekkGO.transform.Translate(0, -hukingDistanse, 0);

                bodyHitbox.center = new Vector3(-0.00544756651f, -0.136718869f, 1.15092519e-10f);
                bodyHitbox.height = 2.854548f;

                huker = true;
            }

            if (Input.GetKeyUp(KeyCode.C) && huker)
            {
                spelarKroppGO.transform.Translate(0, hukingDistanse, 0);
                bakkeSjekkGO.transform.Translate(0, hukingDistanse, 0);

                bodyHitbox.center = new Vector3(-0.00544756651f, -0.657192826f, -6.46199205e-11f);
                bodyHitbox.height = 3.884056f;

                huker = false;
            }
        }

        
    }

    void Springing()
    {
        if(!holdSpringer)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && springer == false)
            {
                g�FartMaks *= springeFartModifier;
                g�FartFaktisk = g�FartMaks;
                springer = true;
            }
            else if (Input.GetKeyDown(KeyCode.LeftShift) && springer == true)
            {
                g�FartMaks = g�FartOrginal;
                springer = false;
            }

            //if (playerFpsRB.velocity == new Vector3(0, 0, 0))
            //{
            //    springer = false;
            //    g�FartMaks = g�FartOrginal;
            //    g�FartFaktisk = g�FartMaks;
            //}
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftShift) && springer == false)
            {
                g�FartMaks *= springeFartModifier;
                g�FartFaktisk = g�FartMaks;
                springer = true;
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift) && springer == true)
            {
                g�FartMaks = g�FartOrginal;
                springer = false;
            }
        }
        

        
    }
}
