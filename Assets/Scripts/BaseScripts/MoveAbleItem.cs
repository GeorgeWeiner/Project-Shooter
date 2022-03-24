using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody))]
public  class MoveAbleItem : MonoBehaviour,IMoveAble,ISaveAble
{
    bool isGrabbed;
    Rigidbody objectRb;

    private void Awake()
    {  
        objectRb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        AddToSaveManager();
    }
    public void OnGrab(Vector3 grabPoint,Transform holder)
    {
        if (!isGrabbed)
        {
            isGrabbed = true;
            objectRb.useGravity = false;
        }
        else
        {
            transform.position = holder.position + holder.forward * 2;
        }   
    }
    public void OnRelease()
    {
        isGrabbed = false;
        objectRb.useGravity = true;
    }

    public void AddToSaveManager()
    {
        SaveManager.Instance.SaveAbles.Add(this.gameObject);
    }
}
