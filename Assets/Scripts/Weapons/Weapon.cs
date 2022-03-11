using System.Collections;
using UnityEngine;

namespace Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected WeaponData currentlyEquippedWeaponData;
        public WeaponData CurrentlyEquippedWeaponData { get { return currentlyEquippedWeaponData; } set { currentlyEquippedWeaponData = value;} }
        [SerializeField] MeshRenderer weaponMesh;
        [SerializeField] protected Transform weaponTransform;
        [SerializeField] protected float currentAmmo;
        protected bool canShoot = true;
        protected bool isReloading;
        private void Awake()
        {
            currentAmmo = CurrentlyEquippedWeaponData.MaxAmmo;
            EventManager.Instance.reloadWeapon += Reload;
        }
        private void OnDestroy()
        {
            EventManager.Instance.reloadWeapon -= Reload;
        }
        private void Reload()
        {
            StartCoroutine(ReloadWeapon()); 
        }
        protected virtual void Shoot()
        {
            Debug.Log("HIII");
            StartCoroutine(DelayBetweenShots());
        }
        private IEnumerator DelayBetweenShots()
        {
            canShoot = false;
            yield return new WaitForSeconds(currentlyEquippedWeaponData.WeaponDelay);
            canShoot = true;
        }
        private IEnumerator ReloadWeapon()
        {
            //PlaySound Animation usw
            isReloading = true;
            canShoot = false;
            yield return new WaitForSeconds(currentlyEquippedWeaponData.WeaponReloadTime);
            currentAmmo = currentlyEquippedWeaponData.MaxAmmo;
            canShoot = true;
            isReloading = false;
        }

    }
}
