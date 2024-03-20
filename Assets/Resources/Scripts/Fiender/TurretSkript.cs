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

    private VåpenVariabler våpenVariabler;
    private SjåAngrepRekkevidde rekkevidder;

    // Start is called before the first frame update
    void Start()
    {
        våpenVariabler = GetComponent<VåpenVariabler>();
        rekkevidder = GetComponent<SjåAngrepRekkevidde>();
    }

    // Update is called once per frame
    void Update()
    {

        if (rekkevidder.serLayerTarget)
        {
            SjåPåSpelar();
        }


        if (rekkevidder.angripLayerTarget)
        {
            TurretSkyting();
        }
    }

    void SjåPåSpelar()
    {
        turretHeadGO.transform.LookAt(spelarGO.transform);
    }

    void Skyt()
    {
        KuleSkript clone = Instantiate(våpenVariabler.kulaSkript[våpenVariabler.kulaBrukt], kuleSpawnPunkt.transform, false);
        
        clone.skade = våpenVariabler.skade;
        clone.fart = våpenVariabler.kuleFart;
        clone.tilbakeslagKraft = våpenVariabler.tilbakeslagKraft;
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
            tidtilnesteskudd = Time.time + 1f / våpenVariabler.angrepHastigheit;

            Skyt();
        }
    }
}