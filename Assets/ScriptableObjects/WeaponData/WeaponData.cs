using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "NewWeapon")]
public class WeaponData : ScriptableObject 
{
    [SerializeField] AudioClip weaponSound;
    public AudioClip WeaponSound { get { return weaponSound; } }
    [SerializeField] AudioClip reloadSound;
    public AudioClip ReloadSound { get { return reloadSound; } }
    [SerializeField] MeshRenderer weaponMesh;
    public MeshRenderer WeaponMesh { get { return WeaponMesh; } }
    [SerializeField] GameObject projectile;
    public GameObject Projectile { get { return projectile; } }
    [SerializeField] int maxAmmo;
    public int MaxAmmo { get { return maxAmmo; } }
    [SerializeField] float weaponDmg;
    public float WeaponDmg { get { return weaponDmg; } }
    [SerializeField] float weaponDelay;
    public float WeaponDelay { get { return weaponDelay; } }
    [SerializeField] float  weaponReloadTime;
    public float WeaponReloadTime { get { return weaponReloadTime; } }
    
}
