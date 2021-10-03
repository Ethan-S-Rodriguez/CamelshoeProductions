using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour
{
    public string NextLevel;
    public SavingSystem SaveGame;
    public PlayerController player;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            SaveGame.Save(player.Health.ToString(), player.Lives.ToString(), NextLevel);
            SceneManager.LoadScene(NextLevel);
        }
    }
}
