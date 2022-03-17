using System;
using Inputs;
using UnityEngine;

namespace Player
{
    public class FlashlightController : MonoBehaviour
    {
        [SerializeField] private GameObject flashlight;
        [SerializeField] private AudioSource audioSource;
    
        private bool _flashLightToggled;

        private void Update()
        {
            ToggleFlashlight();
        }
        private void ToggleFlashlight()
        {
            if (!PlayerInput.Flashlight()) return;
        
            _flashLightToggled = !_flashLightToggled;
            flashlight.SetActive(_flashLightToggled);
            
            audioSource.PlayOneShot(audioSource.clip);
        }
    }
}
