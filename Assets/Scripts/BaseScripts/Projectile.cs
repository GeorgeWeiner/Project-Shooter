using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileForce;
    Rigidbody projectileRb;
    float projectileDmg;
    public float ProjectileDmg { get { return projectileDmg; } set { projectileDmg = value; } }
    private void Awake()
    {
        projectileRb = GetComponent<Rigidbody>();
        InitializeProjectile();
    }
    void InitializeProjectile()
    {
        projectileRb.AddForce(transform.forward * projectileForce, ForceMode.Impulse);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<IDamageable>() != null)
        {
            other.GetComponent<IDamageable>().TakeDmg(projectileDmg);
            Destroy(gameObject);
        }
    }
}
