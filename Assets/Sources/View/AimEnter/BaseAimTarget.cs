using Sources.Core.AimEnter;
using Sources.Core.AimEnter.Visitors;
using UnityEngine;

namespace Sources.View.AimEnter
{
    [RequireComponent(typeof(Collider))]
    public abstract class BaseAimTarget : MonoBehaviour, IAimTarget
    {
        public abstract void Accept(AimTargetEnterVisitor visitor);
        
        public abstract void Accept(AimTargetExitVisitor visitor);
    }
}