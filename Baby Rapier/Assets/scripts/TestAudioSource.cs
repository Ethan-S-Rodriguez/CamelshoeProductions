using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAudioSource : MonoBehaviour
{

    AudioSource Source;
    float LastVol;
    // Use this for initialization
    void Start()
    {
        Source = GetComponent<AudioSource>();
        if (name == "SFX Source")
            LastVol = PlayerPrefs.GetFloat("SFX Volume");
        else
            LastVol = PlayerPrefs.GetFloat("Music Volume");
        Source.volume = LastVol;
    }

    // Update is called once per frame
    void Update()
    {
        float NewVol;
        if (name == "SFX Source")
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
