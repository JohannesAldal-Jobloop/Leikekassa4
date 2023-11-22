using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamerebevegelseFPS : MonoBehaviour
{

    private float rotasjonX = 0f;
    private float rotasjonY = 0f;
    public float musSensitivitet = 10;
    public float minRotasjon = -90;
    public float maxRotasjon = 90;
    public float spawnRotasjonY;

    private float musRotasjonX;
    private float musRotasjonY;
    private float musRotasjonZ;

    public bool harSettSpawnTotasjonY = false;

    public GameObject kamera;
    public GameObject playerFPS;

    public SpelerDødSkript spelerDødSkript;

    // Start is called before the first frame update
    void Start()
    {
        kamera = GameObject.Find("Main Camera");
        playerFPS = GameObject.Find("SpelerFPS");
    }

    // Update is called once per frame
    void Update()
    {
        FinnMusRotasjon();   
    }

    private void FixedUpdate()
    {

        if (spelerDødSkript.respawner == false)
        {
            //if (!harSettSpawnTotasjonY)
            //{
            //    rotasjonY = spawnRotasjonY;
            //    harSettSpawnTotasjonY = true;
            //}

            BevegKameraMedMus();
        }
        else
        {
            rotasjonX = 0;
            rotasjonY = 0;

            //kamera.transform.eulerAngles = new Vector3(rotasjonX, rotasjonY, 0);
            //playerFPS.transform.localEulerAngles = new Vector3(0, rotasjonY, 0);
        }
    }

    void BevegKameraMedMus()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        rotasjonX += Input.GetAxis("Mouse Y") * -1 * musSensitivitet * Time.deltaTime;
        rotasjonY += Input.GetAxis("Mouse X") * 1 * musSensitivitet * Time.deltaTime;

        Debug.Log("RotasjonX: " + rotasjonX + ", RotasjonY: " + rotasjonY);

        /*
         * Kamera bruker .eulerAngles istedenfor .localEulerAngles fordi kamera er childen til playerFPS
         * og .localEulerAngles endrer seg etter parent so då blir rotasjonen feil når parenten endrer seg.
         */
        kamera.transform.eulerAngles = new Vector3(rotasjonX, rotasjonY, 0);
        playerFPS.transform.localEulerAngles = new Vector3(0, rotasjonY, 0);


        rotasjonX = Mathf.Clamp(rotasjonX, minRotasjon, maxRotasjon);

    }

    void FinnMusRotasjon()
    {
        musRotasjonX = gameObject.transform.localEulerAngles.x;
        musRotasjonY = gameObject.transform.localEulerAngles.y;
        musRotasjonZ = gameObject.transform.localEulerAngles.z;
    }

}
