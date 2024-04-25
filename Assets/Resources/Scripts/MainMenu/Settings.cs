using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class Settings : MonoBehaviour
{
    public float soundVolume = 0;
    public float mouseSensetivity = 0;

    private string keyBindVariable;

    public bool settKeycode;

    enum keyBindVars { }
    [SerializeField] private keyBindVars keyBindVariables;

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

    public void SettKeyCode(string keybindToChange)
    {
        settKeycode = true;
        keyBindVariable = keybindToChange;
    }

    void OnGUI()
    {
        Event e = Event.current;

        if (e.isKey && settKeycode)
        {
            newKeycode = e.keyCode;
            //Debug.Log($"KeyCode pressed: {newKeycode}");

            if(keyBindsClass.keyBindNames.Contains(keyBindVariable))
            {
                Debug.Log("KeyBind sett.");
                inputField.text = e.keyCode.ToString();
            }
            else
            {
                Debug.Log("keyBindVariable is written wrong or it does not exsist.");
            }
            
            settKeycode = false;

        }
    }


}
