using DefaultNamespace.Interfaces;
using UnityEngine;

namespace DefaultNamespace
{
    public class ButtonInteractionResponse : MonoBehaviour, IInteractable
    {
        public void OnInteraction()
        {
            GetComponent<IButtonResponse>().ExecuteButtonFunctionality();
        }
    }
}