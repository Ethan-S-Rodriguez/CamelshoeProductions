using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TestOptions : MonoBehaviour {
    public Slider MusicVolume;
    public Slider SFXVolume;
    public Button Back;
    public Button StartScene;
    public Text Menu;
    public AudioClip Sound;
    public AudioSource Source;
    Button Options;

    private void Start()
    {
        Options = GetComponent<Button>();
        MusicVolume.gameObject.SetActive(true);
        SFXVolume.gameObject.SetActive(true);
        Back.gameObject.SetActive(false);
    }
    private void Update()
    {
        MusicVolume.gameObject.SetActive(false);
        SFXVolume.gameObject.SetActive(false);
    }

    public void OpenOptions()
    {
        Source.PlayOneShot(Sound, PlayerPrefs.GetFloat("SFX Volume"));

        StartScene.gameObject.SetActive(false);
        Menu.gameObject.SetActive(false);
        Back.gameObject.SetActive(true);
        MusicVolume.gameObject.SetActive(true);
        SFXVolume.gameObject.SetActive(true);
        Options.gameObject.SetActive(false);
    }
}
