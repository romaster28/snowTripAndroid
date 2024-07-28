using Sources.Core.AimEnter;
using Sources.Core.AimEnter.Visitors;

namespace Sources.View.AimEnter.AimTargets
{
    public class DoorCarDefaultAimTarget : DefaultAimTarget
    {
        public override void Accept(AimTargetEnterVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override void Accept(AimTargetExitVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}