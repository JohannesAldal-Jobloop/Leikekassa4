using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkytevåpenUI : MonoBehaviour
{
    private bool reloadAnimasjonStarta;

    public TextMeshProUGUI ammoViser;

    public SkytevåpenScript skytevåpenScript;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Leikekassa")
        {
            OpptaterSkytevåpenUI();
        }
        
    }

    void OpptaterSkytevåpenUI()
    {
        if (skytevåpenScript.reloader && !reloadAnimasjonStarta)
        {
            StartCoroutine(ReloadTekstAnimasjon());
        }
        else if(!reloadAnimasjonStarta)
        {
            ammoViser.text = skytevåpenScript.aktivVåpenVariabler.magasinMengdeNo.ToString();
        }
        
    }

    IEnumerator ReloadTekstAnimasjon()
    {
        if (skytevåpenScript.reloader)
        {
            reloadAnimasjonStarta = true;
            ammoViser.text = ".";
            yield return new WaitForSeconds(skytevåpenScript.aktivVåpenVariabler.reloadFart / 3);
            ammoViser.text = "..";
            yield return new WaitForSeconds(skytevåpenScript.aktivVåpenVariabler.reloadFart / 3);
            ammoViser.text = "...";
            yield return new WaitForSeconds(skytevåpenScript.aktivVåpenVariabler.reloadFart / 3);
            reloadAnimasjonStarta = false;
        }
        
    }
}
