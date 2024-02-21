using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public float soundVolume = 0;

    private Slider soundSlider;

    // Start is called before the first frame update
    void Start()
    {
        soundSlider = GameObject.Find("Lyd").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateSoundVolume()
    {
        soundVolume = soundSlider.value;
        Debug.Log("SoundVolume: " + soundVolume);
    }
}
