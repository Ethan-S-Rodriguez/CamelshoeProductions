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
        LastVol = Volume.value;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (LastVol != Volume.value)
        {
            AudioListener.volume = Volume.value;
            LastVol = Volume.value;
        }
	}
}
