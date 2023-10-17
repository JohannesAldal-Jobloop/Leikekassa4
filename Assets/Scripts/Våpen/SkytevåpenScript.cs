using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkytevåpenScript : MonoBehaviour
{
    private float nesteTidSkyte = 0;

    public bool prosjektilSkyting = true;
    public bool reloader = false;

    public GameObject aktivtSiktepunkt;
    public GameObject aktivtVåpen;
    public GameObject aktivtKuleSpawnpunkt;

    public Camera fpsKamera;

    public List<GameObject> kuleList = new List<GameObject>();
    public List<GameObject> våpenList = new List<GameObject>();
    public List<GameObject> siktepunktList = new List<GameObject>();
    public List<GameObject> kuleSpawnpunktList = new List<GameObject>();

    public GameObject[] aktiveKuler;

    public VåpenVariabler aktivVåpenVariabler;

    // Start is called before the first frame update
    void Start()
    {
        FinnAlleAktiveGameobjectForScript();
        aktivVåpenVariabler.magasinMengdeNo = aktivVåpenVariabler.magasinKapasitet;
    }

    // Update is called once per frame
    void Update()
    {
        FinnAktivtVåpen();
        FinnAktivtSiktepunkt();
        FinnAktivKulespawnpunkt();
        FinnAktivVåpenVariabler();


        if (aktivVåpenVariabler.skyteModus == 1 && aktivVåpenVariabler.magasinMengdeNo != 0 && !reloader)
        {
            FullAutoSkyting();
        }
        else if(aktivVåpenVariabler.skyteModus == 2 && aktivVåpenVariabler.magasinMengdeNo != 0 && !reloader)
        {
            SemiAutoSkyting();
        }
        else if(aktivVåpenVariabler.skyteModus == 3 && aktivVåpenVariabler.magasinMengdeNo != 0 && !reloader)
        {
            laserSkyting();
        }

        if (Input.GetKey(KeyCode.R))
        {
            StartCoroutine(Reload());
        }
        
    }

    void FinnAlleAktiveGameobjectForScript()
    {
        FinnAktivtVåpen();
        FinnAktivtSiktepunkt();
        FinnAktivVåpenVariabler();
        FinnAktivKulespawnpunkt();
    }

    void FinnAktivtVåpen()
    {
        for (int i = 0; i < våpenList.Count; i++)
        {
            if (våpenList[i].activeSelf == true)
            {
                aktivtVåpen = våpenList[i];
            }
        }
    }

    void FinnAktivtSiktepunkt()
    {
        for (int i = 0; i < siktepunktList.Count; i++)
        {
            if (siktepunktList[i].activeSelf == true)
            {
                aktivtSiktepunkt = siktepunktList[i];
            }
        }
    }

    void FinnAktivKulespawnpunkt()
    {
        for (int i = 0; i < kuleSpawnpunktList.Count; i++)
        {
            if (kuleSpawnpunktList[i].activeInHierarchy == true)
            {
                aktivtKuleSpawnpunkt = kuleSpawnpunktList[i];
            }
        }
    }

    void FinnAktivVåpenVariabler()
    {
        aktivVåpenVariabler = aktivtVåpen.GetComponent<VåpenVariabler>();
    }

    IEnumerator Reload()
    {
        reloader = true;
        yield return new WaitForSeconds(aktivVåpenVariabler.reloadFart);
        aktivVåpenVariabler.magasinMengdeNo = aktivVåpenVariabler.magasinKapasitet;
        reloader = false;
    }

    void SpawnBullet()
    {
        Instantiate(kuleList[aktivVåpenVariabler.kulaBrukt], aktivtKuleSpawnpunkt.transform);
        aktivVåpenVariabler.magasinMengdeNo -= 1;
    }
    void RaycastShooting()
    {
        RaycastHit rayTreff;
        if(Physics.Raycast(fpsKamera.transform.position, fpsKamera.transform.forward, out rayTreff, aktivVåpenVariabler.maxRekevidde))
        {
            Debug.Log(rayTreff.transform.name);

            TarSkade tarSkade = rayTreff.transform.GetComponent<TarSkade>();

            if(tarSkade != null)
            {
                tarSkade.TaSkade(aktivVåpenVariabler.skade);
            }

            if(rayTreff.rigidbody != null)
            {
                rayTreff.rigidbody.AddForce(-rayTreff.normal * aktivVåpenVariabler.tilbakeslagKraft);
            }

            ParticleSystem treffEffekt = Instantiate(aktivVåpenVariabler.treffEffekt, rayTreff.point, Quaternion.LookRotation(rayTreff.normal));
            Destroy(treffEffekt, 1f );
        }
        aktivVåpenVariabler.magasinMengdeNo -= 1;
    }

    void FullAutoSkyting()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Time.time >= nesteTidSkyte)
        {
            nesteTidSkyte = Time.time + 1f / aktivVåpenVariabler.angrepHastigheit;
            if (prosjektilSkyting)
            {
                SpawnBullet();
            }
            else
            {
                RaycastShooting();
            }
            
        }
    }

    void SemiAutoSkyting()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time >= nesteTidSkyte)
        {
            nesteTidSkyte = Time.time + 1f / aktivVåpenVariabler.angrepHastigheit;
            if (prosjektilSkyting)
            {
                SpawnBullet();
            }
            else
            {
                RaycastShooting();
            }
        }
        
    }

    void laserSkyting()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Time.time >= nesteTidSkyte)
        {
            nesteTidSkyte = Time.time + 1f / aktivVåpenVariabler.angrepHastigheit;
            if (prosjektilSkyting)
            {
                SpawnBullet();
            }
            else
            {
                RaycastShooting();
            }
        }
        else
        {
            FinnAktiveKuler();

            for(int i = 0; i < aktiveKuler.Length; i++)
            {
                Destroy(aktiveKuler[i]);
            }
        }
    }

    void FinnAktiveKuler()
    {
        Debug.Log("Prøver å finne aktive kuler.");
        aktiveKuler = GameObject.FindGameObjectsWithTag("Kula");
        
    }
}
