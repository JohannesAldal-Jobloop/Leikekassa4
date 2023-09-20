using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BevegelseFPS : MonoBehaviour
{
    public GameObject playerFpsGO;
    public Rigidbody playerFpsRB;

    public float gåFart = 10;
    public float hoppeKraft = 10;

    // Start is called before the first frame update
    void Start()
    {
        playerFpsGO = GameObject.Find("PlayerFPS");
        playerFpsRB = playerFpsGO.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        BevegWASD();
        Hopping();
    }

    void BevegWASD()
    {
        if (Input.GetKey(KeyCode.W))
        {
            playerFpsRB.AddForce(gåFart, 0 , 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            playerFpsRB.AddForce(0, 0, gåFart);
        }
        else if (Input.GetKey(KeyCode.S)) 
        {
            playerFpsRB.AddForce(-gåFart, 0, 0);
        }
        else if(Input.GetKey(KeyCode.D)) 
        {
            playerFpsRB.AddForce(0, 0, -gåFart);
        }
    }

    void Hopping()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            playerFpsRB.AddForce(0, hoppeKraft, 0);
        }
    }
}
