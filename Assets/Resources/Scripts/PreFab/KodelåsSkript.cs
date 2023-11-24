using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KodelåsSkript : MonoBehaviour
{
    public string riktigKode = "0000";
    public string inputaKode = "";

    public float korLengeRiktig = 1;
    public float KorLengeFeil = 1;

    public Color baseFarge;
    public Color feilFarge;
    public Color riktigFarge;

    [HideInInspector] public bool erRiktig = false;

    private Renderer gameObjectRenderer;

    // Start is called before the first frame update
    void Start()
    {
        gameObjectRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(inputaKode.Length == riktigKode.Length)
        {
            StartCoroutine(KjekkOmKodeErRiktig());
        }
        else
        {
            gameObjectRenderer.material.color = baseFarge;
        }
    }

    IEnumerator KjekkOmKodeErRiktig()
    {
        if(inputaKode == riktigKode)
        {
            erRiktig = true;
            gameObjectRenderer.material.color = riktigFarge;

            yield return new WaitForSeconds(korLengeRiktig);
            erRiktig = false;

            inputaKode = "";

        }else
        {
            erRiktig = false;
            gameObjectRenderer.material.color = feilFarge;

            yield return new WaitForSeconds(KorLengeFeil);

            inputaKode = "";
        }
    }
}
