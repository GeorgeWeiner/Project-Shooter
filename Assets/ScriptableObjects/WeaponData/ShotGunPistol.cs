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
        AudioSource.PlayClipAtPoint(weaponSound, weaponFirePoint.position);
        for (int i = 0; i < numberOfBullets; i++)
        {
            RaycastHit hitInfo;
            float xOffset= Random.Range(-xSpray,xSpray);
            float yOffset = Random.Range(-ySpray, ySpray);
            Ray ray = new Ray(weaponFirePoint.position , -weaponFirePoint.forward + new Vector3(xOffset, yOffset, 0));
            bool hitTarget = Physics.Raycast(ray, out hitInfo, float.MaxValue, hitLayer);
            if (hitTarget)
            {
                Debug.Log("HEHEHEHEHEH");
                if(hitInfo.collider.gameObject.GetComponent<IDamageable>() != null)
                {
                    hitInfo.collider.gameObject.GetComponent<IDamageable>().TakeDmg(weaponDmg);
                } 
            }
        }
    }
}
