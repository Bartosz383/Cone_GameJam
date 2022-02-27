using System.Collections;
using UnityEngine;


public class WeaponController : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    
    [SerializeField]
    private Transform firePoint;

    [SerializeField]
    private float shootCooldown;

    private bool isActive;
    private float currentShootCooldown = 0;
    
        private void FixedUpdate()
    {
        if (currentShootCooldown >= 0)
        {
            currentShootCooldown -= Time.fixedDeltaTime;
        }
    }

    public IEnumerator Shoot()
    {
        if (!isActive) yield break;
        if (currentShootCooldown <= 0)
        {
            currentShootCooldown = shootCooldown;
            Instantiate(bullet, firePoint.position, firePoint.rotation);
        }
    }

    public void Activate()
    {
        isActive = true;
    }

    public bool GetActive() => isActive;
    
}
