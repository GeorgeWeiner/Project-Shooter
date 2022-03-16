using Inputs;
using UnityEngine;

namespace Movement
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float walkSpeed = 150f;
        [SerializeField] private float sprintSpeed = 230f;
        [SerializeField] private float jumpForce = 10f;
        [SerializeField] private float distanceToGround = 1f;
        [SerializeField] private float maxDistanceGroundInfo = 5f;
        [SerializeField] private float gravityStrength;
        [SerializeField] private float gravityAcceleration = 50f;
        
        [SerializeField] private LayerMask groundLayer;
        
        [Header("Crouching")]
        [SerializeField] private Vector3 crouchScale;
        [SerializeField] private float crouchSpeed;
        
        private Vector3 _normalScale;
        private float _crouchScaleDifference;
        private Rigidbody _rb;
        private CapsuleCollider _col;
        private PlayerLook _playerLook;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _col = GetComponent<CapsuleCollider>();
            _playerLook = GetComponentInChildren<PlayerLook>();
            _normalScale = transform.localScale;
        }

        private void Update()
        {
            Jump();
            Crouch();
        }

        private void FixedUpdate()
        {
            MovePlayer();
            GravityStrength();
            Gravity();
        }

        private void MovePlayer()
        {
            var directionHorizontal = _playerLook.transform.forward * PlayerInput.InputY() + _playerLook.transform.right * PlayerInput.InputX();
            var projectOnPlane = Vector3.ProjectOnPlane(directionHorizontal, GroundInfo().normal);

            _rb.AddForce(projectOnPlane.normalized * MovementSpeed() * Time.fixedDeltaTime * 100f, ForceMode.Acceleration);
            _rb.AddForce(-projectOnPlane.normalized * (MovementSpeed() * 0.75f) * Time.fixedDeltaTime * 100f, ForceMode.Acceleration);
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
        }

        private void Gravity()
        {
            if (!IsGrounded())
            {
                _rb.AddForce(0f, -gravityStrength, 0f, ForceMode.Acceleration);
            }
        }

        private float MovementSpeed()
        {
            return PlayerInput.Sprint() ? sprintSpeed : walkSpeed;
        }

        public bool IsGrounded()
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

        private void GravityStrength()
        {
            if (!IsGrounded())
            {
                gravityStrength += gravityAcceleration * Time.fixedDeltaTime;
            }
            else
            {
                gravityStrength = 0f;
            }
        }

        private void Crouch()
        {
            Vector3 localScale;
            
            if (!PlayerInput.Crouch() && CanStandUp())
                localScale = _normalScale;
            else
                localScale = crouchScale;
            
            transform.localScale = Vector3.MoveTowards(transform.localScale, localScale, crouchSpeed * Time.deltaTime);
        }

        private bool CanStandUp()
        {
            var myTransform = transform;
            return !Physics.Raycast(myTransform.position, myTransform.up, 3f);
        }
    }
}
