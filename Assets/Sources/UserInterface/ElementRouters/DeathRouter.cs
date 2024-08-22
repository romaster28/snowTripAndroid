using Sources.Core;
using Sources.Signals.Game;
using Sources.UserInterface.ConcreteScreens.Game;
using Zenject;

namespace Sources.UserInterface.ElementRouters
{
    public class DeathRouter : IElementRouter
    {
        [Inject] private readonly ScreensFacade _screens;

        [Inject] private readonly SignalBus _signalBus;

        [Inject] private readonly Place _place;
        
        private void OnDead(PlayerDeadSignal _)
        {
            _screens.Open<DeathScreen>();
        }

        public void Initialize()
        {
            _signalBus.Subscribe<PlayerDeadSignal>(OnDead);

            _screens.Get<DeathScreen>().OnMenuClicked += _place.GoMenu;

            _screens.Get<DeathScreen>().OnRestartClicked += _place.Restart;
        }
    }
}