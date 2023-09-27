using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkytevåpenScript : MonoBehaviour
{
    public float skytehastigheit = 0.1f;

    public GameObject aktivtSiktepunkt;
    public GameObject aktivtVåpen;
    public GameObject kuleSpawnpunkt;

    public List<GameObject> kuleList = new List<GameObject>();
    public List<GameObject> våpenList = new List<GameObject>();
    public List<GameObject> siktepunktList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        FinnAktivtVåpen();
        FinnAktivtSiktepunkt();
    }

    // Update is called once per frame
    void Update()
    {
        FullAutoSkyting();
        FinnAktivtVåpen();
        FinnAktivtSiktepunkt();
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

    IEnumerator FullAutoSkyting()
    {
        if(Input.GetKeyUp(KeyCode.Mouse0) && våpenList[1].activeSelf)
        {
            Instantiate(kuleList[0], kuleSpawnpunkt.transform);
            yield return new WaitForSeconds(skytehastigheit);
        }
    }
}
