using Sources.Core.AimEnter;

namespace Sources.View.AimEnter.AimTargets
{
    public class CarAimTarget : AimTarget
    {
        public override void Accept(TargetAimEnterVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}