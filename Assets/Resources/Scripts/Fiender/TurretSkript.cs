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

    public VåpenVariabler våpenVariabler;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(kulaTest, kuleSpawnPunkt.transform);
        våpenVariabler = GetComponent<VåpenVariabler>();
    }

    // Update is called once per frame
    void Update()
    {
        Spawntest();
        SjåPåSpelar();

        if (Time.time >= tidtilnesteskudd)
        {
            tidtilnesteskudd = Time.time + 1f / våpenVariabler.angrepHastigheit;

            Skyt();

            Debug.Log("Skyte() aktivert");
        }
    }

    void SjåPåSpelar()
    {
        gameObject.transform.LookAt(spelarGO.transform);
    }

    void Skyt()
    {
        KuleSkript clone = Instantiate(våpenVariabler.kulaSkript[våpenVariabler.kulaBrukt], kuleSpawnPunkt.transform, false);
        
        clone.skade = våpenVariabler.skade;
        clone.fart = våpenVariabler.fart;
        clone.tilbakeslagKraft = våpenVariabler.tilbakeslagKraft;
        clone.maksRekkevidde = våpenVariabler.maksRekkevidde;

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
}