using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCreator : MonoBehaviour
{
    public GameObject player;
    public GameObject[] platform;
    public int platformCount = 0;
    public int index;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(CameraController.instance.transform.position.x, CameraController.instance.transform.position.y-8.87f, 0);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "MainPoint" )
        {
                int rnd = Random.Range(0, 100);
            if (rnd < 70)
            {
                index = 0; //normal platform
            }
            else if (rnd < 95)
            {
                int rand = Random.Range(0, 100);
                if (rand < 35) index = 1;
                else index = 2;
            }
            else if (rnd < 100)
            {
                index = 3; //trambolin
            }

                Instantiate(platform[index], new Vector2(Random.Range(-2.2f, 2.2f), /*player.transform.position.y + (5f + Random.Range(0.5f, 1f)))*/other.transform.position.y + (19f + Random.Range(0.2f,0.5f))), Quaternion.identity);    
        }
        Destroy(other.gameObject);

    }
}
 