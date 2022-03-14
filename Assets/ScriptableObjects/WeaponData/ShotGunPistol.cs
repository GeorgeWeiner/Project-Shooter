using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "NewWeapon/ShotgunPistol", fileName = "ShotgunPistol",order = 0)]
public class ShotGunPistol : Weapon
{
    [SerializeField] int numberOfBullets;
    [SerializeField] float ySpray;
    [SerializeField] float xSpray;
    public override void FireWeapon(Transform weaponFirePoint)
    {
        for (int i = 0; i < numberOfBullets; i++)
        {
            Debug.Log("HEY");
            float xAngle = Random.Range(-xSpray,xSpray);
            float yAngle = Random.Range(-ySpray, ySpray);
            var tempProjectile = Instantiate(projectile, weaponFirePoint.position,weaponFirePoint.rotation);
            tempProjectile.transform.rotation = Quaternion.Euler(tempProjectile.transform.localRotation.x + xAngle, tempProjectile.transform.localRotation.y + yAngle, 0);
            var tempProjectileComponent = tempProjectile.GetComponent<Projectile>();
            tempProjectileComponent.ProjectileDmg = weaponDmg;
        }
    }
}
