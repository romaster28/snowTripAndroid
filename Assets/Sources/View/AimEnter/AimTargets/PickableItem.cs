using System;
using Sources.Core.AimEnter;
using Sources.Core.AimEnter.Visitors;
using UnityEngine;

namespace Sources.View.AimEnter.AimTargets
{
    [RequireComponent(typeof(Rigidbody))]
    public class PickableItem : DefaultAimTarget
    {
        public Rigidbody RigidBody { get; private set; }

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
            RigidBody = GetComponent<Rigidbody>();
        }
    }
}