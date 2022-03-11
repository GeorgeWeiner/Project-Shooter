using Cinemachine;
using Inputs;
using UnityEngine;

namespace Movement
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 5f;
        [SerializeField] private float jumpForce = 10f;
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private float distanceToGround;
        [SerializeField] private Transform orientation;
        [SerializeField] private CinemachineVirtualCamera virtualCamera;
     
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
            var movementDirection = _playerLook.transform.forward * PlayerInput.Instance.PlayerInputY() + _playerLook.transform.right * PlayerInput.Instance.PlayerInputX();

            _rb.AddForce(movementDirection.normalized * movementSpeed * Time.fixedDeltaTime * 100f, ForceMode.Acceleration);
        }

        private void Jump()
        {
            if (IsGrounded() && PlayerInput.Instance.PlayerJump())
            {
                _rb.AddForce(0f, jumpForce, 0f);
            }
        }

        private void Interact()
        {
            if (PlayerInput.Instance.PlayerInteract())
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
    }
}
