using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inputs;
public class WeaponInput : MonoBehaviour
{
    [SerializeField] Weapon weaponToFire;
    public Weapon WeaponToFire { get { return weaponToFire; } set { weaponToFire = value; } }
    [SerializeField] Transform weaponTransform;
    [SerializeField] MeshFilter weaponMesh;
    [SerializeField] int currentWeaponAmmo;
    public int CurrentWeaponAmmo { get { return currentWeaponAmmo; } set { currentWeaponAmmo = value; } }
    bool canShoot = true;
    private void Awake()
    {
        weaponToFire = Inventory.Instance.CurrentlyEquippedWeapon;
        currentWeaponAmmo = weaponToFire.MaxAmmo;
    }
    void Update()
    {
        FireCurrentWeapon();
        ReloadCurrentWeapon();
    }
    void FireCurrentWeapon()
    {
        if (PlayerInput.Shoot() && canShoot && currentWeaponAmmo > 0)
        {
            StartCoroutine(WeaponDelay());
            weaponToFire.FireWeapon(weaponTransform);
            currentWeaponAmmo -= 1;
        }
    }
    void ReloadCurrentWeapon()
    {
        if (PlayerInput.Reload() && canShoot )
        {
            StartCoroutine(ReloadWeapon()); 
        }
    }
    public void ChangeMesh(MeshFilter weaponMeshToChangeTo)
    {
        Debug.Log("HEHEHEHEHH");
        var tempMesh = weaponMeshToChangeTo.sharedMesh;
        Debug.Log(tempMesh);
        weaponMesh.mesh = tempMesh;
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
