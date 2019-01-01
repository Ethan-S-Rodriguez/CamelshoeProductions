using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCheckPoint : MonoBehaviour {

    public static Vector3 ReachedPoint;
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Player")
        {
            ReachedPoint = transform.position;
        }
    }
}
