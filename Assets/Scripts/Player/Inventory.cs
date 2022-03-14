using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : BaseSingleton<Inventory>
{
    [SerializeField] List<Weapon> weaponsAquired;
    Weapon currentlyEquippedWeapon;
    public Weapon CurrentlyEquippedWeapon { get { return currentlyEquippedWeapon; } set { currentlyEquippedWeapon = value; } }
    WeaponInput playerWeapon;
    int currentWeaponIndex;
    private void Awake()
    {
        playerWeapon = GetComponent<WeaponInput>();
        currentWeaponIndex = weaponsAquired.Count;
    }
    private void Update()
    {
        ChangeCurrentWeapon();
    }
    public void ChangeWeapon()
    {
        if(currentWeaponIndex != weaponsAquired.Count)
        {
            Debug.Log("Changed");
            currentlyEquippedWeapon = weaponsAquired[currentWeaponIndex];
            playerWeapon.WeaponToFire = weaponsAquired[currentWeaponIndex];
            currentWeaponIndex++;
        }
        else
        {
            currentWeaponIndex = 0;
            currentlyEquippedWeapon = weaponsAquired[currentWeaponIndex];
            playerWeapon.WeaponToFire = weaponsAquired[currentWeaponIndex];
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
