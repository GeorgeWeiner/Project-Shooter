using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveAble 
{
    void OnGrab(Vector3 grabPoint,Transform holder);
    void OnRelease();
}
