using Sources.Core.AimEnter;

namespace Sources.View.AimEnter.AimTargets
{
    public class DoorCarAimTarget : AimTarget
    {
        public override void Accept(TargetAimEnterVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}