using System.Runtime.CompilerServices;
using UnityEngine;

namespace Inputs
{
    public class PlayerInput : MonoBehaviour
    {
        private static PlayerInput _instance;
        
        public static PlayerInput Instance => _instance;
        public float PlayerInputX() => Input.GetAxisRaw("Horizontal");
        public float PlayerInputY() => Input.GetAxisRaw("Vertical");

        public float PlayerMouseInputX() => Input.GetAxisRaw("Mouse Y");
        public float PlayerMouseInputY() => Input.GetAxisRaw("Mouse X");

        public bool PlayerJump() => Input.GetKeyDown(KeyCode.Space);
        public bool PlayerShoot() => Input.GetMouseButton(0);
        public bool PlayerInteract() => Input.GetKeyDown(KeyCode.E);

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
            } 
            else 
            {
                _instance = this;
            }
        }
    }
}