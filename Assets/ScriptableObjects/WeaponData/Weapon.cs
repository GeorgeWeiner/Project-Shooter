using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : ScriptableObject 
{
    [SerializeField] AudioClip weaponSound;
    public AudioClip WeaponSound { get { return weaponSound; } }
    [SerializeField] AudioClip reloadSound;
    public AudioClip ReloadSound { get { return reloadSound; } }
    [SerializeField] MeshFilter weaponMesh;
    public MeshFilter WeaponMesh { get { return weaponMesh; } }
    [SerializeField] protected GameObject projectile;
    public GameObject Projectile { get { return projectile; } }
    [SerializeField] int maxAmmo;
    public int MaxAmmo { get { return maxAmmo; } }
    [SerializeField] float weaponDmg;
    public float WeaponDmg { get { return weaponDmg; } }
    [SerializeField] float weaponDelay;
    public float WeaponDelay { get { return weaponDelay; } }
    [SerializeField] float  weaponReloadTime;
    public float WeaponReloadTime { get { return weaponReloadTime; } }

    public abstract void FireWeapon();
    
}
