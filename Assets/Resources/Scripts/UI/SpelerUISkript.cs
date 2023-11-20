using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpelerUISkript : MonoBehaviour
{
    public GameObject er_d�d_UI;
    public GameObject i_Live_UI;
    public GameObject pauseKjermUI;

    public Slider livBarGO;
    public GameObject overSkjoldBarGO;
    public Slider overSkjoldBarSlider;
    public GameObject giftBarGO;
    public Slider giftBar;

    public GameObject spelarGO;

    public TarSkade tarSkadeSpeler;
    public LivFunksjoner livFunksjonerSpeler;
    public PausSpel pausSpel;

    // Start is called before the first frame update
    void Start()
    {
        spelarGO = GameObject.Find("SpelerFPS");
        tarSkadeSpeler = spelarGO.GetComponent<TarSkade>();
        livFunksjonerSpeler = spelarGO.GetComponent <LivFunksjoner>();
        overSkjoldBarSlider = overSkjoldBarGO.GetComponent<Slider>();
        pausSpel = GetComponent<PausSpel>();
    }

    // Update is called once per frame
    void Update()
    {
        OpptaterSpelerUI();
    }

    void OpptaterSpelerUI()
    {
        LivBarUpdate();
        OverSkjoldUpdate();
        GiftBarUptdate();

        if (!tarSkadeSpeler.erD�d) 
        { 
            er_d�d_UI.SetActive(false);
            i_Live_UI.SetActive(true);

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            er_d�d_UI.SetActive(true);
            i_Live_UI.SetActive(false);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (pausSpel.erPausa)
        {
            pauseKjermUI.SetActive(true);
        }
        else
        {
            pauseKjermUI.SetActive(false);
        }
    }

    void LivBarUpdate()
    {
        livBarGO.maxValue = tarSkadeSpeler.maksLiv;
        livBarGO.value = tarSkadeSpeler.liv;
    }

    void OverSkjoldUpdate()
    {
        if(livFunksjonerSpeler.overSkjoldMengde > 0)
        {
            overSkjoldBarGO.SetActive(true);
            overSkjoldBarSlider.maxValue = livFunksjonerSpeler.overSkjoldMaks;
            overSkjoldBarSlider.value = livFunksjonerSpeler.overSkjoldMengde;
        }
        else
        {
            overSkjoldBarGO.SetActive(false);
            livFunksjonerSpeler.overSkjoldMengde = 0;
        }

        if(livFunksjonerSpeler.overSkjoldMengde <= 0)
        {
            overSkjoldBarGO.SetActive(false);
        }
    }

    void GiftBarUptdate()
    {
        if(livFunksjonerSpeler.giftOppbygging > 0)
        {
            giftBarGO.SetActive(true);
        }
        else
        {
            giftBarGO.SetActive(false);
        }

        giftBar.maxValue = livFunksjonerSpeler.giftResistanse;
        giftBar.value = livFunksjonerSpeler.giftOppbygging;

    }
}
