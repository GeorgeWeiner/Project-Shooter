using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "NewWeapon/ShotgunPistol", fileName = "ShotgunPistol",order = 0)]
public class ShotGunPistol : Weapon
{
    public override void FireWeapon()
    {
        Debug.Log("Hello");
    }
}
