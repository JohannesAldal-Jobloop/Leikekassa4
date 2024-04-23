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


    public string[] keyBindNames;

    // Start is called before the first frame update
    void Start()
    {
        keyBindNames.Append(moveForwardKeyCode.ToString());
        keyBindNames.Append(moveLeftKeyCode.ToString());
        keyBindNames.Append(moveBackKeyCode.ToString());
        keyBindNames.Append(moveRightKeyCode.ToString());
        keyBindNames.Append(jumpKeyCode.ToString());
        keyBindNames.Append(crouchKeyCode.ToString());
        keyBindNames.Append(sprintKeyCode.ToString());
        keyBindNames.Append(interactKeyCode.ToString());
        keyBindNames.Append(attackKeyCode.ToString());
        keyBindNames.Append(aimKeyCode.ToString());
        keyBindNames.Append(reloadWeaponKeyCode.ToString());
        keyBindNames.Append(pauseGameKeyCode.ToString());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
