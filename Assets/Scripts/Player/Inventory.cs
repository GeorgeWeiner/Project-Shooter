using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : BaseSingleton<Inventory>
{
    [SerializeField] List<Weapon> weaponsAquired;
    public List<Weapon> WeaponsAquired { get { return weaponsAquired; } set { weaponsAquired = value; } }
    Weapon currentlyEquippedWeapon;
    public Weapon CurrentlyEquippedWeapon { get { return currentlyEquippedWeapon; } set { currentlyEquippedWeapon = value; } }
    Dictionary<Weapon, int> weaponsAmmo = new Dictionary<Weapon, int>();
    WeaponInput playerWeapon;
    [SerializeField] int currentWeaponIndex;
    protected override void Awake()
    {
        base.Awake();
        currentlyEquippedWeapon = weaponsAquired[0];
        currentWeaponIndex = 0;
    }
    private void Start()
    {
        playerWeapon = GetComponent<WeaponInput>();
        weaponsAmmo.Add(currentlyEquippedWeapon, playerWeapon.CurrentWeaponAmmo);
    }
    private void Update()
    {
        ChangeCurrentWeapon();
    }
    public void ChangeWeapon()
    {
        if (currentWeaponIndex != weaponsAquired.Count -1  && currentWeaponIndex <= weaponsAquired.Count -1 )
        {
            if (weaponsAmmo.ContainsKey(currentlyEquippedWeapon))
            { 
                weaponsAmmo[currentlyEquippedWeapon] = playerWeapon.CurrentWeaponAmmo;
                currentWeaponIndex++;
                playerWeapon.WeaponToFire = weaponsAquired[currentWeaponIndex];
                CurrentlyEquippedWeapon = weaponsAquired[currentWeaponIndex];
                playerWeapon.ChangeMesh(currentlyEquippedWeapon.WeaponMesh);
                if (weaponsAmmo.ContainsKey(currentlyEquippedWeapon))
                {
                    playerWeapon.CurrentWeaponAmmo = weaponsAmmo[currentlyEquippedWeapon];
                }
                else
                {
                    weaponsAmmo.Add(currentlyEquippedWeapon, currentlyEquippedWeapon.MaxAmmo);
                    playerWeapon.CurrentWeaponAmmo = weaponsAmmo[currentlyEquippedWeapon];
                }  
            }
            else
            {
   
                currentWeaponIndex++;
                currentlyEquippedWeapon = weaponsAquired[currentWeaponIndex];
                playerWeapon.WeaponToFire = weaponsAquired[currentWeaponIndex];
                playerWeapon.ChangeMesh(currentlyEquippedWeapon.WeaponMesh);
                weaponsAmmo.Add(currentlyEquippedWeapon, currentlyEquippedWeapon.MaxAmmo);
                playerWeapon.CurrentWeaponAmmo = weaponsAmmo[currentlyEquippedWeapon];
            }

        }
        else
        {
            currentWeaponIndex = 0;
            if (weaponsAmmo.ContainsKey(currentlyEquippedWeapon))
            {
                weaponsAmmo[currentlyEquippedWeapon] = playerWeapon.CurrentWeaponAmmo;
                playerWeapon.WeaponToFire = weaponsAquired[currentWeaponIndex];
                CurrentlyEquippedWeapon = weaponsAquired[currentWeaponIndex];
                playerWeapon.ChangeMesh(currentlyEquippedWeapon.WeaponMesh);
                if (weaponsAmmo.ContainsKey(currentlyEquippedWeapon))
                {
                    playerWeapon.CurrentWeaponAmmo = weaponsAmmo[currentlyEquippedWeapon];
                }
                else
                {
                    weaponsAmmo.Add(currentlyEquippedWeapon, currentlyEquippedWeapon.MaxAmmo);
                }
            }
        }
    }
    void ChangeCurrentWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ChangeWeapon();
        }
    }
}
