using System;
using Inputs;
using UnityEngine;

namespace Weapons
{
   public class WeaponSway : MonoBehaviour
   {
      [Header("Position")]
      [SerializeField] private float amountPosition;
      [SerializeField] private float maxPositionDisplacement;
      [SerializeField] private float positionSmoothing;

      [Header("Rotation")]
      [SerializeField] private float amountRotation;
      [SerializeField] private float smoothingRotation;
      [SerializeField] private float rotationClamp;
      
      private Vector3 _initialPosition;

      private void Awake()
      {
         _initialPosition = transform.localPosition;
      }

      private void Update()
      {
         ApplySway();
      }

      private void ApplySway()
      {
         transform.localPosition = CalculateSway();
         transform.localRotation = CalculateRotation();
      }

      private Vector3 CalculateSway()
      {
         var movementX = PlayerInput.MouseInputX() * amountPosition;
         var movementY = PlayerInput.MouseInputY() * amountPosition;

         movementX = Mathf.Clamp(movementX, -maxPositionDisplacement, maxPositionDisplacement);
         movementY = Mathf.Clamp(movementY, -maxPositionDisplacement, maxPositionDisplacement);

         var finalPosition = new Vector3(movementY, movementX, 0f);
         
         return Vector3.Lerp(transform.localPosition, _initialPosition + finalPosition,
            Time.deltaTime * positionSmoothing);
      }

      private Quaternion CalculateRotation()
      {
         var movementX = PlayerInput.MouseInputX() * amountRotation;
         var movementY = PlayerInput.MouseInputY() * amountRotation;

         movementX = Mathf.Clamp(movementX, -rotationClamp, rotationClamp);
         movementY = Mathf.Clamp(movementY, -rotationClamp, rotationClamp);

         var rotationX = Quaternion.AngleAxis(movementX, Vector3.right);
         var rotationY = Quaternion.AngleAxis(-movementY, Vector3.up);

         var targetRotation = rotationX * rotationY;
         
         return Quaternion.Slerp(transform.localRotation, targetRotation, smoothingRotation * Time.deltaTime);
      }
   }
}
