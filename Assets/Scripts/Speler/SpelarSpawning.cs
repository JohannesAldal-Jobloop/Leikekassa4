using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpelarSpawning : MonoBehaviour
{
    public int aktivtSpelarSpawnpointIndex = 0;

    public bool respawner = false;

    private Vector3 aktivtSpelarSpawnpointRotasjon;

    public Transform aktivSpelarSpawnpointTransform;

    public List<Transform> spelarSpawnpointer = new List<Transform>();

    private TarSkade spelerTarSkadeSkript;
    private SpelerDødSkript spelerDødSkript;

    // Start is called before the first frame update
    void Start()
    {
        spelerTarSkadeSkript = GameObject.Find("SpelerFPS").GetComponent<TarSkade>();
        spelerDødSkript = GameObject.Find("SpelerFPS").GetComponent<SpelerDødSkript>();

        StartCoroutine(RespawnCourutine());
    }

    // Update is called once per frame
    void Update()
    {
        FinnAktivSpelerSpawnpointtransform();
        FinnAktivSpelerSpawnpointRotasjon();
    }

    public IEnumerator RespawnCourutine()
    {
        Debug.Log("Respawn starta");
        respawner = true;

        spelerTarSkadeSkript.ResetLiv();

        Time.timeScale = 1.0f;

        transform.eulerAngles = aktivtSpelarSpawnpointRotasjon;
        transform.position = aktivSpelarSpawnpointTransform.position;

        yield return new WaitForSeconds(.01f);

        spelerDødSkript.VisKropp();


        yield return new WaitForSeconds(1);
        respawner = false;
        Debug.Log("Respawn ferdig");
    }

    public void Respawn()
    {
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
