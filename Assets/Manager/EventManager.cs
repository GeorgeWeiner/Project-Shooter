using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : BaseSingleton<EventManager>
{
    public delegate void ReloadWeapon();
    public event ReloadWeapon reloadWeapon;
    void Update()
    {
        ReloadWeaponEvent();
    }
    void ReloadWeaponEvent()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if(reloadWeapon != null)
            {
                reloadWeapon();
            }
        }
    }
}
