using Sources.Core.AimEnter;
using UnityEngine;

namespace Sources.View.AimEnter
{
    [RequireComponent(typeof(Collider))]
    public abstract class AimTarget : MonoBehaviour
    {
        public abstract void Accept(TargetAimEnterVisitor visitor);
    }
}