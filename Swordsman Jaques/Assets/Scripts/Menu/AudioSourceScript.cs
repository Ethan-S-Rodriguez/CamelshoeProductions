using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceScript : MonoBehaviour
{

    AudioSource Source;
    float LastVol;
    // Use this for initialization
    void Start()
    {
        Source = GetComponent<AudioSource>();
        if (name == "SFXSource")
            LastVol = PlayerPrefs.GetFloat("SFX Volume");
        else
            LastVol = PlayerPrefs.GetFloat("Music Volume");
        Source.volume = LastVol;
    }

    // Update is called once per frame
    void Update()
    {
        float NewVol;
        if (name == "SFXSource")
            NewVol = PlayerPrefs.GetFloat("SFX Volume");
        else
            NewVol = PlayerPrefs.GetFloat("Music Volume");

        if (LastVol != NewVol)
        {
            LastVol = NewVol;
            Source.volume = LastVol;
        }
    }
}
