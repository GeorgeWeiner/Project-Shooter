using Inputs;
using UnityEngine;

namespace Movement
{
    public class ViewBob : MonoBehaviour
    {
        [SerializeField] private bool enable = true;

        
        [Header("Intensity")]
        [SerializeField] private float amplitudeWalking = 0.15f;
        [SerializeField] private float frequencyWalking = 15f;
        
        [SerializeField] private float amplitudeSprinting = 0.3f;
        [SerializeField] private float frequencySprinting = 25f;

        [Header("Cameras")]
        [SerializeField] private Transform cam;
        [SerializeField] private Transform cameraHolder;

        private const float ToggleSpeed = 3f;
        private Vector3 _startPos;
        private PlayerMovement _controller;
        private Rigidbody _rb;
        private float _amplitude;
        private float _frequency;
        

        private void Awake()
        {
            _controller = GetComponentInParent<PlayerMovement>();
            _rb = GetComponentInParent<Rigidbody>();
            _startPos = cam.localPosition;
        }

        private void Update()
        {
            if (!enable) return;
            
            CheckMotion();
            ResetPosition();
            ControlIntensity();
            cam.LookAt(FocusTarget());
        }

        private void CheckMotion()
        {
            var velocity = _rb.velocity;
            var speed = new Vector3(velocity.x, 0, velocity.z).magnitude;

            if (speed < ToggleSpeed) return;
            if (!_controller.IsGrounded()) return;
            
            PlayMotion(FootStepMotion());
        }
        
        private void PlayMotion(Vector3 motion)
        {
            cam.localPosition += motion; 
        }

        private void ResetPosition()
        {
            if (cam.localPosition == _startPos) return;

            cam.localPosition = Vector3.Lerp(cam.localPosition, _startPos, Time.deltaTime);
        }

        private Vector3 FootStepMotion()
        {
            var pos = Vector3.zero;
            pos.y += Mathf.Sin(Time.time * _frequency) * _amplitude;
            pos.x += Mathf.Cos(Time.time * _frequency / 2) * _amplitude * 2;

            return pos;
        }

        private Vector3 FocusTarget()
        {
            var position = transform.position;
            var pos = new Vector3(position.x, position.y + cameraHolder.localPosition.y, position.z);
            pos += cameraHolder.forward * 50f;
            return pos;
        }

        private void ControlIntensity()
        {
            if (PlayerInput.Sprint() && PlayerInput.InputY() != 0f || PlayerInput.Sprint() && PlayerInput.InputX() != 0f)
            {
                _amplitude = amplitudeSprinting;
                _frequency = frequencySprinting;
            }
            else
            {
                _amplitude = amplitudeWalking;
                _frequency = frequencyWalking;
            }
        }
    }
}
