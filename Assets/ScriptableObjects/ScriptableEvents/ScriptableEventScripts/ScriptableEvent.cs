using System.Collections;
using System.Collections.Generic;
using BaseScripts;
using UnityEngine;

public enum TypeOfThisEvent
{
    audioEvent,
    enemyEvent
}
public abstract  class ScriptableEvent : ScriptableObject
{
    [SerializeField] protected TypeOfThisEvent typeOfThisEvent;
    public TypeOfThisEvent TypeOfThisEvent { get { return typeOfThisEvent; } }
    [SerializeField] protected Timer eventTimer;
    [SerializeField] float eventDelay;
    protected abstract void EventFunction<T>(T parameter) where T : Transform;
    public virtual void StartEvent<T>(T parameter) where T : Transform
    {
        EventFunction<T>(parameter);
    }
}
