using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public abstract class Weapon : ScriptableObject 
{
    [SerializeField] protected LayerMask hitLayer;
    [SerializeField] protected AmmoType ammoTypeOfThisWeapon;
    public AmmoType AmmoTypeOfThisWeapon { get { return ammoTypeOfThisWeapon; } }
    [SerializeField] protected AudioClip weaponSound;
    public AudioClip WeaponSound { get { return weaponSound; } }
    [SerializeField] protected AudioClip reloadSound;
    public AudioClip ReloadSound { get { return reloadSound; } }
    [SerializeField] GameObject weaponPrefab;
    public GameObject WeaponPrefab { get { return weaponPrefab; } }
    [SerializeField] protected GameObject muzzleFlash;
    public GameObject MuzzleFlash{ get { return muzzleFlash; } }
    [SerializeField] int maxAmmo;
    public int MaxAmmo { get { return maxAmmo; } }
    [SerializeField] protected float weaponDmg;
    public float WeaponDmg { get { return weaponDmg; } }
    [SerializeField] float weaponDelay;
    public float WeaponDelay { get { return weaponDelay; } }
    [SerializeField] float  weaponReloadTime;
    public float WeaponReloadTime { get { return weaponReloadTime; } }
    [SerializeField] bool isAutomaticGun;
    public bool IsAutomaticGun { get { return isAutomaticGun; } }

    public abstract void FireWeapon(Transform weaponFirePoint);
    public IEnumerator MuzzleFlashSpawn(Transform muzzleFlashPosition)
    {
        var tempParticles = Instantiate(muzzleFlash, muzzleFlashPosition.forward, muzzleFlashPosition.rotation);
        tempParticles.transform.position = muzzleFlashPosition.position + muzzleFlashPosition.forward ;
        yield return new WaitForSeconds(0.1f);
        Destroy(tempParticles);
    }

    public void PlayWeaponEffects(Transform weapon)
    {
        weapon.GetComponentInChildren<StudioEventEmitter>().Play();
    }
}
