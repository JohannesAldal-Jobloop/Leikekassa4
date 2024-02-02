using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastSpawnpoingHitBox : MonoBehaviour
{
    SpelerD�dSkript SpelerD�dSkript;

    // Start is called before the first frame update
    void Start()
    {
        SpelerD�dSkript = GameObject.Find("SpelerFPS").GetComponent<SpelerD�dSkript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "SpelerFPS")
        {
            StartCoroutine(SpelerD�dSkript.RespawnCourutine());
        }
    }
}
