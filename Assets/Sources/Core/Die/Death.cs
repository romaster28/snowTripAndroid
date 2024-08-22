using Sources.Signals.Game;
using Zenject;

namespace Sources.Core.Die
{
    public class Death
    {
        [Inject] private readonly SignalBus _signalBus;

        public void Die()
        {
            _signalBus.Fire<PlayerDeadSignal>();
        }
    }
}