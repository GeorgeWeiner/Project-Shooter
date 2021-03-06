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
            weaponToFire.PlayWeaponEffects(weaponTransform);
            currentWeaponAmmo -= 1;
        }
    }
    void ReloadCurrentWeapon()
    {
        if (PlayerInput.Reload() && !isReloading)
        {
            StartCoroutine(ReloadWeaponProcess()); 
        }
    }
    IEnumerator WeaponDelay()
    {
        canShoot = false;
        yield return new WaitForSeconds( weaponToFire.WeaponDelay);
        canShoot = true;
    }
    IEnumerator ReloadWeaponProcess()
    {

        isReloading = true;
        yield return new WaitForSeconds(weaponToFire.WeaponReloadTime);
        ReloadWeapon();
        isReloading = false;
    }
    void ReloadWeapon()
    {
        Inventory inventory = Inventory.Instance;
        for (int i = 0; i < inventory.WeaponCarriedAmmo.Count; i++)
        {
            if (inventory.WeaponCarriedAmmo.ContainsKey(inventory.CurrentlyEquippedWeapon.AmmoTypeOfThisWeapon))
            {
                if (inventory.WeaponCarriedAmmo[inventory.CurrentlyEquippedWeapon.AmmoTypeOfThisWeapon] > inventory.CurrentlyEquippedWeapon.MaxAmmo)
                {
                    int ammoToAdd = inventory.CurrentlyEquippedWeapon.MaxAmmo - currentWeaponAmmo;
                    if(ammoToAdd <= inventory.WeaponCarriedAmmo[inventory.CurrentlyEquippedWeapon.AmmoTypeOfThisWeapon])
                    {
                        inventory.WeaponCarriedAmmo[inventory.CurrentlyEquippedWeapon.AmmoTypeOfThisWeapon] -= ammoToAdd;
                        currentWeaponAmmo += ammoToAdd;
                        Debug.Log(inventory.WeaponCarriedAmmo[inventory.CurrentlyEquippedWeapon.AmmoTypeOfThisWeapon]);
                    }
                    
                }
                else if(inventory.WeaponCarriedAmmo[inventory.CurrentlyEquippedWeapon.AmmoTypeOfThisWeapon] > 0)
                {
                    int ammoToAdd = inventory.CurrentlyEquippedWeapon.MaxAmmo - currentWeaponAmmo;
                    if (ammoToAdd <= inventory.WeaponCarriedAmmo[inventory.CurrentlyEquippedWeapon.AmmoTypeOfThisWeapon])
                    {
                        currentWeaponAmmo += ammoToAdd;
                        inventory.WeaponCarriedAmmo[inventory.CurrentlyEquippedWeapon.AmmoTypeOfThisWeapon] -= ammoToAdd;
                        Debug.Log(inventory.WeaponCarriedAmmo[inventory.CurrentlyEquippedWeapon.AmmoTypeOfThisWeapon]);
                    }   
                }     
            }   
        }
    }
}
