using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TurretSkript : MonoBehaviour
{
    public float skytehastigheit;
    private float tidtilnesteskudd;

    public GameObject kuleSpawnPunkt;
    public GameObject spelarGO;
    public GameObject kulaTest;
    public GameObject spawnTest;
    public List<GameObject> kuler = new List<GameObject>();   

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(kulaTest, kuleSpawnPunkt.transform);
    }

    // Update is called once per frame
    void Update()
    {
        Spawntest();
        //SjÂPÂSpelar();
        //Skyt();
        if (Time.time >= tidtilnesteskudd)
        {
            tidtilnesteskudd = Time.time + 1f / skytehastigheit;

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

    void Spawntest()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            Instantiate(kulaTest, kuleSpawnPunkt.transform);
        }
    }
}
