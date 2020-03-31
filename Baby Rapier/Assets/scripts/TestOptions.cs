using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestOptions : MonoBehaviour {
    public Slider Volume;
    public Button Back;
    public Button StartScene;
    public Text Menu;
    Button Options;
    private void Start()
    {
        Options = GetComponent<Button>();
        Volume.gameObject.SetActive(false);
        Back.gameObject.SetActive(false);
    }
    public void OpenOptions()
    {
        Options.gameObject.SetActive(false);
        StartScene.gameObject.SetActive(false);
        Menu.gameObject.SetActive(false);
        Back.gameObject.SetActive(true);
        Volume.gameObject.SetActive(true);

    }
}
