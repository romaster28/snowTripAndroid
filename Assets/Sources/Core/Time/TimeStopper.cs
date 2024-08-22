using Sources.Signals.Game;
using Zenject;

namespace Sources.Core.Time
{
    public class TimeStopper : IInitializable
    {
        [Inject] private readonly SignalBus _signalBus;

        [Inject] private readonly ITimeChanger _timeChanger;

        private void OnDead(PlayerDeadSignal _)
        {
            _timeChanger.Stop();
        }

        public void Initialize()
        {
            _signalBus.Subscribe<PlayerDeadSignal>(OnDead);
            
            _timeChanger.Start();
        }
    }
}