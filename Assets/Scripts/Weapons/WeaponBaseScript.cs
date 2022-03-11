using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBaseScript : MonoBehaviour
{
    [SerializeField] protected WeaponData currentlyEquippedWeaponData;
    public WeaponData CurrentlyEquippedWeaponData { get { return currentlyEquippedWeaponData; } set { currentlyEquippedWeaponData = value;} }
    [SerializeField] MeshRenderer weaponMesh;
    [SerializeField] protected Transform weaponTransform;
    [SerializeField] protected float currentAmmo;
    protected bool canShoot = true;
    protected bool isReloading;
    private void Awake()
    {
        currentAmmo = CurrentlyEquippedWeaponData.MaxAmmo;
        EventManager.Instance.reloadWeapon += ReloadCurrentWeapon;
    }
    private void OnDestroy()
    {
        EventManager.Instance.reloadWeapon -= ReloadCurrentWeapon;
    }
    private void ReloadCurrentWeapon()
    {
        StartCoroutine(ReloadWeapon()); 
    }
    protected virtual void ShootCurrentWeapon()
    {
        Debug.Log("HIII");
        StartCoroutine(DelayBetweenShots());
    }
    IEnumerator DelayBetweenShots()
    {
        canShoot = false;
        yield return new WaitForSeconds(currentlyEquippedWeaponData.WeaponDelay);
        canShoot = true;
    }
    IEnumerator ReloadWeapon()
    {
        //PlaySound Animation usw
        isReloading = true;
        canShoot = false;
        yield return new WaitForSeconds(currentlyEquippedWeaponData.WeaponReloadTime);
        currentAmmo = currentlyEquippedWeaponData.MaxAmmo;
        canShoot = true;
        isReloading = false;
    }

}
