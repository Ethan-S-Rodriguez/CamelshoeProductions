using UnityEngine;
using UnityEngine.UI;


public class TestOptions : MonoBehaviour {
    public Slider MusicVolume;
    public Slider SFXVolume;
    public Button Options;
    public Button Back;
    public Button StartScene;
    public Text Menu;
    public AudioClip Sound;
    public AudioSource Source;

    private void Start()
    {
        MusicVolume.gameObject.SetActive(true);
        SFXVolume.gameObject.SetActive(true);
        Back.gameObject.SetActive(false);
        MusicVolume.gameObject.SetActive(false);
        SFXVolume.gameObject.SetActive(false);
    }
    private void Update()
    {

    }

    public void OpenOptions()
    {
        Source.PlayOneShot(Sound, PlayerPrefs.GetFloat("SFX Volume"));

        StartScene.gameObject.SetActive(false);
        Menu.text = "Options";
        Back.gameObject.SetActive(true);
        MusicVolume.gameObject.SetActive(true);
        SFXVolume.gameObject.SetActive(true);
        Options.gameObject.SetActive(false);
    }
    public void CloseOptions()
    {
        Source.PlayOneShot(Sound, PlayerPrefs.GetFloat("SFX Volume"));
        Options.gameObject.SetActive(true);
        StartScene.gameObject.SetActive(true);
        Menu.text = "Main Menu";
        SFXVolume.gameObject.SetActive(false);
        MusicVolume.gameObject.SetActive(false);
        Back.gameObject.SetActive(false);
    }

}
