using Interfaces;
using UnityEngine;

namespace Inputs
{
    public class ButtonInteractionResponse : MonoBehaviour, IInteractable
    {
        public void OnInteraction()
        {
            GetComponent<IButtonResponse>().ExecuteButtonFunctionality();
        }
    }
}