using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpelerDødSkript : MonoBehaviour
{
    public bool respawner = false;

    public Vector3 spelarSpawnpoint;
    public Transform spelarSpawnpointTest;

    public GameObject spelarKropp;
    public GameObject spelerVåpenarm;

    private TarSkade spelerTarSkadeSkript;

    // Start is called before the first frame update
    void Start()
    {
        spelerTarSkadeSkript = GetComponent<TarSkade>();
        VisKropp();

        StartCoroutine(RespawnCourutine());
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
        Debug.Log("Vis Kropp");
        spelarKropp.SetActive(true);
        spelerVåpenarm.SetActive(true);
    }

    public IEnumerator RespawnCourutine()
    {
        respawner = true;

        Time.timeScale = 1.0f;

        spelerTarSkadeSkript.liv = spelerTarSkadeSkript.maksLiv;

        transform.eulerAngles = new Vector3( spelarSpawnpointTest.rotation.x, spelarSpawnpointTest.rotation.y, spelarSpawnpointTest.rotation.z);
        transform.position = spelarSpawnpointTest.position;

        yield return new WaitForSeconds(.01f);

        VisKropp();


        yield return new WaitForSeconds(1);
        respawner = false;
    }

    public void Respawn()
    {
        StartCoroutine(RespawnCourutine());
    }
}
