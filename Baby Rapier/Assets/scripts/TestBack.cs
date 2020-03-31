using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestBack : MonoBehaviour
{
    public Slider Volume;
    Button Back;
    public Button StartScene;
    public Text Menu;
    public Button Options;
    private void Start()
    {
        Back = GetComponent<Button>();
    }
    public void OpenOptions()
    {
        Options.gameObject.SetActive(true);
        StartScene.gameObject.SetActive(true);
        Menu.gameObject.SetActive(true);
        Back.gameObject.SetActive(false);
        Volume.gameObject.SetActive(false);

    }
}
