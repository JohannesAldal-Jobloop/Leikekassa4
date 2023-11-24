using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KodelåsSkript : MonoBehaviour
{
    public string riktigKode = "0000";
    public string inputaKode = "";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(inputaKode.Length == riktigKode.Length)
        {
            KjekkOmKodeErRiktig();
        }
    }

    void KjekkOmKodeErRiktig()
    {
        if(inputaKode == riktigKode)
        {
            Debug.Log(riktigKode + "=" +  inputaKode);
        }
    }
}
