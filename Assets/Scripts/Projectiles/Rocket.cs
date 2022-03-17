using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : Projectile
{
    [SerializeField] LayerMask targetLayer;
    [SerializeField] AudioClip rocketImpact;
    [SerializeField] float explosionRange;
    [SerializeField] float rocketForceMax;
    float rocketForce;
    float t;
    void Update()
    {
        t += Time.deltaTime;
        GiveProjectileForce();
    }
    protected override void GiveProjectileForce()
    {
        rocketForce = Mathf.Lerp(rocketForce, rocketForceMax, t / 10);
        Debug.Log(rocketForce);
        projectileRb.AddForce(transform.forward * rocketForce, ForceMode.Acceleration);
    }
    protected override void ProjectileImpact(Collider other)
    {
        if(other.GetComponent<IDamageable>() != null || other.CompareTag("Ground") || other.CompareTag("Walls"))
        {
            Collider[] enemies = Physics.OverlapSphere(transform.position, explosionRange, targetLayer);
            foreach (var enemy in enemies)
            {
                if(enemy.GetComponent<IDamageable>() != null)
                {
                    enemy.GetComponent<IDamageable>().TakeDmg(projectileDmg);
                }
            }
            AudioSource.PlayClipAtPoint(rocketImpact, transform.position);
            Destroy(gameObject);
        }
        
    }

}
