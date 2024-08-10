using System;
using Rewired;
using UnityEngine;

namespace FPSMobileController.Scripts
{
    [RequireComponent(typeof(CharacterController))]
    public class Mover : MonoBehaviour
    {
        [Min(0)] [SerializeField] private float _speed = 3;

        private CharacterController _characterController;

        public void MoveToDirection(Vector3 direction)
        {
            _characterController.Move(transform.TransformDirection(direction) * (_speed * Time.deltaTime));
        }

        private void OnMoveReceivedX(InputActionEventData data) 
        {
            MoveToDirection(new Vector2(data.GetAxis(), 0f));
        }

        private void OnMoveReceivedY(InputActionEventData data) 
        {
            MoveToDirection(new Vector3(0, 0, data.GetAxis()));
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

            player.AddInputEventDelegate(OnMoveReceivedX, UpdateLoopType.Update, InputActionEventType.AxisActive, "Horizontal");
            
            player.AddInputEventDelegate(OnMoveReceivedY, UpdateLoopType.Update, InputActionEventType.AxisActive, "Vertical");
        }

        private void OnDisable()
        {
            Player player = ReInput.players.GetPlayer(0);
            
            player.RemoveInputEventDelegate(OnMoveReceivedX, UpdateLoopType.Update, InputActionEventType.AxisActive, "Horizontal");
            
            player.RemoveInputEventDelegate(OnMoveReceivedY, UpdateLoopType.Update, InputActionEventType.AxisActive, "Vertical");
        }
    }
}