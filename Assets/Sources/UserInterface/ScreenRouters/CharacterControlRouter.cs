using Sources.Signals.Game;
using Sources.Signals.Game.Interface;
using Sources.UserInterface.ConcreteScreens.Game;
using Zenject;

namespace Sources.UserInterface.ScreenRouters
{
    public class CharacterControlRouter : IScreenRouter
    {
        [Inject] private readonly SignalBus _signalBus;

        [Inject] private readonly ScreensFacade _screens;

        [Inject] private readonly ElementEnterShower _shower;

        private CharacterControlScreen Screen => _screens.Get<CharacterControlScreen>();
        
        private void OnCarDoorEnterAim(CarDoorAimEnterSignal _)
        {
            Screen.SetEnterCarActive(true);
        }

        private void OnCarDoorExitAim(CarDoorAimExitSignal _)
        {
            Screen.SetEnterCarActive(false);
        }

        public void Initialize()
        {
            _signalBus.Subscribe<CarDoorAimEnterSignal>(OnCarDoorEnterAim);
            
            _signalBus.Subscribe<CarDoorAimExitSignal>(OnCarDoorExitAim);
            
            _signalBus.Subscribe(delegate(CharacterEnteredCarSignal _)
            {
                Screen.SetEnterCarActive(false);
                
                Screen.Close();
            });
            
            _signalBus.Subscribe(delegate(CharacterLeftCarSignal _)
            {
                Screen.Open();
            });
            
            Screen.SetEnterCarActive(false);
            
            Screen.OnEnterCarClicked += delegate
            {
                _signalBus.Fire<EnterCarClickedSignal>();
            };
        }
    }
}