using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "NewWeapon/RocketLauncher", fileName = "PlasmaCutter", order = 1)]
public class RocketLauncher : Weapon
{
    [SerializeField] GameObject rocket;
    public override void FireWeapon(Transform weaponFirePoint)
    {
        var tempRocket = Instantiate(rocket, weaponFirePoint.position + weaponFirePoint.forward , weaponFirePoint.rotation);
    }
}
