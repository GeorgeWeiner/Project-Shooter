using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Audio;

[CreateAssetMenu(menuName = "NewWeapon/PlasmaCutter", fileName = "PlasmaCutter", order = 1)]
public class PlasmaCutter : Weapon
{
    [SerializeField] float laserRange;
    public override void FireWeapon(Transform weaponFirePoint)
    {
        SoundManager.PlaySound(WeaponSound, "plasmaGunSound",true,1);
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
