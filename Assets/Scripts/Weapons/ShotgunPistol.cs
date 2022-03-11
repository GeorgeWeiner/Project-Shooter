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
            if (PlayerInput.Instance.PlayerShoot() && canShoot)
            {
                currentAmmo -= 1;
                base.Shoot();
            }
        }
    }
}
