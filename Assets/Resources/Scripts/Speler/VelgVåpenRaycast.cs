using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class VelgVåpenRaycast : MonoBehaviour
{
    private float maksRekkevidde;

    private int rayIgnorerLayer1 = 9;
    private int rayIgnorerLayer2 = 4 << 10;

    public GameObject fpsKamera;

    public SkytevåpenScript skytevåpenScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        maksRekkevidde = skytevåpenScript.aktivVåpenVariabler.maksRekkevidde;

        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit rayTreff;
            if (Physics.Raycast(fpsKamera.transform.position, fpsKamera.transform.forward, out rayTreff, maksRekkevidde, rayIgnorerLayer1))
            {
                Debug.Log(rayTreff.transform.name);
                GameObject våpen = GameObject.Find(rayTreff.transform.name);

                for (int i = 0; i < skytevåpenScript.våpenList.Count; i++)
                {
                    if (rayTreff.transform.name == skytevåpenScript.våpenList[i].name)
                    {
                        skytevåpenScript.våpenList[i].SetActive(true);

                        
                    }
                    else if(våpen.layer == 3)
                    {
                        skytevåpenScript.våpenList[i].SetActive(false);
                    }
                }
            }
        }
        
    }

}
