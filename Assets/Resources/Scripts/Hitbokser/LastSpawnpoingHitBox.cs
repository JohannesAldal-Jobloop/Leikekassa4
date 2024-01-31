using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastSpawnpoingHitBox : MonoBehaviour
{
    SpelerDødSkript SpelerDødSkript;

    // Start is called before the first frame update
    void Start()
    {
        SpelerDødSkript = GameObject.Find("SpelerFPS").GetComponent<SpelerDødSkript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "SpelerFPS")
        {
            StartCoroutine(SpelerDødSkript.RespawnCourutine());
        }
    }
}
