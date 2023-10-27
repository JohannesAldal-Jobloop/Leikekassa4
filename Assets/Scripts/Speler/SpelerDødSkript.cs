using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpelerDødSkript : MonoBehaviour
{
    public int aktivtSpelarSpawnpointIndex = 0;

    public bool respawner = false;

    private Vector3 aktivtSpelarSpawnpointRotasjon;

    public Transform aktivSpelarSpawnpointTransform;

    public List<Transform> spelarSpawnpointer = new List<Transform>();

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
        spelarKropp.SetActive(true);
        spelerVåpenarm.SetActive(true);
    }

    public IEnumerator RespawnCourutine()
    {
        respawner = true;

        Time.timeScale = 1.0f;

        spelerTarSkadeSkript.liv = spelerTarSkadeSkript.maksLiv;

        
        transform.position = aktivSpelarSpawnpointTransform.position;

        yield return new WaitForSeconds(.01f);

        transform.eulerAngles = new Vector3(0f, -41f, 0f);
        VisKropp();


        yield return new WaitForSeconds(1);
        respawner = false;
    }

    public void Respawn()
    {
        FinnAktivSpelerSpawnpointRotasjon();
        FinnAktivSpelerSpawnpointtransform();

        StartCoroutine(RespawnCourutine());
    }

    void FinnAktivSpelerSpawnpointtransform()
    {
        aktivSpelarSpawnpointTransform = spelarSpawnpointer[aktivtSpelarSpawnpointIndex];
    }

    void FinnAktivSpelerSpawnpointRotasjon()
    {
        aktivtSpelarSpawnpointRotasjon = new Vector3(

            spelarSpawnpointer[aktivtSpelarSpawnpointIndex].rotation.x,
            spelarSpawnpointer[aktivtSpelarSpawnpointIndex].rotation.y,
            spelarSpawnpointer[aktivtSpelarSpawnpointIndex].rotation.z

            );
    }
}
