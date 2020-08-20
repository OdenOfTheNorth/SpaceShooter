using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    public float moveSpeed = 1f;
    public Vector2 movementInput;
    public Vector2 dir;
    
    private Rigidbody2D body;

    
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        body.gravityScale = 0.0f;
    }
    
    private void FixedUpdate()
    {
        transform.LookAt(dir);
        transform.rotation = UtilityFunctions.FlatLookAt(dir,transform.position);
        //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //_body.rotation = angle;
        
        if (movementInput.sqrMagnitude > 0.01f)
        {
            movementInput.Normalize();
            body.MovePosition(body.position + moveSpeed * Time.fixedDeltaTime * movementInput);
        }
    }
}
