using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPack : MonoBehaviour ,IInteractable
{
    [SerializeField] AmmoType typeOfAmmo;
    [SerializeField] int ammoPackSize;

    public void OnInteraction()
    {   
        if(!Inventory.Instance.WeaponCarriedAmmo.ContainsKey(typeOfAmmo))
        {
            Inventory.Instance.WeaponCarriedAmmo.Add(typeOfAmmo, ammoPackSize);
            Debug.Log(Inventory.Instance.WeaponCarriedAmmo[typeOfAmmo]);
        }
        else
        {
            Inventory.Instance.WeaponCarriedAmmo[typeOfAmmo] += ammoPackSize;
            Debug.Log(Inventory.Instance.WeaponCarriedAmmo[typeOfAmmo]);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInParent<Inventory>() != null)
        {
            OnInteraction();
            Destroy(gameObject);
        }
    }
}
