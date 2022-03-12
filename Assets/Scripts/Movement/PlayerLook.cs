﻿using System;
using Inputs;
using UnityEngine;

namespace Movement
{
    public class PlayerLook : MonoBehaviour
    {
        public float sensX, sensY;
        public Transform cam;

        private float _yRotation, _xRotation;
        private const float Multiplier = 100f;

        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            LookAround();
        }

        private void LookAround()
        {
            _xRotation -= PlayerInput.MouseInputX() * sensY * Multiplier * Time.deltaTime;
            _yRotation += PlayerInput.MouseInputY() * sensX * Multiplier * Time.deltaTime;

            _xRotation = Mathf.Clamp(_xRotation, -85f, 85f);
            cam.rotation = Quaternion.Euler(_xRotation, _yRotation, 0f);

            PlayerInput.Instance.playerForward = cam.eulerAngles;
        }
    }
}