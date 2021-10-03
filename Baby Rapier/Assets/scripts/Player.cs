using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour {
    //Int values
    public int Speed; //3 seems a decent speed must be tested more
    public int Jump; //Using add force 250 seems to be consistent
    public int KnockbackX; 
    public int KnockbackY;
    public float StunTime;
    float StunTimer;
    float StunCheck;
    public int MaxHealth, Health, Lives;
    Vector3 RespawnPoint;

    //Float values
    float AttackTimer= 0;
    float AttackCool = 0.5f;

    //Booleans
    public bool CanJump;
    bool attacking = false;
    bool MLeft = false;
    bool MRight = false;
    bool Stunned = false;

    //Unity Componets
    Animator Anim;
    public Collider2D sword;
    public Text HealthText;
    public Text LivesText;
    public Slider Joystick;

    public AudioClip HurtSound;
    public AudioClip DeathSound;
    public AudioClip JumpSound;
    public AudioClip AttackSound;
    public AudioSource Source;
    public TestSaving SaveGame;


    //events
    public delegate void TestDelegate();
    public event TestDelegate Respawn;

    // Use this for initialization
    void Awake () {
        Anim = GetComponent<Animator>();
        sword.enabled = false;
        SaveGame.Awake();
        Health = Convert.ToInt32(SaveGame.Health);
        Lives = Convert.ToInt32(SaveGame.Lives);

        HealthText.text = "Health: " + Health;
        LivesText.text = "Lives: " + Lives;
        RespawnPoint = transform.position;
        MRight = true;
        MLeft = false;
    }

    // Update is called once per frame
    void Update ()
    {
        if (!GameManager.Pause)
        {
            
            if(GetComponent<Rigidbody2D>().simulated == false)
            GetComponent<Rigidbody2D>().simulated = true;

            CheckPlayerInputs();
            if (Health <= 0)
                Death();
            if (Stunned)
            {
                StunCheck = Time.time;
                if ((StunCheck - StunTimer) >= StunTime)
                {
                    Stunned = false;
                    GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                }
            }

        }
        else
        {
            GetComponent<Rigidbody2D>().simulated = false;
        }
    }

    //Movement tests 
    void CheckPlayerInputs()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Joystick.value <0)
        {
            MoveLeft();
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Joystick.value > 0)
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
            Source.PlayOneShot(JumpSound);
            GetComponent<Rigidbody2D>().AddForce(new Vector2( 0, 0));
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, Jump));
            Anim.ResetTrigger("Landed");
            CanJump = false;
        }
    }

    public void MoveLeft()
    {
        if (!Stunned)
        {
            if (!attacking)
                GetComponent<Transform>().localScale = new Vector3(-0.5f, 0.5f, 1);
            GetComponent<Transform>().rotation = new Quaternion(0,180,0,0);

            transform.Translate((Speed * Time.deltaTime), 0, 0);
            MLeft = true;
            MRight = false;
        }
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
        if (!Stunned)
        {
            if (!attacking)
                GetComponent<Transform>().localScale = new Vector3(0.5f, 0.5f, 1);
            GetComponent<Transform>().rotation = new Quaternion(0, 0, 0, 0);
            transform.Translate((Speed * Time.deltaTime), 0, 0);
            MRight = true;
            MLeft = false;
        }
    }

    public void AttackHandler()
    {
        if (!attacking)
        {
            if (CanJump)
            {
                Anim.SetTrigger("attack");
            }
            else if (!CanJump && MRight == true)
            {
                Anim.SetTrigger("jattack R");
            }
            else if (!CanJump && MLeft == true)
            {
                Anim.SetTrigger("jattack L");
            }

            Source.PlayOneShot(AttackSound, 0.5f);
            attacking = true;
            AttackTimer = AttackCool;
            sword.enabled = true;
        }
        else if(attacking)
        {
            if(AttackTimer > 0 )
            {
                AttackTimer -= Time.deltaTime;
            }
            else if(CanJump && AttackTimer <=0)
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
        { 
            CanJump = true;
            Anim.SetTrigger("Landed");
        }

        if (coll.transform.tag == "Enemy")
        {
            Source.PlayOneShot(HurtSound);
            Health--;
            HealthText.text = "Health: " + Health;
            int EnemyDir = 1;

            if( transform.position.x < coll.transform.position.x)
                EnemyDir = -1;
            
            GetComponent<Rigidbody2D>().AddForce(new Vector2((EnemyDir * KnockbackX), KnockbackY));
            Stunned = true;
            StunTimer = Time.time;
        }
        if (coll.transform.tag == "Wall")
        {
            CanJump = true;
            Anim.SetTrigger("Landed");
        }
    }

    private void OnCollisionStay2D(Collision2D coll)
    {
        //if (coll.transform.tag == "Floor")
            CanJump = true;

    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (!CanJump && coll.transform.tag == "Enemy")
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, Jump*2));

        }

    }

    public void Death()
    {
        Source.PlayOneShot(DeathSound);
        Lives--;
        LivesText.text = "Lives: " + Lives;
        Health = MaxHealth;
        HealthText.text = "Health: " + MaxHealth;
        // do death animation then invoke the respawn/restart function after a few seconds (like 2 - 5 with countdown)
        //Respawn.Invoke();
        if (TestCheckPoint.ReachedPoint != Vector3.zero)
            transform.position = TestCheckPoint.ReachedPoint;
        else
            transform.position = RespawnPoint;
    }
}
