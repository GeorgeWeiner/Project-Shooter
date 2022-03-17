using Inputs;
using UnityEngine;

namespace Weapons
{
   public class WeaponSway : MonoBehaviour
   {
      [SerializeField] private float amount;
      [SerializeField] private float maxAmount;
      [SerializeField] private float smoothAmount;

      private Vector3 _initialPosition;

      private void Start()
      {
         _initialPosition = transform.localPosition;
      }

      private void Update()
      {
         var movementX = PlayerInput.MouseInputX() * amount;
         var movementY = PlayerInput.MouseInputY() * amount;

         movementX = Mathf.Clamp(movementX, -maxAmount, maxAmount);
         movementY = Mathf.Clamp(movementY, -maxAmount, maxAmount);

         var finalPosition = new Vector3(movementY, movementX, 0f);
         transform.localPosition = Vector3.Lerp(transform.localPosition, _initialPosition + finalPosition,
            Time.deltaTime * smoothAmount);
      }
   }
}
