using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInWorld : MonoBehaviour,IInteractable
{
    [SerializeField] Weapon thisWeapon;
    public void OnInteraction()
    {
        
    }
}
