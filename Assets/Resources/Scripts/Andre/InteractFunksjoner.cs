using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractFunksjoner : MonoBehaviour
{
    //---------- �pnD�r() ----------
    public GameObject d�r;
    //------------------------------

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Test()
    {
        Debug.Log("interacted med denne knappen");
    }

    public void �pnD�r(GameObject d�r)
    {
        Destroy(d�r);
    }
}
