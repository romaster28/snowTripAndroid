using System;
using Sources.Data;
using Sources.Extensions;
using UnityEngine;

namespace Sources.View.DoorOpeners.ConcreteDoorOpeners
{
    public class ImmediatelyDoorOpener : BaseDoorOpener
    {
        [SerializeField] private Axis _axis;
        
        [SerializeField] private float _openAngle;

        [SerializeField] private float _closeAngle;

        [SerializeField] private Transform _target;

        private bool _isOpened;

        private Transform _correctTarget;
        
        public override bool IsOpened => _isOpened;
        
        protected override void DoOpen()
        {
            _isOpened = true;
            
            _correctTarget.SetLocalRotationAngle(_axis, _openAngle);
        }

        protected override void DoClose()
        {
            _isOpened = false;
            
            _correctTarget.SetLocalRotationAngle(_axis, _closeAngle);
        }

        private void Start()
        {
            _correctTarget = _target == null ? transform : _target;
        }
    }
}