using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

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
    public TestSaving SaveGame;
    public Player player;

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
        player.Health = Convert.ToInt32(SaveGame.Health);
        player.Lives = Convert.ToInt32(SaveGame.Lives);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }
        if (player.Lives <= 0)
            TestMMNoSave();
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

    public void TestMainMenu()
    {
        Source.PlayOneShot(SoundP);
        SaveGame.Save(player.Health.ToString(), player.Lives.ToString(),SceneManager.GetActiveScene().name,"1");
        SceneManager.LoadScene("Main Menu");
    }
    public void TestMMNoSave()
    {
        Source.PlayOneShot(SoundP);
        SceneManager.LoadScene("Main Menu");
    }
}
