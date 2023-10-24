using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpelerDødSkript : MonoBehaviour
{
    public Vector3 spelarSpawnpoint;
    public Transform spelarSpawnpointTest;

    public GameObject spelarKropp;
    public GameObject spelerVåpenarm;

    private TarSkade spelerTarSkadeSkript;

    // Start is called before the first frame update
    void Start()
    {
        spelerTarSkadeSkript = GetComponent<TarSkade>();
    }

    // Update is called once per frame
    void Update()
    {
        if(spelerTarSkadeSkript.erDød)
        {
            GjømKropp();
        }
    }

    void GjømKropp()
    {
        spelarKropp.SetActive(false);
        spelerVåpenarm.SetActive(false);
    }

    void VisKropp()
    {
        spelarKropp.SetActive(true);
        spelerVåpenarm.SetActive(true);
    }

    public void Respawn()
    {
        Time.timeScale = 1.0f;

        spelerTarSkadeSkript.liv = spelerTarSkadeSkript.maksLiv;

        transform.position = spelarSpawnpoint;
        
        VisKropp();
    }
}
