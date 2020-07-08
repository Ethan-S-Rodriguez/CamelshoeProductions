using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyScript : MonoBehaviour {

    public int LeftWaypoint, RightWaypoint;
    public int Speed;

    bool FacingLeft;
    bool hasDied;

    public AudioClip DeathSound;
    public AudioSource Source;

    Rigidbody2D RB;
    Rigidbody2D Player;
    Animator Anim;


	// Use this for initialization
	void Awake ()
    {
        RB = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        FacingLeft = false;
        hasDied = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Pause)
        {
            if (!hasDied)
                MoveEnemy();
        }
    }

    public void MoveEnemy()
    {
        if (Vector3.Distance(RB.position, Player.position) <= 3)
        {
            //chase player
            if (RB.position.x > Player.position.x)
                {
                    RB.transform.Translate(Speed * Time.deltaTime, 0, 0);//left
                    FacingLeft = true;
                }

            else if (RB.position.x < Player.position.x)
                {
                    RB.transform.Translate(Speed * Time.deltaTime, 0, 0);//right
                    FacingLeft = false;
                }
        }

        else
        {
            if (RB.position.x > LeftWaypoint && FacingLeft)
            {
                RB.transform.Translate(Speed * Time.deltaTime, 0, 0);
            }

            else if (RB.position.x < RightWaypoint && !FacingLeft)
            {
                RB.transform.Translate(Speed * Time.deltaTime, 0, 0);

            }

            else
            {
                FacingLeft = !FacingLeft;

                
            }
        }
        if (FacingLeft)
        {
            GetComponent<Transform>().rotation = new Quaternion(0, 180, 0, 0);
        }
        else
        {
            GetComponent<Transform>().rotation = new Quaternion(0, 0, 0, 0);
        }
    }


    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Sword")
        {
            //Die
            Source.PlayOneShot(DeathSound);
            Anim.SetTrigger("Die");
            GetComponent<BoxCollider2D>().enabled = false;
            RB.simulated = false;
            hasDied = true;
        }
    }
    public void Death()
    {
        Destroy(gameObject);

    }
}
