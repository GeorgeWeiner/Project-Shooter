using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionScript : MonoBehaviour
{
    [SerializeField] LayerMask interactableLayer;
    [SerializeField] KeyCode interactionKey;
    [SerializeField] float interactionRange;
    void Update()
    {
        CheckForInteractable();
    }
    void CheckForInteractable()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;
        bool interactableInReach = Physics.Raycast(ray, out hitInfo, interactionRange, interactableLayer);
        if (interactableInReach && Input.GetKeyDown(interactionKey))
        {
            hitInfo.collider.gameObject.GetComponent<IInteractable>().OnInteraction();
        }
    }
}
