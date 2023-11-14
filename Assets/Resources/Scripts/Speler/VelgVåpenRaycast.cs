using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelgVåpenRaycast : MonoBehaviour
{
    private float maksRekkevidde;

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
            if (Physics.Raycast(fpsKamera.transform.position, fpsKamera.transform.forward, out rayTreff, maksRekkevidde))
            {
                Debug.Log(rayTreff.transform.name);

                for (int i = 0; i < skytevåpenScript.våpenList.Count; i++)
                {
                    if (rayTreff.transform.name == skytevåpenScript.våpenList[i].name)
                    {
                        for(int j = 0; j < skytevåpenScript.våpenList.Count; j++)
                        {

                        }
                    }
                }
            }
        }
        
    }

}
