using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TurretSkript : MonoBehaviour
{
    public float skadeP�Turret = 10;
    public float tilbakeslagKraftP�Turret = 10;

    public float skytehastigheit;
    private float tidtilnesteskudd;
    public float maksRekkevidde;

    public int kulebrukt = 0;;

    public GameObject kuleSpawnPunkt;
    public GameObject spelarGO;
    public GameObject kulaTest;
    public GameObject spawnTest;

    public GameObject[] aktiveKuler;

    public List<GameObject> kuler = new List<GameObject>();

    private KuleSkript kuleSkript;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(kulaTest, kuleSpawnPunkt.transform);
    }

    // Update is called once per frame
    void Update()
    {
        Spawntest();
        Sj�P�Spelar();

        if (Time.time >= tidtilnesteskudd)
        {
            tidtilnesteskudd = Time.time + 1f / skytehastigheit;

            Skyt();

            Debug.Log("Skyte() aktivert");
        }
    }

    void Sj�P�Spelar()
    {
        gameObject.transform.LookAt(spelarGO.transform);
    }

    void Skyt()
    {
        Instantiate(kuler[kulebrukt], kuleSpawnPunkt.transform);
        FinnAktiveKuler();
        SettV�penvariablerTilKulene();
        Debug.Log("Skal ha skytt ei kula");
    }

    void Spawntest()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            Instantiate(kulaTest, kuleSpawnPunkt.transform);
        }
    }

    void FinnAktiveKuler()
    {
        aktiveKuler = GameObject.FindGameObjectsWithTag("KulaFiende");
    }

    void SettV�penvariablerTilKulene()
    {
        kuleSkript = kuler[kulebrukt].GetComponent<KuleSkript>();

        kuleSkript.skade = skadeP�Turret;
        kuleSkript.tilbakeslagKraft = tilbakeslagKraftP�Turret;

        //KuleSkript kuleSkript;

        //for (int i = 0; i < aktiveKuler.Length; i++)
        //{
        //    kuleSkript =  aktiveKuler[i].GetComponent<KuleSkript>();

        //    kuleSkript.FinnV�penVariabler("HodeTurret");
        //}
    }
}
