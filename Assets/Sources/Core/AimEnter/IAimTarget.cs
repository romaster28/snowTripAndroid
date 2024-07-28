using Sources.Core.AimEnter.Visitors;

namespace Sources.Core.AimEnter
{
    public interface IAimTarget
    {
        void Accept(AimTargetEnterVisitor visitor);
        
        void Accept(AimTargetExitVisitor visitor);
    }
}