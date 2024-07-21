using System;
using UnityEngine;

namespace FPSMobileController.Scripts
{
    public class CharacterRouter : MonoBehaviour
    {
        [SerializeField] private Mover _mover;

        [SerializeField] private UltimateJoystick _joystick;

        private void FixedUpdate()
        {
            _mover.MoveToDirection(new Vector3(_joystick.HorizontalAxis, 0, _joystick.VerticalAxis));
        }
    }
}