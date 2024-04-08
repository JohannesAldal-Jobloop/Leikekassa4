using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public float soundVolume = 0;
    public float mouseSensetivity = 0;

    private Slider soundSlider;
    private Slider mouseSensetivitySlider;

    private KeyBindsClass keyBindsClass;

    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "HovedMeny")
        {
            //soundSlider = GameObject.Find("Lyd").GetComponent<Slider>();
            //mouseSensetivitySlider = GameObject.Find("Sensetivitet").GetComponent<Slider>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateSoundVolume()
    {
        soundVolume = soundSlider.value;
    }

    public void UpdateMouseSensetivityVolume()
    {
        mouseSensetivity = mouseSensetivitySlider.value;
    }

    private void SettKeyBindsUI()
    {
        /* Sette all teksen til riktig keybind.
         * eksample: moveForwardText.Text = keyBindsClass.moveForwardKeyCode.ToString()
         * 
         */
    }
}
