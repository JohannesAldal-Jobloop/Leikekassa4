using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropping : MonoBehaviour
{
    public float launchSpeed = 1;


    [SerializeField] private bool itemDropped = false;

    // Må skifta til å finne frå ein klasse med lister med alle items som kan bli droppa.
    public GameObject itemToDrop;

    private Vector3 parentPosistion;

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
        if (tarSkade.erDød && !itemDropped)
        {
            parentPosistion = gameObject.transform.position;

            Rigidbody itemRB;

            GameObject item = Instantiate(itemToDrop, gameObject.transform);
            item.transform.parent = null;
            item.transform.position = new Vector3(parentPosistion.x, (parentPosistion.y + 1), parentPosistion.z);
            item.transform.localScale = Vector3.one;

            itemRB = item.GetComponent<Rigidbody>();
            itemRB.AddForce(Vector3.up * launchSpeed, ForceMode.VelocityChange);

            itemDropped = true;
        }
    }
}
