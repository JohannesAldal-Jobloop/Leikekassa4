using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KodelåsSkript : MonoBehaviour
{
    public string riktigKode = "0000";
    public string inputaKode = "";

    public float korLengeRiktig = 1;
    public float KorLengeFeil = 1;

    public GameObject tingSomSkalÅpnesGO;
    public GameObject riktigViser;

    public Color baseFarge;
    public Color feilFarge;
    public Color riktigFarge;

    public TextMeshPro riktigViserTekst;

    [HideInInspector] public bool erRiktig = false;

    private Renderer riktigViserRenderer;

    // Start is called before the first frame update
    void Start()
    {
        riktigViserRenderer = riktigViser.GetComponent<Renderer>();
        riktigViserTekst.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(riktigViserTekst.text.Length = riktigKode.Length)
        {

        }


        if(inputaKode.Length == riktigKode.Length && !erRiktig)
        {
            StartCoroutine(KjekkOmKodeErRiktig());
        }
        else if(inputaKode == "")
        {
            riktigViserRenderer.material.color = baseFarge;
        }
    }

    IEnumerator KjekkOmKodeErRiktig()
    {
        if(inputaKode == riktigKode)
        {
            erRiktig = true;
            riktigViserRenderer.material.color = riktigFarge;
            tingSomSkalÅpnesGO.SetActive(!erRiktig);

            yield return new WaitForSeconds(korLengeRiktig);

            erRiktig = false;
            tingSomSkalÅpnesGO.SetActive(!erRiktig);
            inputaKode = "";
            riktigViserTekst.text = "";

        }
        else
        {
            erRiktig = false;
            riktigViserRenderer.material.color = feilFarge;

            tingSomSkalÅpnesGO.SetActive(!erRiktig);

            yield return new WaitForSeconds(KorLengeFeil);

            inputaKode = "";
            riktigViserTekst.text = "";
        }
    }
}
