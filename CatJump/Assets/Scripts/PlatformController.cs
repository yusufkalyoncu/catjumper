using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public float jumpForce = 10f;
    public int foodChance;
    public int milkChance;
    public Transform spawnPoint;
    public GameObject collectable;
    public GameObject milk;
    public GameObject obj;
    public GameObject mainPoint;
    public bool isSuperJump;
    public bool isDeleted;
    public static PlatformController instance;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        mainPoint.transform.parent = null;
        int chance = Random.Range(1, 101);
        if (chance > 100 - foodChance)
        {
            chance = Random.Range(1, 101);
            if(chance > 100 - milkChance) obj = Instantiate(milk, spawnPoint.position, Quaternion.identity);
            else obj = Instantiate(collectable, spawnPoint.position, Quaternion.identity);
            obj.transform.parent = gameObject.transform;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Rigidbody2D rb = other.collider.GetComponent<Rigidbody2D>();
        if (rb != null && other.relativeVelocity.y <= 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            AudioManager.instance.JumpSound();
            if (PlayerController.instance.tolerance == 0 && !PlayerController.instance.shieldActive) HealthController.instance.GetDamage(15);
            else if (PlayerController.instance.tolerance > 0) PlayerController.instance.tolerance--;

            if (jumpForce > 10f) PlayerController.instance.isSuperJump = true;
        }
         
    }

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Platform")
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x + 0.15f, -2.2f, 2.2f), transform.position.y, transform.position.z);
            other.transform.position = new Vector3(Mathf.Clamp(other.transform.position.x - 0.15f, -2.2f, 2.2f), other.transform.position.y, other.transform.position.z);
        }
    }*/
}
