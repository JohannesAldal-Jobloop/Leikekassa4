using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    public bool isActive = true;

    [SerializeField] private float rotationSpeed = 1.0f;

    [SerializeField] private Vector3 spinnVector3;

    //public GameObject gameObjectToSpinn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(spinnVector3, rotationSpeed);
    }

    private void SpinnGameObject(GameObject spinnGO, float spinnSpeed, /*string spinnDirection,*/ Vector3 spinnVector3)
    {
        spinnGO.transform.Rotate(spinnVector3, spinnSpeed);

        //if (spinnDirection == "x")
        //{
            
        //}
        //else if(spinnDirection == "y")
        //{

        //}
        //else if (spinnDirection == "z")
        //{

        //}
    }
}
