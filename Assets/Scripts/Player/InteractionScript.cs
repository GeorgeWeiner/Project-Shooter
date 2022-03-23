using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionScript : MonoBehaviour
{
    delegate void ReleaseItem();
    ReleaseItem releaseItem;
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
            if(hitInfo.collider.GetComponent<IInteractable>() != null)
            {
                hitInfo.collider.gameObject.GetComponent<IInteractable>().OnInteraction();
            }
        }
        if (interactableInReach && Input.GetKey(interactionKey))
        {
            if(hitInfo.collider.GetComponent<IMoveAble>() != null)
            {
                hitInfo.collider.GetComponent<IMoveAble>().OnGrab(hitInfo.point,transform);
                releaseItem = hitInfo.collider.GetComponent<IMoveAble>().OnRelease;
            }  
        }
        else if ( Input.GetKeyUp(interactionKey) || !interactableInReach)
        {
            releaseItem?.Invoke();
        }
    }
}
