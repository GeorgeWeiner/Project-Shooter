using System;
using Inputs;
using UnityEngine;

namespace Player
{
    public class Interaction : MonoBehaviour
    {
        [SerializeField] private float maxInteractionDistance;
        [SerializeField] private LayerMask interactionLayerMask;

        private Transform _origin;

        private void Start()
        {
            _origin = transform;
        }

        private void Update()
        {
            Interact();
            DebugRay();
        }

        private void Interact()
        {
            if (!Physics.Raycast(_origin.position, _origin.forward, out var hit, maxInteractionDistance, interactionLayerMask, QueryTriggerInteraction.Collide)) return;
            if (PlayerInput.Interact())
            {
                hit.collider.GetComponent<IInteractable>().OnInteraction();
            }
        }

        private void DebugRay()
        {
            Debug.DrawRay(_origin.position, _origin.forward, Color.green, maxInteractionDistance);
        }
    }
}
