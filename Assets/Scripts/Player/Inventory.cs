using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : BaseSingleton<Inventory>
{
    [SerializeField] Transform weaponHoldPoint;
    [SerializeField] List<GameObject> weaponPrefabs;
    public List<GameObject> WeaponPrefabs { get { return weaponPrefabs; } set { weaponPrefabs = value; } }
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
                ChangeWeaponPrefab(weaponPrefabs[currentWeaponIndex]);
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
                ChangeWeaponPrefab(weaponPrefabs[currentWeaponIndex]);
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
                ChangeWeaponPrefab(weaponPrefabs[currentWeaponIndex]);
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
    public void AddWeaponPrefab(GameObject weaponPrefabToAdd)
    {
        var weapon = Instantiate(weaponPrefabToAdd, weaponHoldPoint.position, weaponHoldPoint.rotation);
        weapon.transform.SetParent(weaponHoldPoint, true);
        weaponPrefabs.Add(weapon);
    }
    void ChangeWeaponPrefab(GameObject weaponPrefabToSetActive)
    {
        for (int i = 0; i < weaponPrefabs.Count; i++)
        {
            var weaponPrefabToSetInactive = weaponPrefabs[i];
            if (weaponPrefabs.Contains(weaponPrefabToSetInactive))
            {
                weaponPrefabToSetInactive.SetActive(false);
            }
        }
        weaponPrefabToSetActive.SetActive(true);
    }
    void ChangeCurrentWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ChangeWeapon();
        }
    }
}
