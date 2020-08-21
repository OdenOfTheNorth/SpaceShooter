using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    private float moveSpeed = 4.0f;
    private float timeToLive = 3.0f;
    private LayerMask hitLayers = ~0;
    private float damage = 0;

    public void Initialize(LayerMask layersToHit, float projectileDamage)
    {
        hitLayers = layersToHit;
        damage = projectileDamage;
    }
    
    void Update()
    {
        timeToLive -= Time.deltaTime;
        if (timeToLive < 0f)
        {
            Destroy(gameObject);
        }

        transform.position += Time.deltaTime * moveSpeed * transform.right;
    }
}
