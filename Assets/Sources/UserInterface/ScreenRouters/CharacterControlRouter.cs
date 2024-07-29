using Sources.Signals.Game;
using Sources.Signals.Game.Interface;
using Sources.UserInterface.ConcreteScreens.Game;
using Sources.View.AimEnter;
using Sources.View.AimEnter.AimTargets;
using Zenject;

namespace Sources.UserInterface.ScreenRouters
{
    public class CharacterControlRouter : IScreenRouter
    {
        [Inject] private readonly SignalBus _signalBus;

        [Inject] private readonly ScreensFacade _screens;

        [Inject] private readonly ElementEnterShower _shower;

        private CharacterControlScreen Screen => _screens.Get<CharacterControlScreen>();

        public void Initialize()
        {
            _signalBus.Subscribe(delegate(CharacterEnteredCarSignal _)
            {
                Screen.SetEnterCarActive(false);
                
                Screen.Close();
            });
            
            _signalBus.Subscribe(delegate(CharacterLeftCarSignal _)
            {
                Screen.Open();
            });
            
            _signalBus.Subscribe(delegate(ItemTakenSignal _)
            {
                Screen.SetDropItemActive(true);
            });
            
            _signalBus.Subscribe(delegate(ItemDroppedSignal _)
            {
                Screen.SetDropItemActive(false);
            });

            _signalBus.Subscribe(delegate(ReadyToPlaceSignal _)
            {
                Screen.SetPlaceActive(true);
            });
            
            _signalBus.Subscribe(delegate(ReleaseToPlaceSignal _)
            {
                Screen.SetPlaceActive(false);
            });
            
            Screen.OnEnterCarClicked += delegate
            {
                _signalBus.Fire<EnterCarClickedSignal>();
            };
            
            Screen.OnTakeItemClicked += delegate
            {
                _signalBus.Fire<TakeItemClickedSignal>();
            };
            
            Screen.OnDropItemClicked += delegate
            {
                _signalBus.Fire<DropItemClickedSignal>();
            };
            
            Screen.OnPlaceClicked += delegate
            {
                _signalBus.Fire<PlaceClickedSignal>();
            };

            Screen.SetEnterCarActive(false);
            
            Screen.SetTakeItemActive(false);
            
            Screen.SetDropItemActive(false);
            
            Screen.SetPlaceActive(false);
        }
    }
}