using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7.0f;
    [SerializeField] private float timeToLive = 20.0f;

    private float damage = 0;

    public void Initialize(float projectileDamage)
    {
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        UnitHealth otherHealth = other.GetComponent<UnitHealth>();
        otherHealth.TakeDamage(damage);
        Destroy(gameObject);
    }
}
