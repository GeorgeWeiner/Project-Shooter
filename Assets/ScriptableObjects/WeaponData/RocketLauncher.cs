using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "NewWeapon/RocketLauncher", fileName = "PlasmaCutter", order = 1)]
public class RocketLauncher : Weapon
{
    public override void FireWeapon(Transform weaponFirePoint)
    {
        Debug.Log("ROCKETFIRED");
    }
}
