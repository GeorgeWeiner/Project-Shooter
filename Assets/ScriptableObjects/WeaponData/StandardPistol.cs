using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "NewWeapon/StandardPistol", fileName = "Pistol", order = 1)]
public class StandardPistol : Weapon
{
    public override void FireWeapon(Transform weaponFirePoint)
    {
        AudioSource.PlayClipAtPoint(weaponSound, weaponFirePoint.position);
        Ray ray = new Ray(weaponFirePoint.position, weaponFirePoint.forward);
        RaycastHit hitInfo;
        bool hitTarget = Physics.Raycast(ray,out hitInfo, 30f, hitLayer);
        if (hitTarget)
        {
            if(hitInfo.collider.gameObject.GetComponent<IDamageable>() != null)
            {
                hitInfo.collider.gameObject.GetComponent<IDamageable>().TakeDmg(weaponDmg);
            }
        }
    }

}
