using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpelerUISkript : MonoBehaviour
{
    public GameObject er_d�d_UI;
    public GameObject i_Live_UI;

    public TarSkade tarSkadeSpeler;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OpptaterSpelerUI();
    }

    void OpptaterSpelerUI()
    {
        if(!tarSkadeSpeler.erD�d) 
        { 
            er_d�d_UI.SetActive(false);
            i_Live_UI.SetActive(true);
        }
        else
        {
            er_d�d_UI.SetActive(true);
            i_Live_UI.SetActive(false);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
