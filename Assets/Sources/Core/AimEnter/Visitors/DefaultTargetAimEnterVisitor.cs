using Sources.View.AimEnter.AimTargets;
using UnityEngine;

namespace Sources.Core.AimEnter.Visitors
{
    public class DefaultTargetAimEnterVisitor : TargetAimEnterVisitor
    {
        public override void Visit(DoorCarAimTarget doorCar)
        {
            Debug.Log("Enter car");
        }
    }
}