using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    public float moveSpeed = 1f;
    public Vector2 movementInput;
    public Vector2 dir;
    
    private Rigidbody2D _body;

    
    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate()
    {
        transform.LookAt(dir);
        transform.rotation = UtilityFunctions.FlatLookAt(dir,transform.position);
        //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //_body.rotation = angle;
        
        if (movementInput.sqrMagnitude > 0.1f)
        {
            movementInput.Normalize();
            _body.MovePosition(_body.position + moveSpeed * Time.fixedDeltaTime * movementInput);
        }
    }
}
