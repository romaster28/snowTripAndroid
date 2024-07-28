using Sources.View.AimEnter.AimTargets;

namespace Sources.Core.AimEnter.Visitors
{
    public abstract class AimTargetEnterVisitor
    {
        public abstract void Visit(DoorCarDefaultAimTarget doorCarDefault);

        public abstract void Visit(PickableItem pickableItem);
    }
}