using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inputs;

public class Laser : MonoBehaviour
{
    [SerializeField] ParticleSystem laser;
    void Update()
    {
        ShootLaser();
    }
    void ShootLaser()
    {
        if (PlayerInput.Shoot())
        {
            Debug.Log("HEHEH");
            if (!laser.isPlaying)
            {
                laser.Play();
            }
        }
        else if(!PlayerInput.Shoot())
        {
            laser.Stop();
        }
    }
}
