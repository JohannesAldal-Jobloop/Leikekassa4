using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HovedMenySkript : MonoBehaviour
{
    public GameObject hovedSkjerm;
    public GameObject innstillinger;

    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "HovedMeny")
        {
            hovedSkjerm = GameObject.Find("HovedSkjerm");
            innstillinger = GameObject.Find("Innstillinger");
            innstillinger.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartSpel()
    {
        SceneManager.LoadSceneAsync("Leikekassa", LoadSceneMode.Single);
    }

    public void AvsluttSpel()
    {
        Debug.Log("Avsluttter spel...");
        Application.Quit();
    }

    public void SkiftTilInstillinger()
    {
        hovedSkjerm.SetActive(false);
        innstillinger.SetActive(true);
    }

    public void Tilbake(GameObject pastScreen)
    {
        innstillinger.SetActive(false);
        hovedSkjerm.SetActive(true);
    }

}
