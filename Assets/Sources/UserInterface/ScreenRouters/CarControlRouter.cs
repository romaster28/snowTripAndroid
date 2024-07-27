using Sources.Signals.Game;
using Sources.Signals.Game.Interface;
using Sources.UserInterface.ConcreteScreens.Game;
using Zenject;

namespace Sources.UserInterface.ScreenRouters
{
    public class CarControlRouter : IScreenRouter
    {
        [Inject] private readonly ScreensFacade _screens;

        [Inject] private readonly SignalBus _signalBus;
        
        private CarControlScreen Screen => _screens.Get<CarControlScreen>();
        
        public void Initialize()
        {
            _signalBus.Subscribe(delegate(CharacterEnteredCarSignal _)
            {
                Screen.Open();
            });
            
            _signalBus.Subscribe(delegate(CharacterLeftCarSignal _)
            {
                Screen.Close();
            });
            
            Screen.OnLeaveClicked += delegate
            {
                _signalBus.Fire<LeaveCarClickedSignal>();
            };
        }
    }
}