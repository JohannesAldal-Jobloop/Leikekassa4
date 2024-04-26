using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BevegelseFPS : MonoBehaviour
{
    public GameObject playerFpsGO;
    public GameObject bakkeSjekkGO;
    public GameObject spelarKroppGO;

    public Rigidbody playerFpsRB;

    public CharacterController bodyHitbox;

    //---------- Variabler til WASD bevegelse ----------
    private CharacterController spelerKontroller;
    [HideInInspector] public Vector3 velocity;

    public float tyngdekraft = -1f;

    private float horisontalInput = 0f;
    private float vertikalInput = 0f;

    public float gåFartOrginal = 10f;
    public float gåFartMaks;
    public float gåFartVelocetiMaks;
    public float gåFartFaktisk = 0;

    private float sidelengsReduksjons = 0.8f;

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
    public float hoppeKraftOrginal = 10;
    public float hoppeKraftFaktisk = 10;
    public float hoppIluftaKraftReduksjon = 0.5f;
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
    private KeyBindsClass keyBindsClass;

    // Start is called before the first frame update
    void Start()
    {
        
        playerFpsGO = GameObject.Find("SpelerFPS");
        bakkeSjekkGO = GameObject.Find("BakkeSjekk");
        bodyHitbox = playerFpsGO.GetComponent<CharacterController>();
        spelerKontroller = GetComponent<CharacterController>();
        
        bakkeSjekk = bakkeSjekkGO.GetComponent<BakkeSjekk>();
        spelerDødSkript = GetComponent<SpelerDødSkript>();

        hoppeKraftFaktisk = hoppeKraftOrginal;
        gåFartFaktisk = gåFartOrginal;
        hoppILufta = hoppILuftaMaks;
        gåFartMaks = gåFartOrginal;
    }

    // Update is called once per frame
    void Update()
    {
        //Physics.gravity = new Vector3(0, -tyngdekraft, 0);
        keyBindsClass = GameObject.Find("SpelSjef").GetComponent<KeyBindsClass>();

        if (spelerDødSkript.respawner == false)
        {
            FinnVelocityTilSpeler();
            Hopping();
            Huking();
            Springing();
            BevegGetAxis();

            
        }
    }

    private void BevegGetAxis()
    {
        horisontalInput = Input.GetAxis("Horizontal");
        vertikalInput = Input.GetAxis("Vertical");

        Vector3 bevegelse = transform.right * horisontalInput + transform.forward * vertikalInput;

        spelerKontroller.Move(bevegelse * gåFartFaktisk * Time.deltaTime);

        velocity.y += tyngdekraft * Time.deltaTime;

        spelerKontroller.Move(velocity * Time.deltaTime);

        ReduserSidelengsFart();


    }

    // Begynt på å laga bevegelse med å bruke keycodene frå KeyBindsClass
    private void BevegWASD()
    {
        if(Input.GetKey(keyBindsClass.keyBindsDictionary["moveForwardKeyCode"]))
        {

        }
    }

    private void ReduserSidelengsFart()
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

    private void Hopping()
    {
        
        if (Input.GetKeyDown(keyBindsClass.keyBindsDictionary["jumpKeyCode"]) && bakkeSjekk.paBakken)
        {
            Debug.Log("hopper");
            hoppeKraftFaktisk = hoppeKraftOrginal;
            hoppILufta = hoppILuftaMaks;
            velocity.y = hoppeKraftFaktisk * Time.deltaTime;
            //playerFpsRB.AddRelativeForce(0, hoppeKraftFaktisk, 0, ForceMode.Impulse);
        } 
        else if(Input.GetKeyDown(keyBindsClass.keyBindsDictionary["jumpKeyCode"]) && !bakkeSjekk.paBakken && hoppILufta != 0)
        {
            Debug.Log("hopper i lofta");
            hoppeKraftFaktisk *= hoppIluftaKraftReduksjon;
            velocity.y = hoppeKraftFaktisk * Time.deltaTime;
            //playerFpsRB.AddRelativeForce(0, hoppeKraftFaktisk, 0, ForceMode.Impulse);
            hoppILufta--;
            hoppeKraftFaktisk = hoppeKraftOrginal;
        }
    }

    private void Huking()
    {
        if (!holdHuker)
        {
            if(Input.GetKeyDown(keyBindsClass.keyBindsDictionary["crouchKeyCode"]) && !huker)
            {
                Debug.Log("Huker");
                spelarKroppGO.transform.Translate(0, -hukingDistanse, 0);
                bakkeSjekkGO.transform.Translate(0, -hukingDistanse, 0);
                bodyHitbox.center = new Vector3(-0.00544756651f, -0.136718869f, 1.15092519e-10f);
                bodyHitbox.height = 2.854548f;

                huker = true;
            }else if (Input.GetKeyDown(keyBindsClass.keyBindsDictionary["crouchKeyCode"]) && huker)
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
            if (Input.GetKey(keyBindsClass.keyBindsDictionary["crouchKeyCode"]) && !huker)
            {
                spelarKroppGO.transform.Translate(0, -hukingDistanse, 0);
                bakkeSjekkGO.transform.Translate(0, -hukingDistanse, 0);

                bodyHitbox.center = new Vector3(-0.00544756651f, -0.136718869f, 1.15092519e-10f);
                bodyHitbox.height = 2.854548f;

                huker = true;
            }

            if (Input.GetKeyUp(keyBindsClass.keyBindsDictionary["attackKeyCode"]) && huker)
            {
                spelarKroppGO.transform.Translate(0, hukingDistanse, 0);
                bakkeSjekkGO.transform.Translate(0, hukingDistanse, 0);

                bodyHitbox.center = new Vector3(-0.00544756651f, -0.657192826f, -6.46199205e-11f);
                bodyHitbox.height = 3.884056f;

                huker = false;
            }
        }

        
    }

    private void Springing()
    {
        if(!holdSpringer)
        {
            if (Input.GetKeyDown(keyBindsClass.keyBindsDictionary["sprintKeyCode"]) && springer == false && vertikalInput > 0)
            {
                gåFartMaks *= springeFartModifier;
                gåFartFaktisk = gåFartMaks;
                springer = true;
            }
            else if (Input.GetKeyDown(keyBindsClass.keyBindsDictionary["sprintKeyCode"]) && springer == true || vertikalInput <= 0)
            {
                gåFartMaks = gåFartOrginal;
                springer = false;
            }

            
        }
        else
        {
            if (Input.GetKey(keyBindsClass.keyBindsDictionary["sprintKeyCode"]) && springer == false && vertikalInput > 0)
            {
                gåFartMaks *= springeFartModifier;
                gåFartFaktisk = gåFartMaks;
                springer = true;
            }
            else if (Input.GetKeyUp(keyBindsClass.keyBindsDictionary["sprintKeyCode"]) && springer == true || vertikalInput <= 0)
            {
                gåFartMaks = gåFartOrginal;
                springer = false;
            }
        }
        
    }

    private void FinnVelocityTilSpeler()
    {
        velocityAll = playerFpsRB.velocity;
        velocityX = playerFpsRB.velocity.x;
        velocityY = playerFpsRB.velocity.y;
        velocityZ = playerFpsRB.velocity.z;
    }
}
