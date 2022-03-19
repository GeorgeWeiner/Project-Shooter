using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInWorld : MonoBehaviour,IInteractable
{
    [SerializeField] Weapon thisWeapon;
    public void OnInteraction()
    {
        Inventory.Instance.WeaponsAquired.Add(thisWeapon);
        Inventory.Instance.AddWeaponPrefab(thisWeapon.WeaponPrefab);
        Inventory.Instance.ChangeWeapon();
        Inventory.Instance.CurrentlyEquippedWeapon = thisWeapon;
        Destroy(gameObject);
    }
}
