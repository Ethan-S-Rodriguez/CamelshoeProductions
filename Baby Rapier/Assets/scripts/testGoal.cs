using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class testGoal : MonoBehaviour
{
    public string NextLevel;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            SceneManager.LoadScene(NextLevel);
        }
    }
}
