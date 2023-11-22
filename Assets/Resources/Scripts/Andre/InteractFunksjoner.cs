using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InteractFunksjoner : MonoBehaviour
{
    public float interactRekkevidde = 5;

    private int rayIgnorerLayer1 = 9;

    private string corotineKombinertString;

    public GameObject fpsKamera;

    private knapp knappSkript;


    public delegate void TestDelegate();

    // Start is called before the first frame update
    void Start()
    {
        fpsKamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Denne funksjonen tar ein IEnumerator og ein string.
    // kjøyrer IEnumeratoren viss den får ein raycast hit frå speleren sitt kamera som treffer GameObjectet som har goName navn.

    public void KjekkOmBlirTrykktIE(IEnumerator coroutine, string goName)
    {
        RaycastHit rayTreff;
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(fpsKamera.transform.position, fpsKamera.transform.forward, out rayTreff, interactRekkevidde, rayIgnorerLayer1))
            {
                Debug.Log(rayTreff.transform.name);

                if (rayTreff.transform.name == goName)
                {
                    knappSkript = rayTreff.transform.GetComponent<knapp>();

                    knappSkript.StartCoroutine(coroutine);
                }
            }
        }
    }

    // Denne funksjonen tar ein funksjon og kjøyrer den viss den får ein raycast hit frå speleren sitt kamera.
    public void KjekkOmBlirTrykktFunk(TestDelegate funksjon , string goName)
    {
        RaycastHit rayTreff;
        if (Physics.Raycast(fpsKamera.transform.position, fpsKamera.transform.forward, out rayTreff, interactRekkevidde, rayIgnorerLayer1))
        {
            Debug.Log(rayTreff.transform.name);

            if (rayTreff.transform.name == goName)
            {
                knappSkript = rayTreff.transform.GetComponent<knapp>();

                funksjon();
            }
        }
    }
}
