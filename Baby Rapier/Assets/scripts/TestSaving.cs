using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class TestSaving : MonoBehaviour {

    public static TestSaving i;

    string SaveFile;
    public string Health = "5";
    public string Lives = "10";
    public string Stage = "Testbuild";
    public string Checkpoint;

    public void Awake()
    {
        string filepath = "..\\Baby Rapier\\Assets\\scripts\\SaveFile.txt";
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

            SplitMe = LoadGame.ReadLine();
            SplitLine = SplitMe.Split(':');
            Checkpoint = SplitLine[1];
        }
        else
        {
            File.Create(filepath);
            SaveFile = filepath;

        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void NewGame()
    {
        Health = "5";
        Lives = "10";
        Stage = "Testbuild";
        Checkpoint = "1";
        Save(Health, Lives, Stage, Checkpoint);
        SceneManager.LoadScene("Testbuild");
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

        SplitMe = LoadGame.ReadLine();
        SplitLine = SplitMe.Split(':');
        Checkpoint = SplitLine[1];

        SceneManager.LoadScene(Stage);

    }


    public void Save(string HP, string LF, string LV, string CP)
    {
        StreamWriter SaveGame = new StreamWriter(SaveFile);
        SaveGame.WriteLine("Health:"+ HP);
        SaveGame.WriteLine("Lives:" + LF);
        SaveGame.WriteLine("Stage:" + LV);
        SaveGame.WriteLine("Checkpoint:" + CP);
        SaveGame.Flush();
        SaveGame.Close();
    }
}
