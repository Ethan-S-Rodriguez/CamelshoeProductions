using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static bool Pause;
    public Text screen;
    public Button Resume;
    public Button MainMenu;
    public Slider MusicVolume;
    public Slider SFXVolume;
    public GameObject PausePanel;
    public AudioClip SoundP;
    public AudioClip SoundR;
    public AudioSource Source;

    // Use this for initialization
    void Start()
    {
        Pause = false;
        screen.enabled = false;
        Resume.gameObject.SetActive(false);
        MainMenu.gameObject.SetActive(false);
        MusicVolume.gameObject.SetActive(false);
        SFXVolume.gameObject.SetActive(false);
        PausePanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        if (!Pause)
            Source.PlayOneShot(SoundP);
        else
            Source.PlayOneShot(SoundR);
        Pause = !Pause;
        screen.enabled = Pause;
        Resume.gameObject.SetActive(Pause);
        MainMenu.gameObject.SetActive(Pause);
        PausePanel.gameObject.SetActive(Pause);
        MusicVolume.gameObject.SetActive(Pause);
        SFXVolume.gameObject.SetActive(Pause);
    }

    public void TestPlay()
    {
        Source.PlayOneShot(SoundP);
        if (SceneManager.GetActiveScene().name == "Main Menu")
            SceneManager.LoadScene("Testbuild");
        else
            SceneManager.LoadScene("Main Menu");
    }
}
