using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShoot : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    private float cooldown = 1.0f; 
    private float currentCoolDown = 0.0f;
    
    public Transform origin;
    public LayerMask HitLayers;
    public float damage = 50f;
    
    
    private void Update()
    {
        currentCoolDown -= Time.deltaTime;
    }
    
    public void fire()
    {
        if (currentCoolDown <= 0.0f)
        {
            currentCoolDown = cooldown;
            GameObject projectileInstance = Instantiate(projectile, origin.position, origin.rotation);
        }
        
    }
}
