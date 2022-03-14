using System.Runtime.CompilerServices;
using UnityEngine;

namespace Inputs
{
    public class PlayerInput : MonoBehaviour
    {
        public static PlayerInput Instance { get; private set; }

#if ENABLE_LEGACY_INPUT_MANAGER
        public static float InputX() => Input.GetAxisRaw("Horizontal");
        public static float InputY() => Input.GetAxisRaw("Vertical");
        public static float MouseInputX() => Input.GetAxisRaw("Mouse Y");
        public static float MouseInputY() => Input.GetAxisRaw("Mouse X");
        public static bool Jump() => Input.GetKeyDown(KeyCode.Space);
        public static bool Shoot() => Input.GetMouseButton(0);
        public static bool Reload() => Input.GetKeyDown(KeyCode.R);
        public static bool Interact() => Input.GetKeyDown(KeyCode.E);
        public static bool Sprint() => Input.GetKey(KeyCode.LeftShift);
#endif        
        
        public static Vector3 playerForward;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            } 
            else 
            {
                Instance = this;
            }
        }
    }
}