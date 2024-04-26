using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class KeyBindsClass : MonoBehaviour
{
    public KeyCode moveForwardKeyCode       = KeyCode.W;
    public KeyCode moveLeftKeyCode          = KeyCode.A;
    public KeyCode moveBackKeyCode          = KeyCode.S;
    public KeyCode moveRightKeyCode         = KeyCode.D;
    public KeyCode jumpKeyCode              = KeyCode.Space;
    public KeyCode crouchKeyCode            = KeyCode.C;
    public KeyCode sprintKeyCode            = KeyCode.LeftShift;
    public KeyCode interactKeyCode          = KeyCode.E;
    public KeyCode attackKeyCode            = KeyCode.Mouse0;
    public KeyCode aimKeyCode               = KeyCode.Mouse1;
    public KeyCode reloadWeaponKeyCode      = KeyCode.R;
    public KeyCode pauseGameKeyCode         = KeyCode.Escape;
    public KeyCode KeyCode;


    [HideInInspector] public List<string> keyBindNames = new List<string>();
        

    // Start is called before the first frame update
    void Start()
    {
        keyBindNames.Add("moveForwardKeyCode");
        keyBindNames.Add("moveLeftKeyCode");
        keyBindNames.Add("moveBackKeyCode");
        keyBindNames.Add("moveRightKeyCode");
        keyBindNames.Add("jumpKeyCode");
        keyBindNames.Add("crouchKeyCode");
        keyBindNames.Add("sprintKeyCode");
        keyBindNames.Add("interactKeyCode");
        keyBindNames.Add("attackKeyCode");
        keyBindNames.Add("aimKeyCode");
        keyBindNames.Add("reloadWeaponKeyCode");
        keyBindNames.Add("pauseGameKeyCode");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
