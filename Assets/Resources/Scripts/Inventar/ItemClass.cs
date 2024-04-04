using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemClass : MonoBehaviour
{
    public bool interactPickup = false;
    public bool holdInteract = false;

    // 1000 = 20 sec
    public float holdInteractLenghtSec = 5;
    
    public string[] itemTags = { };
    public string itemName;
    public string itemDescription;
    public Sprite itemPreviewImage;
    public Sprite itemDescriptionImage;
    public int itemValue;
    public int damagePhysical   = 0;
    public int damageMagic      = 0;
    public int damageFire       = 0;
    public int damageSpectral   = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
