using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Movement), typeof(HitscanShoot), typeof(UnitHealth))]
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Slider healthSlider = null;

    private Movement movement;
    private HitscanShoot shot;
    private UnitHealth health;
    private Camera cam;
    
    private void Awake()
    {
        movement = GetComponent<Movement>();
        shot = GetComponent<HitscanShoot>();
        health = GetComponent<UnitHealth>();
        health.OnUnitDied += OnPlayerDied;
        health.OnHealthChanged += OnHealthChanged;
        cam = Camera.main;
        GameController.GameControllerInstance.playerTransform = transform;
    }

    private void Update()
    {
        movement.dir = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));  
        
        movement.movementInput.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (Input.GetButton("Fire1"))
        {
            shot.fire();
        }
    }

    private void OnPlayerDied()
    {
        GameController.GameControllerInstance.PlayerDied();
    }
    
    private void OnHealthChanged(float maxHealth, float currentHealth)
    {
        healthSlider.value = currentHealth / maxHealth;
    }
}
