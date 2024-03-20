using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropping : MonoBehaviour
{

    [SerializeField] private bool itemDropped = false;

    public GameObject itemToDrop;

    private TarSkade tarSkade;

    // Start is called before the first frame update
    void Start()
    {
        tarSkade = gameObject.GetComponent<TarSkade>();
    }

    // Update is called once per frame
    void Update()
    {
        DropOnDeath();
    }

    private void DropOnDeath()
    {
        if(tarSkade.erDød)
        {
            Instantiate(itemToDrop, gameObject.transform);
        }
    }
}
