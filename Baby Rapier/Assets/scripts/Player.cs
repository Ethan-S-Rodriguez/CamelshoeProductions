﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour {
    //Int values
    public int Speed; //3 seems a decent speed must be tested more
    public int Jump; //Using add force 250 seems to be consistent
    public int Health, Lives;
    int playerhealth;

    //Float values
    float AttackTimer= 0;
    float AttackCool = 0.3f;

    //Booleans
    public bool CanJump;
    bool attacking = false;
    bool MLeft = false;
    bool MRight = false;

    //Unity Componets
    Animator Anim;
    public Collider2D sword;
    public Text HealthText;
    public Text LivesText;

    //events
    public delegate void TestDelegate();
    public event TestDelegate Respawn;

    // Use this for initialization
    void Awake () {
        Anim = GetComponent<Animator>();
        sword.enabled = false;
        playerhealth = Health;
        HealthText.text = "Health: " + Health;
        LivesText.text = "Lives: " + Lives;
    }

    // Update is called once per frame
    void Update ()
    {
        CheckPlayerInputs();
        if (Health <= 0)
            Death();
        
	}

    //Movement tests 
    void CheckPlayerInputs()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || MLeft == true)
        {
            MoveLeft();
        }
        else if (Input.GetKey(KeyCode.RightArrow) || MRight == true)
        {
            MoveRight();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            PlayerJump();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            AttackHandler();
        }
        if(attacking)
        {
            AttackHandler();
        }
    }

    public void PlayerJump ()
    {
        if (CanJump)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, Jump));
            CanJump = false;
        }
    }

    public void MoveLeft()
    {
        GetComponent<Transform>().rotation = new Quaternion(0, 180, 0, 0);
        transform.Translate((Speed * Time.deltaTime), 0, 0);
    }
    public void SetMLeft(bool swap)
    {
        MLeft = swap;
    }
    public void SetMRight(bool swap)
    {
        MRight= swap;
    }
    public void MoveRight()
    {
        GetComponent<Transform>().rotation = new Quaternion(0, 0, 0, 0);
        transform.Translate((Speed * Time.deltaTime), 0, 0);
    }

    public void AttackHandler()
    {
        if (!attacking)
        {
            Anim.SetTrigger("attack");
            attacking = true;
            AttackTimer = AttackCool;
            sword.enabled = true;
        }
        else if(attacking)
        {
            if(AttackTimer > 0)
            {
                AttackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                sword.enabled = false;
            }
        }
        
    }

    //Jump only once test{must edit for double jump)
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.transform.tag == "Floor")
            CanJump = true;

        if (coll.transform.tag == "Enemy")
        {
            Health--;
            HealthText.text = "Health: " + Health;

        }
        if (coll.transform.tag == "Wall")
            CanJump = true;
    }

    private void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.transform.tag == "Wall")
            CanJump = true;
    }
    public void Death()
    {
        Lives--;
        LivesText.text = "Lives: " + Lives;
        Health = playerhealth;
        // do death animation then invoke the respawn/restart function after a few seconds (like 2 - 5 with countdown)
        //Respawn.Invoke();
        transform.position = TestCheckPoint.ReachedPoint;
    }
}
