using UnityEngine;

[RequireComponent(typeof(Movement), typeof(UnitHealth))]
public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private float stoppingDistance = 2.0f;
    [SerializeField] private float maxShootingDistance = 4.5f;

    private Movement movement;
    private UnitHealth health;
    private Transform playerTransform;
    private Vector3 playerPosition;
    private Vector3 vectorToPlayer;
    private ProjectileShoot projectileShoot;
    
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

        if (vectorToPlayer.sqrMagnitude <= maxShootingDistance * maxShootingDistance)
        {
            projectileShoot.fire();
        }
    }

    private void OnUnitDied()
    {
        GameController.GameControllerInstance.EnemyDied();
        EnemySpawner.enemySpawnerInstance.EnemyDied();
        Destroy(gameObject);
    }
}
