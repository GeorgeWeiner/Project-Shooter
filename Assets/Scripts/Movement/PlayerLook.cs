using Inputs;
using UnityEngine;

namespace Movement
{
    public class PlayerLook : MonoBehaviour
    {
        public float sensX, sensY;
        private Transform _cam;

        private float _yRotation, _xRotation;
        private const float Multiplier = 100f;
        
        private void LookAround()
        {
            _yRotation += PlayerInput.Instance.PlayerMouseInputX() * sensX * Multiplier;
            _xRotation -= PlayerInput.Instance.PlayerMouseInputX() * sensY * Multiplier;
            
            _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
            //_cam.localRotation = Quaternion.Euler();
        }
    }
}