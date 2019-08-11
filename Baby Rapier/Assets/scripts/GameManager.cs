using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static bool Pause;
    public Text screen;
    // Use this for initialization
    void Start()
    {
        Pause = false;
        screen.enabled = false;
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
        Pause = !Pause;
        screen.enabled = Pause;
    }
}
