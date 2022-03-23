using System;
using System.Collections.Generic;
using Inputs;
using UnityEngine;
using UnityEngine.Events;

namespace Events
{
    [CreateAssetMenu(menuName = "Game Event", fileName = "New Game Event")]
    public class GameEvent : ScriptableObject
    {
        private HashSet<GameEventListener> _listeners = new HashSet<GameEventListener>();
        
        //Calls all the listeners in the hashset.
        public void Invoke()
        {
            foreach (var globalEventListener in _listeners)
            {
                globalEventListener.RaiseEvent();
            }
        }

        public void Register(GameEventListener gameEventListener)
        {
            _listeners.Add(gameEventListener);
        }

        public void Deregister(GameEventListener gameEventListener)
        {
            _listeners.Remove(gameEventListener);
        }
    }
}