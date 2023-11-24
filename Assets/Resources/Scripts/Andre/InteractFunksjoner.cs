using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InteractFunksjoner : MonoBehaviour
{
    public float interactRekkevidde = 5;

    private int rayIgnorerLayer1 = 9;

    private string funksjonKombinertString;

    public GameObject fpsKamera;

    private knapp knappSkript;


    public delegate void TestDelegate();
    public TestDelegate interactFunksjon;

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
    // kjøyrer IEnumeratoren viss den får ein raycast hit
    // frå speleren sitt kamera som treffer GameObjectet som har goName navn.

    public void KjekkOmBlirTrykktIE(string coroutine, string goName)
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit rayTreff;
            if (Physics.Raycast(fpsKamera.transform.position, fpsKamera.transform.forward, out rayTreff, interactRekkevidde, rayIgnorerLayer1))
            {
                if (rayTreff.transform.name == goName)
                {
                    knappSkript = rayTreff.transform.GetComponent<knapp>();

                    knappSkript.StartCoroutine(coroutine);
                }
            }
        }
    }
}
