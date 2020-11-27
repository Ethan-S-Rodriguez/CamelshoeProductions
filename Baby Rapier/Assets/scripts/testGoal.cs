using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class testGoal : MonoBehaviour
{
    public string NextLevel;
    public TestSaving SaveGame;
    public Player player;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            SaveGame.Save(player.Health.ToString(), player.Lives.ToString(), NextLevel, "1");
            SceneManager.LoadScene(NextLevel);
        }
    }
}
