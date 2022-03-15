using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "NewWeapon/PlasmaCutter", fileName = "PlasmaCutter", order = 1)]
public class PlasmaCutter : Weapon
{
    public override void FireWeapon(Transform weaponFirePoint)
    {
        Debug.Log("Fire");
    }
}
