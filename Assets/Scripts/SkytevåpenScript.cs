using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkytevåpenScript : MonoBehaviour
{
    public GameObject aktivtSiktepunkt;
    public GameObject aktivtVåpen;
    public GameObject kuleSpawnpunkt;

    public List<GameObject> kuleList = new List<GameObject>();
    public List<GameObject> våpenList = new List<GameObject>();
    public List<GameObject> siktepunktList = new List<GameObject>();

    public VåpenVariabler aktivVåpenVariabler;

    // Start is called before the first frame update
    void Start()
    {
        FinnAktivtVåpen();
        FinnAktivtSiktepunkt();
        FinnAktivVåpenVariabler();
    }

    // Update is called once per frame
    void Update()
    {
        FinnAktivtVåpen();
        FinnAktivtSiktepunkt();
        StartCoroutine("FullAutoSkyting");
        FinnAktivVåpenVariabler();
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

    void FinnAktivVåpenVariabler()
    {
        aktivVåpenVariabler = aktivtVåpen.GetComponent<VåpenVariabler>();
    }

    IEnumerator FullAutoSkyting()
    {
        if(Input.GetKey(KeyCode.Mouse0) && våpenList[1].activeSelf)
        {
            Debug.Log("AR1 skal skyte");
            Instantiate(kuleList[0], kuleSpawnpunkt.transform);
            yield return new WaitForSeconds(aktivVåpenVariabler.angrepHastigheit);
        }
    }
}
