using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public float soundVolume = 0;
    public float mouseSensetivity = 0;

    private bool settKeycode;

    private KeyCode newKeycode;

    [SerializeField] private TextMeshProUGUI inputFieldText;
    [SerializeField] private InputField inputField;

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

        keyBindsClass = GameObject.Find("SpelSjef").GetComponent<KeyBindsClass>();
        
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

    public void SettKeyCode()
    {
        settKeycode = true;
        //inputFieldText.text = "";
        //inputFieldText.text = newKeycode.ToString();
        

    }

    void OnGUI()
    {
        Event e = Event.current;

        if (e.isKey && settKeycode)
        {
            newKeycode = e.keyCode;
            Debug.Log($"KeyCode pressed: {newKeycode}");
            keyBindsClass.jumpKeyCode = newKeycode;
            settKeycode = false;

        }
    }


}
