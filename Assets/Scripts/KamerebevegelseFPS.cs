using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamerebevegelseFPS : MonoBehaviour
{
    public GameObject kamera;

    private float rotasjonX = 0f;
    private float rotasjonY = 0f;
    public float musSensitivitet = 10;
    
    private float musRotasjonX;
    private float musRotasjonY;
    private float musRotasjonZ;

    // Start is called before the first frame update
    void Start()
    {
        kamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        FinnMusRotasjon();   
    }

    private void FixedUpdate()
    {
        BevegKameraMedMus();
    }

    void BevegKameraMedMus()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        rotasjonX += Input.GetAxis("Mouse Y") * musSensitivitet * Time.deltaTime;
        rotasjonY += Input.GetAxis("Mouse X") * -1 * musSensitivitet * Time.deltaTime;
        transform.localEulerAngles = new Vector3(rotasjonX, rotasjonY, 0);

        /*
        if(musRotasjonX >= 90)
        {
            transform.localEulerAngles = new Vector3(90, musRotasjonX, 0);
        }else if(musRotasjonY <= -90)
        {
            transform.localEulerAngles = new Vector3(90, musRotasjonY, 0);
        }
        */
    }

    void FinnMusRotasjon()
    {

        musRotasjonX = gameObject.transform.localEulerAngles.x;
        musRotasjonY = gameObject.transform.localEulerAngles.y;
        musRotasjonZ = gameObject.transform.localEulerAngles.z;

        Debug.Log("X: " + musRotasjonX + "| Y: " + musRotasjonY + "| Z: " + musRotasjonZ);
    }
}
