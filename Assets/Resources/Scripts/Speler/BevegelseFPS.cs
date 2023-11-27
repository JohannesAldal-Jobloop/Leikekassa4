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

    public float g�FartOrginal = 10f;
    public float g�FartMaks;
    public float g�FartVelocetiMaks;
    public float g�FartFaktisk = 0;
    private float addForceVerdi;

    private float sidelengsReduksjons = 0.75f;
    private float tidG�ttUtenAkselerasjonInterval;

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
    private SpelerD�dSkript spelerD�dSkript;

    // Start is called before the first frame update
    void Start()
    {
        hoppILufta = hoppILuftaMaks;
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
            FinnVelocityTilSpeler();
            Hopping();
            Huking();
            Springing();
            //BevegWASD();
            BevegWASDManuel();

            
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

        //playerFpsGO.transform.Translate(Vector3.forward * Time.deltaTime * g�FartFaktisk * (vertikalInput * fartModifierVertikal));
        //playerFpsGO.transform.Translate(Vector3.right * Time.deltaTime * g�FartFaktisk * (horisontalInput * fartModifierHorisontal));

        addForceVerdi = 1 * Time.deltaTime * g�FartFaktisk;

        playerFpsRB.AddRelativeForce(0, 0, 1 * (vertikalInput * fartModifierVertikal), ForceMode.VelocityChange);
        playerFpsRB.AddRelativeForce(1 * (horisontalInput * fartModifierHorisontal), 0, 0, ForceMode.VelocityChange);

        //if (playerFpsRB.velocity.x >= g�FartVelocetiMaks)
        //{
        //    playerFpsRB.velocity = new Vector3(g�FartVelocetiMaks, velocityY, velocityZ);
        //}
        //else if (playerFpsRB.velocity.y >= g�FartVelocetiMaks)
        //{
        //    playerFpsRB.velocity = new Vector3(velocityX, g�FartVelocetiMaks, velocityZ);
        //}
        //else if (playerFpsRB.velocity.z >= g�FartVelocetiMaks)
        //{
        //    playerFpsRB.velocity = new Vector3(velocityX, velocityY, g�FartVelocetiMaks);
        //}


        ReduserSidelengsFart();
    }

    void BevegWASDManuel()
    {
        g�FartFaktisk = g�FartMaks;
        addForceVerdi = 1 * Time.deltaTime * g�FartFaktisk;

        if (Input.GetKey(KeyCode.W))
        {
            //if((velocityAll + new Vector3(0, 0, addForceVerdi)) < new Vector3(g�FartVelocetiMaks, g�FartVelocetiMaks, g�FartVelocetiMaks))
            //{
                
            //}
            playerFpsRB.AddRelativeForce(0,0, addForceVerdi, ForceMode.VelocityChange);

            //playerFpsRB.velocity = new Vector3(1, 0, 0) * Time.deltaTime * g�FartFaktisk; 

        }
        else if(Input.GetKey(KeyCode.A)) 
        {
            playerFpsRB.AddRelativeForce(-addForceVerdi, 0, 0, ForceMode.VelocityChange);

            //playerFpsRB.velocity = new Vector3(0, 0, 1) * Time.deltaTime * g�FartFaktisk;

        }else if(Input.GetKey(KeyCode.S))
        {
            playerFpsRB.AddRelativeForce(0, 0, -addForceVerdi, ForceMode.VelocityChange);

            //playerFpsRB.velocity = new Vector3(-1, 0, 0) * Time.deltaTime * g�FartFaktisk;

        }
        else if(Input.GetKey(KeyCode.D))
        {
            //playerFpsRB.AddRelativeForce(Vector3.right);
            playerFpsRB.AddRelativeForce(addForceVerdi, 0, 0, ForceMode.VelocityChange);

            //playerFpsRB.velocity = new Vector3(0, 0, -1) * Time.deltaTime * g�FartFaktisk;

        }

        //if (playerFpsRB.velocity.x >= g�FartVelocetiMaks)
        //{
        //    playerFpsRB.velocity = new Vector3(g�FartVelocetiMaks, velocityY, velocityZ);
        //}
        //else if (playerFpsRB.velocity.y >= g�FartVelocetiMaks)
        //{
        //    playerFpsRB.velocity = new Vector3(velocityX, g�FartVelocetiMaks, velocityZ);
        //}
        //else if (playerFpsRB.velocity.z >= g�FartVelocetiMaks)
        //{
        //    playerFpsRB.velocity = new Vector3(velocityX, velocityY, g�FartVelocetiMaks);
        //}
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
                g�FartMaks *= springeFartModifier;
                g�FartFaktisk = g�FartMaks;
                springer = true;
            }
            else if (Input.GetKeyDown(KeyCode.LeftShift) && springer == true || vertikalInput <= 0)
            {
                g�FartMaks = g�FartOrginal;
                springer = false;
            }

            
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftShift) && springer == false && vertikalInput > 0)
            {
                g�FartMaks *= springeFartModifier;
                g�FartFaktisk = g�FartMaks;
                springer = true;
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift) && springer == true || vertikalInput <= 0)
            {
                g�FartMaks = g�FartOrginal;
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
