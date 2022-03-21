using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inputs;
public class WeaponInput : MonoBehaviour
{
    [SerializeField] Weapon weaponToFire;
    public Weapon WeaponToFire { get { return weaponToFire; } set { weaponToFire = value; } }
    [SerializeField] Transform weaponTransform;
    [SerializeField] int currentWeaponAmmo;
    public int CurrentWeaponAmmo { get { return currentWeaponAmmo; } set { currentWeaponAmmo = value; } }
    bool canShoot = true;
    bool isReloading = false;
    private void Start()
    {
        
        currentWeaponAmmo = weaponToFire.MaxAmmo;
    }
    void Update()
    {
        
        FireCurrentWeapon();
        ReloadCurrentWeapon();
    }
    void FireCurrentWeapon()
    {
        if (PlayerInput.Shoot() && canShoot && currentWeaponAmmo > 0 && !isReloading && weaponToFire != null )
        {
            weaponToFire = Inventory.Instance.CurrentlyEquippedWeapon;
            if(!Inventory.Instance.CurrentlyEquippedWeapon.IsAutomaticGun)
            {
                StartCoroutine(weaponToFire.MuzzleFlashSpawn(weaponTransform));
            }
            StartCoroutine(WeaponDelay());
            weaponToFire.FireWeapon(weaponTransform);
            currentWeaponAmmo -= 1;
        }
    }
    void ReloadCurrentWeapon()
    {
        if (PlayerInput.Reload() && !isReloading)
        {
            StartCoroutine(ReloadWeapon()); 
        }
    }
    IEnumerator WeaponDelay()
    {
        canShoot = false;
        yield return new WaitForSeconds( weaponToFire.WeaponDelay);
        canShoot = true;
    }
    IEnumerator ReloadWeapon()
    {
        AudioSource.PlayClipAtPoint(weaponToFire.ReloadSound, weaponTransform.position, 3f);
        isReloading = true;
        yield return new WaitForSeconds(weaponToFire.WeaponReloadTime);
        currentWeaponAmmo = weaponToFire.MaxAmmo;
        isReloading = false;
    }
}
