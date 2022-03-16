using System.Collections;
using BaseScripts;
using UnityEngine;
using UnityEngine.Events;

namespace Inputs
{
    public class GameEventListenerWithDelay : GameEventListener
    {
        [SerializeField] private float delay;
        [SerializeField] private UnityEvent delayedUnityEvent;
        

        public override void RaiseEvent()
        {
            StartCoroutine(DelayTimer());
        }

        private IEnumerator DelayTimer()
        {
            yield return new WaitForSeconds(delay);
            delayedUnityEvent.Invoke();
        }
    }
}