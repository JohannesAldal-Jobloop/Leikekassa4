using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpelerUISkript : MonoBehaviour
{
    public GameObject er_d�d_UI;
    public GameObject i_Live_UI;

    public Slider livBarGO;

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
        LivBarUpdate();

        if(!tarSkadeSpeler.erD�d) 
        { 
            er_d�d_UI.SetActive(false);
            i_Live_UI.SetActive(true);

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            er_d�d_UI.SetActive(true);
            i_Live_UI.SetActive(false);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void LivBarUpdate()
    {

        livBarGO.maxValue = tarSkadeSpeler.maksLiv;
        livBarGO.value = tarSkadeSpeler.liv;
    }
}
