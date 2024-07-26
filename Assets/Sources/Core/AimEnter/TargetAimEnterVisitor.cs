using Sources.View.AimEnter.AimTargets;

namespace Sources.Core.AimEnter
{
    public abstract class TargetAimEnterVisitor
    {
        public abstract void Visit(DoorCarAimTarget doorCar);
    }
}