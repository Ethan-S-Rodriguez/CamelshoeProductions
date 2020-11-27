using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestStart : MonoBehaviour {

    public Button Back2;
    public Button Options;
    public Button NewGame;
    public Button Continue;
    public Button StartScene;
    public AudioClip Sound;
    public AudioSource Source;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OpenOptions()
    {

    }
    public void TestBack()
    {
        Source.PlayOneShot(Sound, PlayerPrefs.GetFloat("SFX Volume"));

        StartScene.gameObject.SetActive(true);
        Back2.gameObject.SetActive(false);
        Options.gameObject.SetActive(true);
        NewGame.gameObject.SetActive(false);
        Continue.gameObject.SetActive(false);
    }
    public void TestPlay()
    {
        Source.PlayOneShot(Sound, PlayerPrefs.GetFloat("SFX Volume"));

        StartScene.gameObject.SetActive(false);
        Back2.gameObject.SetActive(true);
        Options.gameObject.SetActive(false);
        NewGame.gameObject.SetActive(true);
        Continue.gameObject.SetActive(true);
    }
}
