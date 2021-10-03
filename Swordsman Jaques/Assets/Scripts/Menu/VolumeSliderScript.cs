using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSliderScript : MonoBehaviour
{
    Slider Volume;
    float LastVol;

    void Start()
    {
        Volume = GetComponent<Slider>();
        if (name == "SFXSlider")
            Volume.value = PlayerPrefs.GetFloat("SFX Volume");
        else
            Volume.value = PlayerPrefs.GetFloat("Music Volume");
    }

    void Update()
    {
        if (LastVol != Volume.value)
        {
            LastVol = Volume.value;
            if (name == "SFXSlider")
                PlayerPrefs.SetFloat("SFX Volume", Volume.value);
            else
                PlayerPrefs.SetFloat("Music Volume", Volume.value);
        }
    }
}
