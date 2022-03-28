using FMODUnity;
using Inputs;
using Movement;
using UnityEngine;

namespace Audio
{
    public class FootstepManager : MonoBehaviour
    {
        [SerializeField] private float minFootstepVelocity;
        [SerializeField] private EventReference footstepWalking;
        [SerializeField] private EventReference footstepRunning;
    
        private PlayerMovement _playerMovement;
        private Rigidbody _rb;
        private StudioEventEmitter _emitter;
    
        private void Awake()
        {
            _playerMovement = GetComponentInParent<PlayerMovement>();
            _rb = GetComponentInParent<Rigidbody>();
            _emitter = GetComponent<StudioEventEmitter>();
        }

        private void Update()
        {
            PlayFootstepSound();
        }

        private void PlayFootstepSound()
        {
            if (_rb.velocity.magnitude < minFootstepVelocity || !_playerMovement.IsGrounded()) return;
        
            ChangeFootstepSound();
            _emitter.Play();
        }

        private void ChangeFootstepSound()
        {
            _emitter.EventReference = PlayerInput.Sprint() ? footstepRunning : footstepWalking;
        }
    }
}
