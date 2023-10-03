using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkytevåpenScript : MonoBehaviour
{
    public GameObject aktivtSiktepunkt;
    public GameObject aktivtVåpen;
    public GameObject aktivtKuleSpawnpunkt;

    public List<GameObject> kuleList = new List<GameObject>();
    public List<GameObject> våpenList = new List<GameObject>();
    public List<GameObject> siktepunktList = new List<GameObject>();
    public List<GameObject> kuleSpawnpunktList = new List<GameObject>();

    public VåpenVariabler aktivVåpenVariabler;

    // Start is called before the first frame update
    void Start()
    {
        FinnAktivtVåpen();
        FinnAktivtSiktepunkt();
        FinnAktivVåpenVariabler();
        FinnAktivKulespawnpunkt();
    }

    // Update is called once per frame
    void Update()
    {
        FinnAktivtVåpen();
        FinnAktivtSiktepunkt();
        FinnAktivKulespawnpunkt();
        FinnAktivVåpenVariabler();

        if(aktivVåpenVariabler.skyteModus == 1)
        {
            StartCoroutine("FullAutoSkyting");
        }else if(aktivVåpenVariabler.skyteModus == 2)
        {
            StartCoroutine("SemiAutoSkyting");
        }
        

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

    

    IEnumerator FullAutoSkyting()
    {
        if(Input.GetKey(KeyCode.Mouse0) && aktivVåpenVariabler.skyteModus == 1 && aktivtVåpen.activeSelf)
        {
            Debug.Log("Full auto skyting");
            Instantiate(kuleList[aktivVåpenVariabler.kulaBrukt], aktivtKuleSpawnpunkt.transform);
            yield return new WaitForSeconds(aktivVåpenVariabler.angrepHastigheit);
        }
    }

    IEnumerator SemiAutoSkyting()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && aktivVåpenVariabler.skyteModus == 2 && aktivtVåpen.activeSelf)
        {
            Debug.Log("Semi auto skyting");
            Instantiate(kuleList[aktivVåpenVariabler.kulaBrukt], aktivtKuleSpawnpunkt.transform);
            yield return new WaitForSeconds(aktivVåpenVariabler.angrepHastigheit);
        }
    }
}
