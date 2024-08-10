using Sources.Core.AimEnter;

namespace Sources.Signals.Game
{
    public class AimTargetEnterSignal
    {
        public IAimTarget Target { get; }

        public AimTargetEnterSignal(IAimTarget target)
        {
            Target = target;
        }
    }
}