using Sources.Core.AimEnter.Visitors;

namespace Sources.View.AimEnter.AimTargets
{
    public class GasTank : BaseAimTarget
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