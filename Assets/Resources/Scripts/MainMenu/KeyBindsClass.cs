using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class KeyBindsClass : MonoBehaviour
{
    public Dictionary<string, KeyCode> keyBindsDictionary = new Dictionary<string, KeyCode>();

    // Start is called before the first frame update
    void Start()
    {
        
        keyBindsDictionary.Add("moveForwardKeyCode",        KeyCode.W);
        keyBindsDictionary.Add("moveLeftKeyCode",           KeyCode.A);
        keyBindsDictionary.Add("moveBackKeyCode",           KeyCode.S);
        keyBindsDictionary.Add("moveRightKeyCode",          KeyCode.D);
        keyBindsDictionary.Add("jumpKeyCode",               KeyCode.Space);
        keyBindsDictionary.Add("crouchKeyCode",             KeyCode.C);
        keyBindsDictionary.Add("sprintKeyCode",             KeyCode.LeftShift);
        keyBindsDictionary.Add("interactKeyCode",           KeyCode.E);
        keyBindsDictionary.Add("attackKeyCode",             KeyCode.Mouse0);
        keyBindsDictionary.Add("aimKeyCode",                KeyCode.Mouse1);
        keyBindsDictionary.Add("reloadWeaponKeyCode",       KeyCode.R);
        keyBindsDictionary.Add("pauseGameKeyCode",          KeyCode.Escape);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
