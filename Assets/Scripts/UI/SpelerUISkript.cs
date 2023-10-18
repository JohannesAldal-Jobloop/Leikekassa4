using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpelerUISkript : MonoBehaviour
{
    public GameObject dødUISkjerm;

    public TarSkade tarSkadeSpeler;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SjekkOmSpelerErIlive();
    }

    void SjekkOmSpelerErIlive()
    {
        if(tarSkadeSpeler.liv <= 0)
        {
            dødUISkjerm.SetActive(true);
        }
        else
        {
            dødUISkjerm.SetActive(true);
        }
    }
}
