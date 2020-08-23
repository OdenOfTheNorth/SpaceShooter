using System.Collections;
using UnityEngine;

public class HitscanShoot : MonoBehaviour
{
    public Transform origin;
    public LayerMask HitLayers;
    public float damage = 50f;

    private float cooldown = 1.0f; 
    private float currentCoolDown = 0.0f;
    private LineRenderer laser = null;

    private void Awake()
    {
        laser = origin.GetComponent<LineRenderer>();
        laser.enabled = false;
    }

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
            laser.enabled = true;
            laser.SetPosition(0, origin.position);
            
            StartCoroutine(DeactivateLaser());
            
            RaycastHit2D rayHit = Physics2D.Raycast(origin.position,origin.right,Mathf.Infinity,HitLayers);

            if (rayHit)
            {
                UnitHealth hitUnit = rayHit.transform.GetComponent<UnitHealth>();
                if (hitUnit)
                {
                    hitUnit.TakeDamage(damage);
                }

                laser.SetPosition(1, rayHit.point);
            }
            else
            {
                laser.SetPosition(1, origin.position + (origin.right * 20.0f));
            }

        }
    }

    private IEnumerator DeactivateLaser()
    {
        yield return new WaitForSeconds(0.1f);
        laser.enabled = false;
    }
}
