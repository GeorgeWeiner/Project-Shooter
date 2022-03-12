using Inputs;
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
            if (PlayerInput.Shoot() && canShoot)
            {
                currentAmmo -= 1;
                base.Shoot();
            }
        }
    }
}
