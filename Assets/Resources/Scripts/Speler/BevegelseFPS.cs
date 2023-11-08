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

    public float gåFartOrginal = 10f;
    public float gåFartMaks;
    public float springeFartModifier = 1.5f;
    public float gåFartFaktisk = 0;
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
    private SpelerDødSkript spelerDødSkript;

    // Start is called before the first frame update
    void Start()
    {
        gåFartMaks = gåFartOrginal;
        playerFpsGO = GameObject.Find("SpelerFPS");
        bakkeSjekkGO = GameObject.Find("BakkeSjekk");
        bodyHitbox = playerFpsGO.GetComponent<CapsuleCollider>();
        gåFartFaktisk = gåFartOrginal;
        bakkeSjekk = bakkeSjekkGO.GetComponent<BakkeSjekk>();
        spelerDødSkript = GetComponent<SpelerDødSkript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spelerDødSkript.respawner == false)
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

        playerFpsGO.transform.Translate(Vector3.forward * Time.deltaTime * gåFartFaktisk * vertikalInput);
        playerFpsGO.transform.Translate(Vector3.right * Time.deltaTime * gåFartFaktisk * horisontalInput);

        ReduserSidelengsFart();
    }

    void ReduserSidelengsFart()
    {
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            gåFartFaktisk = gåFartMaks * sidelengsReduksjons;
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            gåFartFaktisk = gåFartMaks * sidelengsReduksjons;
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            gåFartFaktisk = gåFartMaks * sidelengsReduksjons;
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            gåFartFaktisk = gåFartMaks * sidelengsReduksjons;
        }
        else if(!springer)
        {
            gåFartFaktisk = gåFartOrginal;
        }
        else
        {
            gåFartFaktisk = gåFartMaks;
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
                gåFartMaks *= springeFartModifier;
                gåFartFaktisk = gåFartMaks;
                springer = true;
            }
            else if (Input.GetKeyDown(KeyCode.LeftShift) && springer == true)
            {
                gåFartMaks = gåFartOrginal;
                springer = false;
            }

            //if (playerFpsRB.velocity == new Vector3(0, 0, 0))
            //{
            //    springer = false;
            //    gåFartMaks = gåFartOrginal;
            //    gåFartFaktisk = gåFartMaks;
            //}
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftShift) && springer == false)
            {
                gåFartMaks *= springeFartModifier;
                gåFartFaktisk = gåFartMaks;
                springer = true;
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift) && springer == true)
            {
                gåFartMaks = gåFartOrginal;
                springer = false;
            }
        }
        

        
    }
}
