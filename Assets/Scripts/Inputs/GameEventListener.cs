﻿using Events;
using UnityEngine;
using UnityEngine.Events;

namespace Inputs
{
    public class GameEventListener : MonoBehaviour
    {
        [SerializeField] protected GameEvent gameEvent;
        [SerializeField] protected UnityEvent unityEvent;

        private void Awake()
        {
            gameEvent.Register(this);
        }

        private void OnDestroy()
        {
            gameEvent.Deregister(this);
        }

        public virtual void RaiseEvent()
        {
            unityEvent.Invoke();
        }
    }
}