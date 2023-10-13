using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BevegelseFPS : MonoBehaviour
{
    public GameObject playerFpsGO;
    public GameObject bakkeSjekkGO;
    public GameObject bodyTopHitboxGO;

    public Rigidbody playerFpsRB;

    public float gåFartOrginal = 10f;
    public float gåFartFaktisk = 0;
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
        gåFartFaktisk = gåFartOrginal;
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

    void Huking()
    {
        if (!holdHuker)
        {
            //-----Virker ikkje-----
            // Når du trykker på C so skal spelaren huke til du trykker på C ijen.
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
