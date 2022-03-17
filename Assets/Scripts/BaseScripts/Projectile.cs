using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] float projectileForce;
    protected Rigidbody projectileRb;
    protected float projectileDmg;
    public float ProjectileDmg { get { return projectileDmg; } set { projectileDmg = value; } }
    private void Awake()
    {
        projectileRb = GetComponent<Rigidbody>();
    }
    protected abstract void GiveProjectileForce();
   
    protected virtual void OnTriggerEnter(Collider other)
    {
        ProjectileImpact(other);
    }
    protected abstract void ProjectileImpact(Collider other);
   
}
