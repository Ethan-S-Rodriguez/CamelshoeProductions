using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public Text Menu;

    public Button Play;
    public Button NewGame;
    public Button Continue;
    public Button PlayBack;

    public Button Options;
    public Button OptionsBack;
    public Slider MusicVolume;
    public Slider SFXVolume;

    public AudioClip Sound;
    public AudioClip BackSound;
    public AudioSource Source;

    public void PlayGame()
    {
        Source.PlayOneShot(Sound, PlayerPrefs.GetFloat("SFX Volume"));

        Play.gameObject.SetActive(false);
        PlayBack.gameObject.SetActive(true);
        Options.gameObject.SetActive(false);
        NewGame.gameObject.SetActive(true);
        Continue.gameObject.SetActive(true);
    }
    public void BackPlay()
    {
        Source.PlayOneShot(BackSound, PlayerPrefs.GetFloat("SFX Volume"));

        Play.gameObject.SetActive(true);
        PlayBack.gameObject.SetActive(false);
        Options.gameObject.SetActive(true);
        NewGame.gameObject.SetActive(false);
        Continue.gameObject.SetActive(false);
    }
    public void OpenOptions()
    {
        Source.PlayOneShot(Sound, PlayerPrefs.GetFloat("SFX Volume"));

        Play.gameObject.SetActive(false);
        Menu.text = "Options";
        OptionsBack.gameObject.SetActive(true);
        MusicVolume.gameObject.SetActive(true);
        SFXVolume.gameObject.SetActive(true);
        Options.gameObject.SetActive(false);
    }
    public void BackOptions()
    {
        Source.PlayOneShot(BackSound, PlayerPrefs.GetFloat("SFX Volume"));
        Options.gameObject.SetActive(true);
        Play.gameObject.SetActive(true);
        Menu.text = "SWORDSMAN JAQUES";
        SFXVolume.gameObject.SetActive(false);
        MusicVolume.gameObject.SetActive(false);
        OptionsBack.gameObject.SetActive(false);
    }

}
