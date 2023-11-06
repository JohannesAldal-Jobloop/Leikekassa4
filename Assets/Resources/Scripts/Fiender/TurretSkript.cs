using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TurretSkript : MonoBehaviour
{
    private float tidtilnesteskudd;
    public float hovetRotasjonsfart;

    public GameObject kuleSpawnPunkt;
    public GameObject spelarGO;
    public GameObject kulaTest;
    public GameObject spawnTest;

    public GameObject[] aktiveKuler;

    public List<GameObject> kuler = new List<GameObject>();

    private V�penVariabler v�penVariabler;
    private Sj�AngrepRekkevidde rekkevidder;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(kulaTest, kuleSpawnPunkt.transform);
        v�penVariabler = GetComponent<V�penVariabler>();
        rekkevidder = GetComponent<Sj�AngrepRekkevidde>();
    }

    // Update is called once per frame
    void Update()
    {
        Spawntest();

        if (rekkevidder.serLayerTarget)
        {
            Sj�P�Spelar();
        }
        

        if (rekkevidder.angripLayerTarget)
        {
            TurretSkyting();
        }
    }

    void Sj�P�Spelar()
    {
        gameObject.transform.LookAt(spelarGO.transform);
    }

    void Skyt()
    {
        KuleSkript clone = Instantiate(v�penVariabler.kulaSkript[v�penVariabler.kulaBrukt], kuleSpawnPunkt.transform, false);
        
        clone.skade = v�penVariabler.skade;
        clone.fart = v�penVariabler.fart;
        clone.tilbakeslagKraft = v�penVariabler.tilbakeslagKraft;
        clone.maksRekkevidde = v�penVariabler.maksRekkevidde;

        FinnAktiveKuler();
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

    void TurretSkyting()
    {
        if (Time.time >= tidtilnesteskudd)
        {
            tidtilnesteskudd = Time.time + 1f / v�penVariabler.angrepHastigheit;

            Skyt();

            Debug.Log("Skyte() aktivert");
        }
    }
}