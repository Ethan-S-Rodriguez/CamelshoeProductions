using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;


public class SavingSystem : MonoBehaviour
{

    public static SavingSystem i;

    string SaveFile;
    public string Health = "5";
    public string Lives = "10";
    public string Stage = "SampleScene";

    public void Awake()
    {
        string filepath = Application.persistentDataPath + "/SaveFile.txt";
        if (File.Exists(filepath))
        {
            SaveFile = filepath;
            StreamReader LoadGame = new StreamReader(SaveFile);

            string SplitMe = LoadGame.ReadLine();
            string[] SplitLine = SplitMe.Split(':');
            Health = SplitLine[1];

            SplitMe = LoadGame.ReadLine();
            SplitLine = SplitMe.Split(':');
            Lives = SplitLine[1];

            SplitMe = LoadGame.ReadLine();
            SplitLine = SplitMe.Split(':');
            Stage = SplitLine[1];

        }
        else
        {
            File.Create(filepath);
            SaveFile = filepath;

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void NewGame()
    {
        Health = "5";
        Lives = "10";
        Stage = "SampleScene";
        Save(Health, Lives, Stage);
        SceneManager.LoadScene("SampleScene");
    }

    public void Continue()
    {
        StreamReader LoadGame = new StreamReader(SaveFile);

        string SplitMe = LoadGame.ReadLine();
        string[] SplitLine = SplitMe.Split(':');
        Health = SplitLine[1];

        SplitMe = LoadGame.ReadLine();
        SplitLine = SplitMe.Split(':');
        Lives = SplitLine[1];

        SplitMe = LoadGame.ReadLine();
        SplitLine = SplitMe.Split(':');
        Stage = SplitLine[1];

        SceneManager.LoadScene(Stage);

    }


    public void Save(string HP, string LF, string LV)
    {
        StreamWriter SaveGame = new StreamWriter(SaveFile);
        SaveGame.WriteLine("Health:" + HP);
        SaveGame.WriteLine("Lives:" + LF);
        SaveGame.WriteLine("Stage:" + LV);
        SaveGame.Flush();
        SaveGame.Close();
    }
}

