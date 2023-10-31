using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TurretSkript : MonoBehaviour
{
    public float skytehastigheit;
    private float tidTilNesteSkudd;

    public GameObject kuleSpawnPunkt;
    public GameObject spelarGO;
    public List<GameObject> kuler = new List<GameObject>();   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate(kuler[0], kuleSpawnPunkt.transform);
        SjÂPÂSpelar();

        if (Time.time >= tidTilNesteSkudd)
        {
            tidTilNesteSkudd = Time.time + 1f / skytehastigheit;

            Skyt();
        }
    }

    void SjÂPÂSpelar()
    {
        gameObject.transform.LookAt(spelarGO.transform);
    }

    void Skyt()
    {
        Instantiate(kuler[0], kuleSpawnPunkt.transform);
    }
}
