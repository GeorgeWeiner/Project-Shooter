using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunPistol : WeaponBaseScript
{
    private void Update()
    {
        ShootCurrentWeapon();
    }
    protected override void ShootCurrentWeapon()
    {
        if (Input.GetMouseButton(0) && canShoot)
        {
            currentAmmo -= 1;
            base.ShootCurrentWeapon();
        }
       
    }
}
