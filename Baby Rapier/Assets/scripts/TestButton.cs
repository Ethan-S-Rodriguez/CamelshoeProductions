using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TestButton : MonoBehaviour {

    public AudioClip Sound;
    public AudioSource Source;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void TestPlay()
    {
        Source.PlayOneShot(Sound);
        SceneManager.LoadScene("Testbuild");
    }
}
