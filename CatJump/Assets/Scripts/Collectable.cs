using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public bool isCollected;
    public float giveHealth;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && !isCollected && !PlayerController.instance.isDead && !PlayerController.instance.isSuperJump && !PlayerController.instance.shieldActive)
        {
            isCollected = true;
            Destroy(transform.gameObject);
            HealthController.instance.health += giveHealth;
            if (transform.tag == "Milk")
            {
                PlayerController.instance.MilkShield();
            }
        }
    }

}
