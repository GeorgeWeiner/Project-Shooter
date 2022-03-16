using System;
using UnityEngine;
using UnityEngine.Events;

namespace BaseScripts
{
    public class Timer : MonoBehaviour
    {
        private Action _timerCallback;
        private float _timer;
        
        public void CreateTimer(float timer, Action timerCallback)
        {
            _timer = timer;
            _timerCallback = timerCallback;
        }

        private void Update()
        {
            if (_timer >= 0f)
            {
                _timer -= Time.deltaTime;
                if (IsTimerComplete())
                {
                    _timerCallback();
                }
            }
        }

        private bool IsTimerComplete()
        {
            return _timer <= 0f;
        }
    }
}
