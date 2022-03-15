using System.Collections;
using System.Collections.Generic;
using BaseScripts;
using UnityEngine;

public abstract class ScriptableEvent : MonoBehaviour
{
    [SerializeField] Timer eventTimer;
    public abstract void EventFunction();
}
