using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpelSjefSpawner : MonoBehaviour
{
    public GameObject spelSjef;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(spelSjef, gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
