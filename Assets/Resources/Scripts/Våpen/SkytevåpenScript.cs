using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkytevåpenScript : MonoBehaviour
{
    private float nesteTidSkyte = 0;

    public bool prosjektilSkyting = true;
    public bool reloader = false;
    public bool sikter = false;
    public bool sikterOktRekkevidde = false;

    public GameObject aktivtSiktepunkt;
    public GameObject aktivtVåpen;
    public GameObject aktivtKuleSpawnpunkt;

    public GameObject[] aktiveKuler;

    public Camera fpsKamera;

    private int rayIgnorerLayer = 0 << 6;

    public List<GameObject> kuleList = new List<GameObject>();
    public List<GameObject> våpenList = new List<GameObject>();
    public List<GameObject> siktepunktList = new List<GameObject>();
    public List<GameObject> kuleSpawnpunktList = new List<GameObject>();

    public VåpenVariabler aktivVåpenVariabler;
    private SpelerDødSkript spelerDødSkript;

    // Start is called before the first frame update
    void Start()
    {
        FinnAlleAktiveGameobjectForScript();
        aktivVåpenVariabler.magasinMengdeNo = aktivVåpenVariabler.magasinKapasitet;
        spelerDødSkript = GameObject.Find("SpelerFPS").GetComponent<SpelerDødSkript>();
    }

    // Update is called once per frame
    void Update()
    {
        FinnAlleAktiveGameobjectForScript();

        if (!spelerDødSkript.respawner)
        {
            if (aktivVåpenVariabler.skyteModus == 1 && aktivVåpenVariabler.magasinMengdeNo != 0 && !reloader)
            {
                FullAutoSkyting();
            }
            else if (aktivVåpenVariabler.skyteModus == 2 && aktivVåpenVariabler.magasinMengdeNo != 0 && !reloader)
            {
                SemiAutoSkyting();
            }
            else if (aktivVåpenVariabler.skyteModus == 3 && aktivVåpenVariabler.magasinMengdeNo != 0 && !reloader)
            {
                laserSkyting();
            }

            if (Input.GetKey(KeyCode.R))
            {
                StartCoroutine(Reload());
            }

            OkMaksRekkeviddeVedSikting();
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
            KuleSkript clone = Instantiate(aktivVåpenVariabler.kulaSkript[aktivVåpenVariabler.kulaBrukt], aktivtKuleSpawnpunkt.transform);

            clone.skade = aktivVåpenVariabler.skade;
            clone.fart = aktivVåpenVariabler.kuleFart;
            clone.tilbakeslagKraft = aktivVåpenVariabler.tilbakeslagKraft;
            clone.maksRekkevidde = aktivVåpenVariabler.maksRekkevidde;
            clone.skyteModus = aktivVåpenVariabler.skyteModus;

        aktivVåpenVariabler.magasinMengdeNo--;

            FinnAktiveKuler();
        
    }
    void RaycastShooting()
    {
        rayIgnorerLayer = ~rayIgnorerLayer;

        RaycastHit rayTreff;
        if(Physics.Raycast(fpsKamera.transform.position, fpsKamera.transform.forward, out rayTreff, aktivVåpenVariabler.maksRekkevidde, rayIgnorerLayer))
        {
            TarSkade tarSkade = rayTreff.transform.GetComponent<TarSkade>();
            TarSkadeHitboks tarSkadeHitboks = rayTreff.transform.GetComponent<TarSkadeHitboks>();

            if(tarSkade != null)
            {
                tarSkade.TaSkade(aktivVåpenVariabler.skade);
            }else if(tarSkadeHitboks != null)
            {
                tarSkadeHitboks.RedirektSkadeTilTarSkadeParent(aktivVåpenVariabler.skade);
            }

            if(rayTreff.rigidbody != null)
            {
                rayTreff.rigidbody.AddForce(-rayTreff.normal * aktivVåpenVariabler.tilbakeslagKraft);
            }

            ParticleSystem treffEffekt = Instantiate(aktivVåpenVariabler.treffEffekt, rayTreff.point, Quaternion.LookRotation(rayTreff.normal));
            Destroy(treffEffekt, 1f );
        }
        aktivVåpenVariabler.magasinMengdeNo--;
    }

    public void FullAutoSkyting()
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

    public void SemiAutoSkyting()
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

    public void laserSkyting()
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
        aktiveKuler = GameObject.FindGameObjectsWithTag("KulaFiende");
    }

    void OkMaksRekkeviddeVedSikting()
    {
        if (sikter && !sikterOktRekkevidde)
        {
            aktivVåpenVariabler.maksRekkevidde *= aktivVåpenVariabler.sikteRekkeviddeØkning;
            sikterOktRekkevidde = true;
        }
        else if(!sikter)
        {

            sikterOktRekkevidde = false;
            aktivVåpenVariabler.maksRekkevidde = aktivVåpenVariabler.maksRekkeviddeOrginal;
        }
    }
}
