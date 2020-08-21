﻿using UnityEngine;

[RequireComponent(typeof(Movement), typeof(UnitHealth))]
public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private int experienceValue = 1;

    private Movement movement;
    private UnitHealth health;
    private Transform playerTransform;
    private Vector3 playerPosition;
    private Vector3 vectorToPlayer;
    private ProjectileShoot projectileShoot;
    private float stoppingDistance = 3.0f;
    
    private void Awake()
    {
        movement = GetComponent<Movement>();
        health = GetComponent<UnitHealth>();
        projectileShoot = GetComponent<ProjectileShoot>();
    }

    void Start()
    {
        playerTransform = GameController.GameControllerInstance.playerTransform;
        health.OnUnitDied += OnUnitDied;
    }

    void Update()
    {
        projectileShoot.fire();
        playerPosition = playerTransform.position;
        vectorToPlayer = playerPosition - transform.position;
        movement.dir = playerPosition;
        
        if (vectorToPlayer.sqrMagnitude > stoppingDistance * stoppingDistance)
        {
            movement.movementInput = vectorToPlayer;
        }
        else
        {
            movement.movementInput = Vector3.zero;
        }
    }

    private void OnUnitDied()
    {
        UpgradeSystem.upgradeSystemInstance.GainExperience(experienceValue);
        GameController.GameControllerInstance.EnemyDied();
        Destroy(gameObject);
    }
}
