using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "NewWeapon/PlasmaCutter", fileName = "PlasmaCutter", order = 1)]
public class PlasmaCutter : Weapon
{
    [SerializeField] float laserRange;
    [SerializeField] ParticleSystem laser;
    public override void FireWeapon(Transform weaponFirePoint)
    {
        Ray ray = new Ray(weaponFirePoint.position, weaponFirePoint.forward);
        RaycastHit[] enemies = Physics.RaycastAll(ray,laserRange,hitLayer);
        foreach (var enemyHit in enemies)
        {
            if(enemyHit.collider.gameObject.GetComponent<IDamageable>() != null)
            {
                enemyHit.collider.gameObject.GetComponent<IDamageable>().TakeDmg(weaponDmg);
            }  
        }
    }
}
