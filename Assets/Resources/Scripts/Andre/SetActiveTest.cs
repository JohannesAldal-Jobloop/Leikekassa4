using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveTest : MonoBehaviour
{
    public GameObject flipGO;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FlipSetAktiv();
    }

    void FlipSetAktiv()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(flipGO.activeSelf)
            {
                flipGO.SetActive(false);
            }
            else
            {
                flipGO.SetActive(true);
            }
        }
    }
}
