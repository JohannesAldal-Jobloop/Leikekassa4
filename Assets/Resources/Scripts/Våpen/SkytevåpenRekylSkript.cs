using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkytevåpenRekylSkript : MonoBehaviour
{
    public bool harRekyl = false;

    private Vector3 rotasjonsNo;
    private Vector3 rotasjonsMål;

    [SerializeField] private float rekylX;
    [SerializeField] private float rekylY;
    [SerializeField] private float rekylZ;

    [SerializeField] private float snappyness;
    [SerializeField] private float returnFart;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotasjonsMål = Vector3.Lerp(rotasjonsMål, Vector3.zero, returnFart * Time.deltaTime);
        rotasjonsNo = Vector3.Slerp(rotasjonsNo, rotasjonsMål, snappyness * Time.deltaTime);
        transform.localRotation = Quaternion.Euler(rotasjonsNo);

    }

    public void Rekyl()
    {
        

        rotasjonsMål += new Vector3(rekylX, Random.Range(-rekylY, rekylY), Random.Range(-rekylZ, rekylZ));
    }
}
