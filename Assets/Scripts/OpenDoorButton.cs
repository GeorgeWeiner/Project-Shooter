using DefaultNamespace.Interfaces;
using UnityEngine;

namespace DefaultNamespace
{
    public class OpenDoorButton : MonoBehaviour, IButtonResponse
    {
        [SerializeField] private DoorPosition doorState;
        [SerializeField] private float doorSpeed;
        
        private float _currentProgress;
        
        public void ExecuteButtonFunctionality()
        {
            doorState.isOpen = !doorState.isOpen;
        }

        private void Update()
        {
            MoveDoor();
        }

        private void MoveDoor()
        {
            doorState.door.localPosition =
                Vector3.Lerp(doorState.doorStates[0], doorState.doorStates[1], _currentProgress);
            
            _currentProgress = Mathf.Clamp01(_currentProgress);

            if (doorState.isOpen)
                _currentProgress += doorSpeed * Time.deltaTime;
            else
                _currentProgress -= doorSpeed * Time.deltaTime;
        }

        [ContextMenu("Set Door Closed Position")]
        private void EditDoorPositionClosed()
        {
            doorState.doorStates[0] = doorState.door.localPosition;
        }
        [ContextMenu("Set Door Opened Position")]
        private void EditDoorPositionOpened()
        {
            doorState.doorStates[1] = doorState.door.localPosition;
        }
    }

    [System.Serializable]
    public struct DoorPosition
    {
        public Transform door;
        public Vector3[] doorStates;
        public bool isOpen;
    }
}