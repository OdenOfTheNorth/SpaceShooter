using UnityEngine;

public class Shoot : MonoBehaviour
{
    private float cooldown = 1.0f; 
    private float currentCoolDown = 0.0f;
    public Transform origin;
    public LayerMask HitLayers;
    
    private void Update()
    {
        currentCoolDown -= Time.deltaTime;
    }

    public void fire()
    {
        if (currentCoolDown <= 0.0f)
        {
            currentCoolDown = cooldown;
            //Debug.Log("attack");
            RaycastHit2D rayHit = Physics2D.Raycast(origin.position,origin.right,Mathf.Infinity,HitLayers);

            if (rayHit)
            {
                Debug.Log(rayHit.transform.name);
            }
            
        }
        
    }
}
