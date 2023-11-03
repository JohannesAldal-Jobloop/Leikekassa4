using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TurretSkript : MonoBehaviour
{
    public float skadePÂTurret = 10;
    public float tilbakeslagKraftPÂTurret = 10;

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
        SjÂPÂSpelar();

        if (Time.time >= tidtilnesteskudd)
        {
            tidtilnesteskudd = Time.time + 1f / skytehastigheit;

            Skyt();

            Debug.Log("Skyte() aktivert");
        }
    }

    void SjÂPÂSpelar()
    {
        gameObject.transform.LookAt(spelarGO.transform);
    }

    void Skyt()
    {
        Instantiate(kuler[kulebrukt], kuleSpawnPunkt.transform);
        FinnAktiveKuler();
        SettVÂpenvariablerTilKulene();
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

    void SettVÂpenvariablerTilKulene()
    {
        kuleSkript = kuler[kulebrukt].GetComponent<KuleSkript>();

        kuleSkript.skade = skadePÂTurret;
        kuleSkript.tilbakeslagKraft = tilbakeslagKraftPÂTurret;

        //KuleSkript kuleSkript;

        //for (int i = 0; i < aktiveKuler.Length; i++)
        //{
        //    kuleSkript =  aktiveKuler[i].GetComponent<KuleSkript>();

        //    kuleSkript.FinnVÂpenVariabler("HodeTurret");
        //}
    }
}
