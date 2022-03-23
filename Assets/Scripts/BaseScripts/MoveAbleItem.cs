using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody))]
public  class MoveAbleItem : MonoBehaviour,IMoveAble
{
    bool isGrabbed;
    Rigidbody objectRb;

    private void Awake()
    {
        objectRb = GetComponent<Rigidbody>();
    }
    public void OnGrab(Vector3 grabPoint,Transform holder)
    {
        if (!isGrabbed)
        {
            isGrabbed = true;
            transform.position = grabPoint + Vector3.forward;
            objectRb.useGravity = false;
        }
        else
        {
            transform.position = holder.position + holder.forward * 4;
        }   
    }

    public void OnRelease()
    {
        isGrabbed = false;
        objectRb.useGravity = true;
    }
}
