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
    public GameObject turretHeadGO;

    public GameObject[] aktiveKuler;

    public Vector3 ophavV3;

    public List<GameObject> kuler = new List<GameObject>();

    private V�penVariabler v�penVariabler;
    private Sj�AngrepRekkevidde rekkevidder;

    // Start is called before the first frame update
    void Start()
    {
        v�penVariabler = GetComponent<V�penVariabler>();
        rekkevidder = GetComponent<Sj�AngrepRekkevidde>();
    }

    // Update is called once per frame
    void Update()
    {

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
        turretHeadGO.transform.LookAt(spelarGO.transform);
    }

    void Skyt()
    {
        KuleSkript clone = Instantiate(v�penVariabler.kulaSkript[v�penVariabler.kulaBrukt], kuleSpawnPunkt.transform, false);
        
        clone.skade = v�penVariabler.skade;
        clone.fart = v�penVariabler.kuleFart;
        clone.tilbakeslagKraft = v�penVariabler.tilbakeslagKraft;
        clone.maksRekkevidde = rekkevidder.angrepRekkevidde;
        clone.ophavPosisjon = ophavV3;

        clone.transform.localScale = new Vector3(0.3f, 0.3f, 1.6f);

        FinnAktiveKuler();
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
        }
    }
}