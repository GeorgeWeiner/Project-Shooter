using Events;
using UnityEngine;

namespace Inputs
{
    public class GenericCallEvent : MonoBehaviour, IInteractable
    {
        [SerializeField] private GameEvent someGameEvent;
        public void OnInteraction()
        {
            if (someGameEvent != null)
                someGameEvent.Invoke();
        }
    }
}