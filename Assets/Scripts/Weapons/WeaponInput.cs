using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inputs;
public class WeaponInput : MonoBehaviour
{
    [SerializeField] Weapon weaponToFire;
    public Weapon WeaponToFire { get { return weaponToFire; } set { weaponToFire = value; } }
    int currentWeaponAmmo;
    public int CurrentWeaponAmmo { get { return currentWeaponAmmo; } set { currentWeaponAmmo = value; } }
    bool canShoot = true;

    private void Awake()
    {
        currentWeaponAmmo = weaponToFire.MaxAmmo;
        weaponToFire = Inventory.Instance.CurrentlyEquippedWeapon;
    }
    void Update()
    {
        FireCurrentWeapon();
        ReloadCurrentWeapon();
    }
    void FireCurrentWeapon()
    {
        if (PlayerInput.Shoot() && canShoot)
        {
            StartCoroutine(WeaponDelay());
            weaponToFire.FireWeapon();
        }
    }
    void ReloadCurrentWeapon()
    {
        if (Input.GetKeyDown(KeyCode.R) && canShoot)
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
        canShoot = false;
        yield return new WaitForSeconds(weaponToFire.WeaponReloadTime);
        currentWeaponAmmo = weaponToFire.MaxAmmo;
        canShoot = true;
    }
}
