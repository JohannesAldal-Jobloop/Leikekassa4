using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpelerDødSkript : MonoBehaviour
{
    public int aktivtSpelarSpawnpointIndex = 0;

    public bool respawner = false;

    private Quaternion aktivtSpelarSpawnpointRotasjon;

    public Transform aktivSpelarSpawnpointTransform;

    public List<Transform> spelarSpawnpointer = new List<Transform>();

    public GameObject spelarKropp;
    public GameObject spelerVåpenarm;
    public GameObject spelerGO;

    private TarSkade spelerTarSkadeSkript;
    private LivFunksjoner livFunksjoner;
    private KamerebevegelseFPS kamerebevegelseFPS;

    // Start is called before the first frame update
    void Start()
    {
        spelerTarSkadeSkript = GetComponent<TarSkade>();
        livFunksjoner = GetComponent<LivFunksjoner>();
        kamerebevegelseFPS = spelerGO.GetComponent<KamerebevegelseFPS>();

        VisKropp();

        Respawn();
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
        kamerebevegelseFPS.harSettSpawnTotasjonY = false;

        Time.timeScale = 1.0f;

        spelerTarSkadeSkript.liv = spelerTarSkadeSkript.maksLiv;
        spelerTarSkadeSkript.livFunksjoner.StartMedOverSkjold();
        
        transform.position = aktivSpelarSpawnpointTransform.position;
        transform.rotation = aktivSpelarSpawnpointTransform.rotation;

        

        

        yield return new WaitForSeconds(.01f);
        VisKropp();
        kamerebevegelseFPS.spawnRotasjonY = spelerGO.transform.localEulerAngles.y;
        Debug.Log(kamerebevegelseFPS.spawnRotasjonY);


        yield return new WaitForSeconds(5);
        respawner = false;
    }

    public void Respawn()
    {
        FinnAktivSpelerSpawnpointRotasjon();
        FinnAktivSpelerSpawnpointtransform();

        livFunksjoner.giftOppbygging = 0;
        livFunksjoner.tidGåttUtenSkade = 0;


        StartCoroutine(RespawnCourutine());
    }

    void FinnAktivSpelerSpawnpointtransform()
    {
        aktivSpelarSpawnpointTransform = spelarSpawnpointer[aktivtSpelarSpawnpointIndex];
    }

    void FinnAktivSpelerSpawnpointRotasjon()
    {
        aktivtSpelarSpawnpointRotasjon = new Quaternion(

            spelarSpawnpointer[aktivtSpelarSpawnpointIndex].rotation.x,
            spelarSpawnpointer[aktivtSpelarSpawnpointIndex].rotation.y,
            spelarSpawnpointer[aktivtSpelarSpawnpointIndex].rotation.z,
            spelarSpawnpointer[aktivtSpelarSpawnpointIndex].rotation.w
            );
    }
}
