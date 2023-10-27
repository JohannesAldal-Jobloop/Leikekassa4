using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TarSkade : MonoBehaviour
{
    /* Lag ein liste som inneholder GameObjects med colliders.
     * Dette blir hitboksene til det GameObjectet som dett skripte er koble til.
     */

    /* For at dette skripte skal virke:
     * Collider.
     */

    public float maksLiv = 10;
    public float liv = 10;

    private string searchTag = "taSkadeHitboks";

    public bool erD�d = false;

   // public GameObject gameOverScreen;

    public List<Collider> taSkadeCollidersList = new List<Collider>();
    public List<Collider> gjerSkadeCollidersList = new List<Collider>();
    public List<GameObject> actors = new List<GameObject> ();

    private TarSkadeHitboks hitboks;
    private LivFunksjoner livFunksjoner;

    // Start is called before the first frame update
    void Start()
    {
        livFunksjoner = GetComponent<LivFunksjoner>();

        if (searchTag != null)
        {
            FindObjectwithTag(searchTag);
            FinnTaSkadeHitbokser();
        }
    }

    // Update is called once per frame
    void Update()
    {
        SkjekkOmHarLiv();
    }

    public void TaSkade(float skade)
    {
        livFunksjoner.tidG�ttUtenSkade = 0;

        liv -= skade;

        if(liv <= 0)
        {
            erD�d = true;

            if(gameObject.layer == 3)
            {
                Debug.Log("Speler Er d�d :(");
                Time.timeScale = 0;
            }
            else
            {
                SlettSegSj�lv();
            }

        }
        else
        {
            erD�d = false;
        }
    }

    void SlettSegSj�lv()
    {
        Destroy(gameObject);
    }

    //*****Fann p� nettet*****
    void FindObjectwithTag(string _tag)
    {
        actors.Clear();
        Transform parent = transform;
        GetChildObject(parent, _tag);
    }

    void GetChildObject(Transform parent, string _tag)
        {
            for (int i = 0; i < parent.childCount; i++)
            {
                Transform child = parent.GetChild(i);
                if (child.tag == _tag)
                {
                    actors.Add(child.gameObject);
                }
                if (child.childCount > 0)
                {
                    GetChildObject(child, _tag);
                }
            }
        }
    //************************

    void FinnTaSkadeHitbokser()
    {
        for(int i = 0; i < actors.Count; i++)
        {
            taSkadeCollidersList.Add(actors[i].GetComponent<Collider>());
            hitboks = actors[i].GetComponent<TarSkadeHitboks>();

            hitboks.tarSkadeParent = gameObject.GetComponent<TarSkade>();
        }
    }

    void SkjekkOmHarLiv()
    {
        if(liv <= 0)
        {
            erD�d = true;
            Time.timeScale = 0;
        }
        else
        {
            erD�d = false;
        }
    }
}
