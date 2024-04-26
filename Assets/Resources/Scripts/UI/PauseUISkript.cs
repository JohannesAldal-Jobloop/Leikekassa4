using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PauseUISkript : MonoBehaviour
{
    //---------- Settings ----------
    [SerializeField] private List<TextMeshProUGUI> inputButtonTexts = new List<TextMeshProUGUI>();

    private string[] keyBindsNames = new string[] { 
            "moveForwardKeyCode",
            "moveLeftKeyCode",
            "moveBackKeyCode",
            "moveRightKeyCode",
            "jumpKeyCode",
            "crouchKeyCode",
            "sprintKeyCode",
            "interactKeyCode",
            "attackKeyCode",
            "aimKeyCode",
            "reloadWeaponKeyCode", 
            "pauseGameKeyCode",
            };
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
            for (int i = 0; i < inputButtonTexts.Count; i++)
            {
                inputButtonTexts[i].text = settings.keyBindsClass.keyBindsDictionary[keyBindsNames[i]].ToString();
            }
        }
        else
        {

        }
    }
}
