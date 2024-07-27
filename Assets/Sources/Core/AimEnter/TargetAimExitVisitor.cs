using Sources.View.AimEnter.AimTargets;

namespace Sources.Core.AimEnter
{
    public abstract class TargetAimExitVisitor
    {
        public abstract void Visit(DoorCarAimTarget doorCar);
    }
}