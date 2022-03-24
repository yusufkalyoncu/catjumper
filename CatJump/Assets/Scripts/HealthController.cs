using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public float health;
    public GameObject player;
    public int maxHealth = 400;
    public Slider healthSlider;
    public static HealthController instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        healthSlider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetDamage(int amount)
    {
        health -= amount;
        UpdateHealth();
    }
    public void GetHealth(int amount)
    {
        
        health += amount;
        UpdateHealth();
    }
    public void SetHealth(int amount)
    {
        health = amount;
        UpdateHealth();
    }
    public void UpdateHealth()
    {
        //if (health > maxHealth) health = maxHealth;
        if (health <= 0 /*|| health >= maxHealth*/) PlayerController.instance.PlayerDie();
        healthSlider.value = (int)health;
        //PlayerSize(health);
    }
    /*public void PlayerSize(float health)
    {
        //int yon = 0;
        //if (Input.GetAxisRaw("Horizontal") > 0) yon = 1;
        //else if (Input.GetAxisRaw("Horizontal") < 0) yon = -1;

        //if (health <= 100) player.transform.localScale = new Vector3((health / 10f)*yon, health / 10f, health / 10f);
        //else if (health > 100 && health <150) player.transform.localScale = new Vector3((health / 50f)*yon, health / 50f, health / 50f);
        //else if (health >= 150) player.transform.localScale = new Vector3((health / 5f) * yon, health / 5f, health / 5f);

    }*/
}
