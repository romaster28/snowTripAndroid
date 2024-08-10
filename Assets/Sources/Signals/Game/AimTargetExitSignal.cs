using Sources.Core.AimEnter;

namespace Sources.Signals.Game
{
    public class AimTargetExitSignal
    {
        public IAimTarget Target { get; }

        public AimTargetExitSignal(IAimTarget target)
        {
            Target = target;
        }
    }
}