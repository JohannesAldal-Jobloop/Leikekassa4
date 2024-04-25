using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PauseUISkript : MonoBehaviour
{
    //---------- Settings ----------
    TextMeshProUGUI inputButtonText;
    //------------------------------

    PauseUISkript pauseUIScript;
    Settings settings;
    PausSpel pausScript;

    // Start is called before the first frame update
    void Start()
    {
        pauseUIScript = gameObject.GetComponent<PauseUISkript>();
        settings = gameObject.GetComponent<Settings>();
        pausScript = gameObject.GetComponent<PausSpel>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pausScript.erPausa)
        {
            SettingsUI();
        }
        else
        {

        }
    }

    private void SettingsUI()
    {
        if (settings.settKeycode)
        {
            
        }
        else
        {

        }
    }
}
