using Cinemachine;
using Inputs;
using UnityEngine;

namespace Movement
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float walkSpeed, sprintSpeed;
        [SerializeField] private float jumpForce = 10f;
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private float distanceToGround;
        [SerializeField] private float maxDistanceGroundInfo;
        [SerializeField] private float gravityStrength;

        private Rigidbody _rb;
        private CapsuleCollider _col;
        private PlayerLook _playerLook;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _col = GetComponent<CapsuleCollider>();
            _playerLook = GetComponentInChildren<PlayerLook>();
        }

        private void Update()
        {
            Jump();
        }

        private void FixedUpdate()
        {
            MovePlayer();
        }

        private void MovePlayer()
        {
            var movementDirectionHorizontal = _playerLook.transform.forward * PlayerInput.InputY() + _playerLook.transform.right * PlayerInput.InputX();
            var slopeMovementDirection = Vector3.ProjectOnPlane(movementDirectionHorizontal, GroundInfo().normal);

            _rb.AddForce(slopeMovementDirection.normalized * MovementSpeed() * Time.fixedDeltaTime * 100f, ForceMode.Acceleration);
            _rb.AddForce(-slopeMovementDirection.normalized * (MovementSpeed() * 0.75f) * Time.fixedDeltaTime * 100f, ForceMode.Acceleration);
        }

        private void Jump()
        {
            if (IsGrounded() && PlayerInput.Jump())
            {
                var velocity = _rb.velocity;
                velocity = new Vector3(velocity.x, 0f, velocity.z);
                
                _rb.velocity = velocity;
                _rb.AddForce(0f, jumpForce, 0f, ForceMode.Impulse);
            }
            
            else if (!IsGrounded())
            {
                _rb.AddForce(0f, -gravityStrength, 0f, ForceMode.Acceleration);
            }
        }

        private float MovementSpeed()
        {
            return PlayerInput.Sprint() ? sprintSpeed : walkSpeed;
        }

        private void Interact()
        {
            if (PlayerInput.Interact())
            {
                //Do thing to pick up props and stuff.
            }
        }

        private bool IsGrounded()
        {
            var bounds = _col.bounds;
            var capsuleBottom = new Vector3(bounds.center.x, bounds.min.y, bounds.center.z);

            return Physics.CheckCapsule(bounds.center, capsuleBottom, distanceToGround, groundLayer,
                QueryTriggerInteraction.Ignore);
        }

        private RaycastHit GroundInfo()
        {
            var myTransform = transform;
            Physics.Raycast(myTransform.position, -myTransform.up, out var hit, maxDistanceGroundInfo,
                groundLayer, QueryTriggerInteraction.Ignore);
            
            return hit;
        }
    }
}
