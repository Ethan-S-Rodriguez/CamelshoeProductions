using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicVolume : MonoBehaviour {

    public Slider Volume;
    AudioSource Source;
    float LastVol;
    // Use this for initialization
    void Start()
    {
        Volume = GetComponent<Slider>();
        Source = GetComponent<AudioSource>();
        Volume.value = PlayerPrefs.GetFloat("Music Volume");
        LastVol = Volume.value;
        Source.volume = Volume.value;
    }

    // Update is called once per frame
    void Update()
    {
        Volume = GetComponent<Slider>();
        if (Volume != null)
        {
            if (Volume.IsActive())
                if (LastVol != Volume.value)
                {
                    Source.volume = Volume.value;
                    LastVol = Volume.value;
                    PlayerPrefs.SetFloat("Music Volume", Volume.value);
                }
        }
    }
}
