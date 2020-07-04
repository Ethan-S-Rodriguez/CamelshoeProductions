using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestBack : MonoBehaviour
{
    public Slider MusicVolume;
    public Slider SFXVolume;
    public Button StartScene;
    public Text Menu;
    public Button Options;
    public AudioClip Sound;
    public AudioSource Source;
    Button Back;

    private void Start()
    {
        Back = GetComponent<Button>();
    }

    public void CloseOptions()
    {
        Source.PlayOneShot(Sound,PlayerPrefs.GetFloat("SFX Volume"));
        Options.gameObject.SetActive(true);
        StartScene.gameObject.SetActive(true);
        Menu.gameObject.SetActive(true);
        SFXVolume.gameObject.SetActive(false);
        MusicVolume.gameObject.SetActive(false);
        Back.gameObject.SetActive(false);
    }
}
