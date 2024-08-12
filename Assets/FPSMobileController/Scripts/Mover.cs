using System;
using Rewired;
using UnityEngine;

namespace FPSMobileController.Scripts
{
    [RequireComponent(typeof(CharacterController))]
    public class Mover : MonoBehaviour
    {
        [Min(0)] [SerializeField] private float _speed = 3;

        [SerializeField] private Transform _camera;
        
        private CharacterController _characterController;

        private Vector3 _current;

        public void MoveToDirection(Vector3 direction)
        {
            // _characterController.SimpleMove(transform.TransformDirection(direction) * (_speed * Time.fixedDeltaTime));
        }

        private void OnMoveReceivedX(InputActionEventData data)
        {
            _current.x = data.GetAxis();
        }

        private void OnMoveReceivedY(InputActionEventData data)
        {
            _current.z = data.GetAxis();
        }

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void OnEnable()
        {
            Player player = ReInput.players.GetPlayer(0);

            if (player == null)
                return;

            player.AddInputEventDelegate(OnMoveReceivedX, UpdateLoopType.Update, InputActionEventType.AxisActiveOrJustInactive, "Horizontal");
            
            player.AddInputEventDelegate(OnMoveReceivedY, UpdateLoopType.Update, InputActionEventType.AxisActiveOrJustInactive, "Vertical");
        }

        private void FixedUpdate()
        {
            _characterController.SimpleMove(_camera.TransformDirection(_current) * (_speed * Time.fixedDeltaTime));
        }

        private void OnDisable()
        {
            Player player = ReInput.players.GetPlayer(0);
            
            player.RemoveInputEventDelegate(OnMoveReceivedX, UpdateLoopType.Update, InputActionEventType.AxisActiveOrJustInactive, "Horizontal");
            
            player.RemoveInputEventDelegate(OnMoveReceivedY, UpdateLoopType.Update, InputActionEventType.AxisActiveOrJustInactive, "Vertical");
        }
    }
}