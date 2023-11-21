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

    //---------- Variabler til WASD bevegelse ----------
    private float horisontalInput = 0f;
    private float vertikalInput = 0f;

    public float gåFartOrginal = 10f;
    public float gåFartMaks;
    
    public float gåFartFaktisk = 0;
    private float sidelengsReduksjons = 0.75f;
    private float tidGåttUtenAkselerasjonInterval;

    public float fartModifierVertikal = 1f;
    public float fartModifierHorisontal = 1f;
    public float bakkeFartModifier = 1f;
    public float springeFartModifier = 1.5f;
    public float luftFartModifier = 0.5f;

    public bool holdSpringer = false;
    public bool springer = false;
    public bool redusertBevegelse = false;
    //--------------------------------------------------

    //---------- Variabler til Hopping ----------
    public float hoppeKraft = 10;
    //-------------------------------------------

    //---------- Variabler til Huking ----------
    public float hukingDistanse = -1;

    public bool holdHuker = false;
    public bool huker = false;
    //-------------------------------------------

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
            StopSpringingNårStårStille();
            Springing();
            BevegWASD();
        }
    }

    void BevegWASD()
    {
        horisontalInput = Input.GetAxis("Horizontal");
        vertikalInput = Input.GetAxis("Vertical");

        if (!bakkeSjekk.paBakken && !redusertBevegelse)
        {
            if(horisontalInput == 0 && vertikalInput == 0)
            {
                fartModifierVertikal = luftFartModifier;
                fartModifierHorisontal = luftFartModifier;
                redusertBevegelse = true;
            }
            else if(vertikalInput != 0)
            {
                fartModifierHorisontal = luftFartModifier;
                fartModifierVertikal = bakkeFartModifier;
                redusertBevegelse = true;
            }
            
        }
        else if(bakkeSjekk.paBakken)
        {
            fartModifierHorisontal = bakkeFartModifier;
            fartModifierVertikal = bakkeFartModifier;
            redusertBevegelse = false;

            
        }

        playerFpsGO.transform.Translate(Vector3.forward * Time.deltaTime * gåFartFaktisk * (vertikalInput * fartModifierVertikal));
        playerFpsGO.transform.Translate(Vector3.right * Time.deltaTime * gåFartFaktisk * (horisontalInput * fartModifierHorisontal));

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
            playerFpsRB.AddForce(0, hoppeKraft, 0, ForceMode.Force);
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
            if (Input.GetKeyDown(KeyCode.LeftShift) && springer == false && vertikalInput > 0)
            {
                gåFartMaks *= springeFartModifier;
                gåFartFaktisk = gåFartMaks;
                springer = true;
            }
            else if (Input.GetKeyDown(KeyCode.LeftShift) && springer == true || vertikalInput <= 0)
            {
                gåFartMaks = gåFartOrginal;
                springer = false;
            }

            
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftShift) && springer == false && vertikalInput > 0)
            {
                gåFartMaks *= springeFartModifier;
                gåFartFaktisk = gåFartMaks;
                springer = true;
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift) && springer == true || vertikalInput <= 0)
            {
                gåFartMaks = gåFartOrginal;
                springer = false;
            }
        }
        

        
    }

    void StopSpringingNårStårStille()
    {
        if (!holdSpringer && playerFpsRB.velocity.x <= 0f && playerFpsRB.velocity.z <= 0f)
        {
            springer = false;
            gåFartMaks = gåFartOrginal;
            gåFartFaktisk = gåFartMaks;
        }
    }
}
