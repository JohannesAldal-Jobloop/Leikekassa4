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
        
        
    }

    private void FixedUpdate()
    {
        BevegKameraMedMus();
    }

    void BevegKameraMedMus()
    {
        Cursor.lockState = CursorLockMode.Locked;

        rotasjonX += Input.GetAxis("Mouse Y") * musSensitivitet;
        rotasjonY += Input.GetAxis("Mouse X") * -1 * musSensitivitet;
        transform.localEulerAngles = new Vector3(rotasjonX, rotasjonY, 0);
    }

    void FinnMusRotasjon()
    {
        musRotasjonX = transform.rotation.x;
        musRotasjonY = transform.rotation.y;
        musRotasjonZ = transform.rotation.z;
    }
}
