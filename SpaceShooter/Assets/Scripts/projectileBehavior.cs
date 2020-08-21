using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileBehavior : MonoBehaviour
{
    private float moveSpeed = 1.0f;
    private float timeToLive = 3.0f;

    private ProjectileShoot HitLayers;
    
    // Update is called once per frame
    void Update()
    {
        timeToLive -= Time.deltaTime;
        if (timeToLive < 0f)
        {
            Destroy(gameObject);
        }
        transform.position += transform.right * moveSpeed;
    }
}
