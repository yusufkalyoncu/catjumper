using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Objects")]
    public Rigidbody2D rb;
    public Animator anim;
    public static PlayerController instance;
    [Header("Movement")]
    public float movementSpeed;
    public float movement;
    public int Score = 0;
    public int yon = 1;
    public bool isSuperJump;
    public int tolerance;
    [Header("Die")]
    public bool isDead;
    public float dieTime,flySpeed;
    private float dieCounter;
    public SpriteRenderer sr;
    private float alpha = 1;
    private float horizontal = 0;
    [Header("Bubble")]
    public float milkShieldTimer;
    private float shieldCounter;
    public Animator bubbleAnim;
    public bool shieldActive;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        tolerance = 2;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dieCounter <= 0 && !isDead)
        {
            if ((int)transform.position.y > Score) Score = (int)transform.position.y;

            /*if (Input.GetAxisRaw("Horizontal") == 1) { Right(); }
            else if (Input.GetAxisRaw("Horizontal") == -1) Left();
            else Up();*/

            movement = horizontal * movementSpeed;
            float health = HealthController.instance.health;
            transform.localScale = new Vector3((health / 100) * yon, health / 100, health / 100);
            if (rb.velocity.y < 0) anim.SetBool("isJump", false);
            else anim.SetBool("isJump", true);

            if (rb.velocity.y < 0) isSuperJump = false;
        }
        else if (dieCounter <= 0 && isDead)
        {
            transform.gameObject.SetActive(false);
            GameOverMenu.instance.WhiteToBlackFunc();

        }
        else
        {
            dieCounter -= Time.deltaTime;
            rb.velocity = new Vector2(rb.velocity.x, flySpeed);
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, alpha);
            alpha -= 0.01f;
        }

        //Bubble
        if (shieldCounter > 0)
        {
            shieldCounter -= Time.deltaTime;
            if (shieldCounter <= 0)
            {
                shieldActive = false;
                bubbleAnim.SetTrigger("bubbleBoom");

            }
        }

    }
    private void FixedUpdate()
    {
        if(!isDead)
        rb.velocity = new Vector2(movement, rb.velocity.y);
    }
    public void PlayerDie()
    {
        AudioManager.instance.DieSound();
        isDead = true;
        dieCounter = dieTime;
        rb.velocity = new Vector2(0, 0);
    }
    public void Right()
    {
        yon = 1;
        horizontal = 1;
    }
    public void Left()
    {
        yon = -1;
        horizontal = -1;
    }
    public void Up()
    {
        horizontal = 0;
    }

    public void MilkShield()
    {
        if (HealthController.instance.health <= 200)
        {
            shieldCounter = milkShieldTimer;
            bubbleAnim.SetTrigger("bubbleReady");
            shieldActive = true;
        }
        else
        {
            HealthController.instance.GetDamage(100);
        }
    }
}
