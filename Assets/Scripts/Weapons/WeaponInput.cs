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
    private void Start()
    {
        weaponToFire = Inventory.Instance.CurrentlyEquippedWeapon;
        currentWeaponAmmo = weaponToFire.MaxAmmo;
    }
    void Update()
    {
        float xOffset = Random.Range(-0.2f, 0.2f);
        float yOffset = Random.Range(-0.2f, 0.2f);
        Debug.DrawRay(weaponTransform.position, weaponTransform.forward + new Vector3(xOffset, yOffset, 0),Color.black);
        FireCurrentWeapon();
        ReloadCurrentWeapon();
    }
    void FireCurrentWeapon()
    {
        if (PlayerInput.Shoot() && canShoot && currentWeaponAmmo > 0)
        {
            StartCoroutine(weaponToFire.MuzzleFlash(weaponTransform));
            StartCoroutine(WeaponDelay());
            AudioSource.PlayClipAtPoint(weaponToFire.WeaponSound, weaponTransform.position,3f);
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
        AudioSource.PlayClipAtPoint(weaponToFire.ReloadSound, weaponTransform.position, 3f);
        canShoot = false;
        yield return new WaitForSeconds(weaponToFire.WeaponReloadTime);
        currentWeaponAmmo = weaponToFire.MaxAmmo;
        canShoot = true;
    }
}
