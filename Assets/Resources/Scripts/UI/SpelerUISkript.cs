using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpelerUISkript : MonoBehaviour
{
    public GameObject er_død_UI;
    public GameObject i_Live_UI;
    public GameObject pauseKjerm_UI;
    public GameObject inventory_UI;

    public Slider livBarGO;
    public GameObject overSkjoldBarGO;
    public Slider overSkjoldBarSlider;
    public GameObject giftBarGO;
    public Slider giftBar;

    public GameObject spelarGO;

    public TarSkade tarSkadeSpeler;
    public LivFunksjoner livFunksjonerSpeler;
    public PausSpel pausSpel;
    public InventoryScript inventoryScript;

    // Start is called before the first frame update
    void Start()
    {
        spelarGO = GameObject.Find("SpelerFPS");
        tarSkadeSpeler = spelarGO.GetComponent<TarSkade>();
        livFunksjonerSpeler = spelarGO.GetComponent <LivFunksjoner>();
        overSkjoldBarSlider = overSkjoldBarGO.GetComponent<Slider>();
        pausSpel = GetComponent<PausSpel>();
        inventoryScript = GetComponent<InventoryScript>();
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
        GiftBarUpdate();

        if (!tarSkadeSpeler.erDød && !inventoryScript.inventoryOpen) 
        { 
            er_død_UI.SetActive(false);
            i_Live_UI.SetActive(true);

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            er_død_UI.SetActive(true);
            i_Live_UI.SetActive(false);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (pausSpel.erPausa)
        {
            pauseKjerm_UI.SetActive(true);

        }
        else
        {
            pauseKjerm_UI.SetActive(false);
        }

        if(inventoryScript.inventoryOpen && !pausSpel.erPausa)
        {
            i_Live_UI.SetActive(false);
            inventory_UI.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }else
        {
            i_Live_UI.SetActive(true);
            inventory_UI.SetActive(false);
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

    void GiftBarUpdate()
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
