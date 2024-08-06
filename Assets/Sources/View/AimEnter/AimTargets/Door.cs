using System;
using Sources.Core.AimEnter.Visitors;
using Sources.View.DoorOpeners;
using UnityEngine;

namespace Sources.View.AimEnter.AimTargets
{
    [RequireComponent(typeof(BaseDoorOpener))]
    public class Door : BaseAimTarget
    {
        public BaseDoorOpener Opener { get; private set; }
        
        public override void Accept(AimTargetEnterVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override void Accept(AimTargetExitVisitor visitor)
        {
            visitor.Visit(this);
        }

        private void Awake()
        {
            Opener = gameObject.GetComponent<BaseDoorOpener>();
        }
    }
}