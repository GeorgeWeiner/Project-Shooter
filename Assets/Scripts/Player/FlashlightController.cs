using Inputs;
using UnityEngine;

namespace Player
{
    public class FlashlightController : MonoBehaviour
    {
        [SerializeField] private GameObject flashlight;
    
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
            
            //Play sound here or whatever
        }
    }
}
