using UnityEngine;

[RequireComponent(typeof(Movement), typeof(HitscanShoot), typeof(UnitHealth))]
public class PlayerInput : MonoBehaviour
{
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
        //Debug.Log("oh no!");
        GameController.GameControllerInstance.PlayerDied();
    }
}
