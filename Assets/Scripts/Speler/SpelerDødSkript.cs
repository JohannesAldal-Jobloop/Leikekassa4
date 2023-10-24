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
        VisKropp();
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

    public IEnumerator Respawn()
    {
        Time.timeScale = 1.0f;

        spelerTarSkadeSkript.liv = spelerTarSkadeSkript.maksLiv;

        transform.position = spelarSpawnpoint;

        yield return new WaitForSeconds(.01f);

        VisKropp();
    }

    public void Respawn2()
    {
        StartCoroutine(Respawn());
    }
}
