using UnityEngine;

namespace Weapons
{
    public class ShotgunPistol : Weapon
    {
        private void Update()
        {
            Shoot();
        }
        protected override void Shoot()
        {
            if (Input.GetMouseButton(0) && canShoot)
            {
                currentAmmo -= 1;
                base.Shoot();
            }
       
        }
    }
}
