using UnityEngine;

[RequireComponent(typeof(Movement), typeof(UnitHealth))]
public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private int experienceValue = 1;

    private Movement movement;
    private UnitHealth health;
    private Transform playerTransform;

    private void Awake()
    {
        movement = GetComponent<Movement>();
        health = GetComponent<UnitHealth>();
    }

    void Start()
    {
        playerTransform = GameController.GameControllerInstance.playerTransform;
        health.OnUnitDied += OnUnitDied;
    }

    void Update()
    {
        movement.movementInput = playerTransform.position - transform.position;

        /*
        if (Input.GetKeyDown(KeyCode.J))
        {
            health.TakeDamage(21.0f);
        }
        */
    }

    private void OnUnitDied()
    {
        UpgradeSystem.upgradeSystemInstance.GainExperience(experienceValue);
        GameController.GameControllerInstance.EnemyKilled();
        Destroy(gameObject);
    }
}
