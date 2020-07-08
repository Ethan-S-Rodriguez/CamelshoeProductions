using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCheckPoint : MonoBehaviour {

    public static Vector3 ReachedPoint;
    public AudioClip Sound;
    public AudioSource Source;
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Player")
        {
            Source.PlayOneShot(Sound);
            ReachedPoint = transform.position;
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
