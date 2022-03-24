using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public static CameraController instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(target.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
        }
    }
}
