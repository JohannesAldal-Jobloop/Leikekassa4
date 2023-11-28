using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BevegelseFPS : MonoBehaviour
{
    public float tyngdekraft = 1f;

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
    public float gåFartVelocetiMaks;
    public float gåFartFaktisk = 0;
    private float addForceVerdi;

    private float sidelengsReduksjons = 0.8f;
    private float tidGåttUtenAkselerasjonInterval;

    public float fartModifierVertikal = 1f;
    public float fartModifierHorisontal = 1f;
    public float bakkeFartModifier = 1f;
    public float springeFartModifier = 1.5f;
    public float luftFartModifier = 0.5f;

    private Vector3 velocityAll;
    private float velocityX;
    private float velocityY;
    private float velocityZ;

    public bool holdSpringer = false;
    public bool springer = false;
    public bool redusertBevegelse = false;
    //--------------------------------------------------

    //---------- Variabler til Hopping ----------
    public float hoppeKraft = 10;
    public int hoppILuftaMaks = 0;
    public int hoppILufta = 0;
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
        
        playerFpsGO = GameObject.Find("SpelerFPS");
        bakkeSjekkGO = GameObject.Find("BakkeSjekk");
        bodyHitbox = playerFpsGO.GetComponent<CapsuleCollider>();
        
        bakkeSjekk = bakkeSjekkGO.GetComponent<BakkeSjekk>();
        spelerDødSkript = GetComponent<SpelerDødSkript>();

        hoppeKraft *= tyngdekraft;
        gåFartOrginal *= tyngdekraft;

        gåFartFaktisk = gåFartOrginal;
        hoppILufta = hoppILuftaMaks;
        gåFartMaks = gåFartOrginal;
    }

    // Update is called once per frame
    void Update()
    {
        Physics.gravity = new Vector3(0, -tyngdekraft, 0);
        

        if (spelerDødSkript.respawner == false)
        {
            FinnVelocityTilSpeler();
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

        if (!bakkeSjekk.paBakken && !redusertBevegelse)
        {
            if(horisontalInput == 0 && vertikalInput == 0)
            {
                fartModifierVertikal = luftFartModifier;
                fartModifierHorisontal = luftFartModifier;
                Debug.Log("redusertBevegelse fart");
                redusertBevegelse = true;
            }
            else if(vertikalInput != 0)
            {
                fartModifierHorisontal = luftFartModifier;
                fartModifierVertikal = bakkeFartModifier;
                Debug.Log("redusertBevegelse fart2");
                redusertBevegelse = true;
            }
            
        }
        else if(bakkeSjekk.paBakken)
        {
            fartModifierHorisontal = bakkeFartModifier;
            fartModifierVertikal = bakkeFartModifier;
            redusertBevegelse = false;

            
        }

        //playerFpsGO.transform.Translate(Vector3.forward * Time.deltaTime * gåFartFaktisk * (vertikalInput * fartModifierVertikal));
        //playerFpsGO.transform.Translate(Vector3.right * Time.deltaTime * gåFartFaktisk * (horisontalInput * fartModifierHorisontal));

        playerFpsRB.AddRelativeForce((horisontalInput * fartModifierHorisontal) * Time.deltaTime * gåFartFaktisk, 0, (vertikalInput * fartModifierVertikal) * Time.deltaTime * gåFartFaktisk, ForceMode.Impulse);

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
        if (Input.GetKeyDown(KeyCode.Space) && bakkeSjekk.paBakken)
        {
            hoppILufta = hoppILuftaMaks;
            playerFpsRB.AddForce(0, hoppeKraft, 0, ForceMode.Force);
        } 
        else if(Input.GetKeyDown(KeyCode.Space) && !bakkeSjekk.paBakken && hoppILufta != 0)
        {
            playerFpsRB.AddForce(0, hoppeKraft, 0, ForceMode.Force);
            hoppILufta--;
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

    void FinnVelocityTilSpeler()
    {
        velocityAll = playerFpsRB.velocity;
        velocityX = playerFpsRB.velocity.x;
        velocityY = playerFpsRB.velocity.y;
        velocityZ = playerFpsRB.velocity.z;
    }
}
