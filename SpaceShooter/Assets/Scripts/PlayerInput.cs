using UnityEngine;
[RequireComponent(typeof(Movement),typeof(Shoot))]

public class PlayerInput : MonoBehaviour
{
    private Movement movement;
    private Shoot shot;
    private Camera cam;
    
    private void Awake()
    {
        movement = GetComponent<Movement>();
        shot = GetComponent<Shoot>();
        cam = Camera.main;
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
}
