using System;
using Sources.Core.AimEnter;
using Sources.Core.AimEnter.Visitors;
using Sources.Data;
using UnityEngine;

namespace Sources.View.AimEnter.AimTargets
{
    [RequireComponent(typeof(Rigidbody))]
    public class Pickable : BaseAimTarget
    {
        [SerializeField] private PickableKey _key;
        
        public Rigidbody RigidBody { get; private set; }

        public PickableKey Key => _key;

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