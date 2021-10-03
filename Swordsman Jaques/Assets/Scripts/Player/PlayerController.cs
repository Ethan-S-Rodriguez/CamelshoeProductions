using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //Player variables
    public int Speed;
    public int Jump;
    public bool CanJump = true;
    public int MaxHealth, Health, Lives;
    Vector3 RespawnPoint;

    //combat variables
    public bool attacking;
    public GameObject Sword;
    float AttackTimer = 0;
    float AttackCool = 0.5f;
    public int KnockbackX;
    public int KnockbackY;
    public float StunTime;
    float StunTimer;
    float StunCheck;
    bool Stunned = false;

    //Sound Effects
    public AudioClip HurtSound;
    public AudioClip DeathSound;
    public AudioClip JumpSound;
    public AudioClip AttackSound;
    public AudioSource Source;

    //Save system
    public SavingSystem saver;

    //UI componets
    public Text HealthText;
    public Text LivesText;

    // Start is called before the first frame update
    void Awake()
    {
        Sword.SetActive(false);
        saver.Awake();
        Health = Convert.ToInt32(saver.Health);
        Lives = Convert.ToInt32(saver.Lives);

        HealthText.text = "Health: " + Health;
        LivesText.text = "Lives: " + Lives;
        RespawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Pause)
        {
            InputHandler();
            if (Health <= 0)
                Death();
        }
    }


    private void InputHandler()
    {
        if (Stunned)
        {
            StunCheck = Time.time;
            if ((StunCheck - StunTimer) >= StunTime)
            {
                Stunned = false;
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftArrow))//|| Joystick.value < 0)
            {
                Move(-0.5f, 180);
            }
            else if (Input.GetKey(KeyCode.RightArrow))//|| Joystick.value > 0)
            {
                Move(0.5f, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            PlayerJump();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            AttackHandler();
        }
        if (attacking)
        {
            AttackHandler();
        }
    }
    public void Move(float dir, int rot)
    {

        GetComponent<Transform>().rotation = new Quaternion(0, rot, 0, 0);
        transform.Translate((Speed * Time.deltaTime), 0, 0);

    }
    public void PlayerJump()
    {
        if (CanJump)
        {
            Source.PlayOneShot(JumpSound);
            //GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0));
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, Jump));
            //Anim.ResetTrigger("Landed");
            CanJump = false;
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.transform.tag == "Floor")
        {
            CanJump = true;
        }
        if (coll.transform.tag == "Enemy")
        {
            Source.PlayOneShot(HurtSound);
            Health--;
            HealthText.text = "Health: " + Health;
            int EnemyDir = 1;

            if (transform.position.x < coll.transform.position.x)
                EnemyDir = -1;

            GetComponent<Rigidbody2D>().AddForce(new Vector2((EnemyDir * KnockbackX), KnockbackY));
            Stunned = true;
            StunTimer = Time.time;
        }
    }
    private void OnCollisionStay2D(Collision2D coll)
    {
        if (CanJump == false)
        {
            if (coll.transform.tag == "Floor")
            {
                CanJump = true;
            }
        }
    }

    public void AttackHandler()
    {
        if (!attacking)
        {
            Source.PlayOneShot(AttackSound, 0.5f);
            Sword.SetActive(true);
            AttackTimer = AttackCool;
            attacking = true;
        }
        else if (attacking)
        {
            if (AttackTimer > 0)
            {
                AttackTimer -= Time.deltaTime;
            }
            else if (AttackTimer <= 0)
            {
                attacking = false;
                Sword.SetActive(false);
            }
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
        if (CheckPointScript.ReachedPoint != Vector3.zero)
            transform.position = CheckPointScript.ReachedPoint;
        else
            transform.position = RespawnPoint;

        Stunned = false;
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        this.GetComponent<Rigidbody2D>().angularVelocity = 0;
        this.GetComponent<Rigidbody2D>().Sleep();
    }
}
