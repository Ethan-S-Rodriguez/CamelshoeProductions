using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestVolume : MonoBehaviour {

    Slider Volume;
    float LastVol;
	// Use this for initialization
	void Start ()
    {
        Volume = GetComponent<Slider>();
        if (name == "SFX Slider")
            Volume.value = PlayerPrefs.GetFloat("SFX Volume");
        else
            Volume.value = PlayerPrefs.GetFloat("Music Volume");   
    }

    // Update is called once per frame
    void Update ()
    {
        if (LastVol != Volume.value)
        {
            LastVol = Volume.value;
            if(name == "SFX Slider")
                PlayerPrefs.SetFloat("SFX Volume", Volume.value);
            else 
                PlayerPrefs.SetFloat("Music Volume", Volume.value);
        }
    }
}
