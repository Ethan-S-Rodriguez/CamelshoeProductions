using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerEnemyscript : MonoBehaviour
{
    public int LeftWaypoint, RightWaypoint;
    public int Speed;
    public int Health;
    public int KnockbackX;
    public int KnockbackY;
    public float StunTime;
    float StunTimer;
    float StunCheck;

    bool FacingLeft;
    bool Stunned = false;
    bool hasDied;

    public AudioClip DeathSound;
    public AudioSource Source;

    Rigidbody2D RB;
    Rigidbody2D Player;
    //Animator Anim;


    // Use this for initialization
    void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        //Anim = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        FacingLeft = false;
        hasDied = false;
        Physics2D.IgnoreLayerCollision(3, 3);
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Pause)
        {
            if (!hasDied)
                MoveEnemy();
            else
                Death();

            if (Stunned)
            {
                StunCheck = Time.time;
                if ((StunCheck - StunTimer) >= StunTime)
                {
                    Stunned = false;
                    this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    this.GetComponent<Rigidbody2D>().angularVelocity = 0;
                    this.GetComponent<Rigidbody2D>().Sleep();
                }
            }
        }
    }

    public void MoveEnemy()
    {
        if (!Stunned)
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
    }


    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Sword")
        {
            Health--;

            int PlayerDir = 1;
            if (transform.position.x < coll.transform.position.x)
                PlayerDir = -1;
            GetComponent<Rigidbody2D>().AddForce(new Vector2((PlayerDir * KnockbackX), KnockbackY));
            Stunned = true;
            StunTimer = Time.time;

            if (Health <= 0)
                DeathAni();
        }
    }
    public void DeathAni()
    {
        Source.PlayOneShot(DeathSound);
        //Anim.SetTrigger("Die");
        GetComponent<CapsuleCollider2D>().enabled = false;
        RB.simulated = false;
        hasDied = true;
    }

    public void Death()
    {
        Destroy(gameObject);

    }
}


