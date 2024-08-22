using Sources.Core.Character;
using Sources.Signals.Game;
using Sources.Signals.Game.Interface;
using Sources.UserInterface.ConcreteScreens.Game;
using Zenject;

namespace Sources.UserInterface.ElementRouters
{
    public class CharacterControlRouter : IElementRouter
    {
        [Inject] private readonly SignalBus _signalBus;

        [Inject] private readonly ScreensFacade _screens;

        [Inject] private readonly Sprint _sprint;

        private CharacterControlScreen Screen => _screens.Get<CharacterControlScreen>();

        public void Initialize()
        {
            Screen.Sprint.OnDown += _sprint.Activate;

            Screen.Sprint.OnUp += _sprint.DeActivate;
            
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
            
            Screen.OnInteractClicked += delegate
            {
                _signalBus.Fire<InteractClickedSignal>();
            };
            
            Screen.OnPlaceClicked += delegate
            {
                _signalBus.Fire<PlaceClickedSignal>();
            };

            Screen.SetEnterCarActive(false);
            
            Screen.SetTakeItemActive(false);
            
            Screen.SetDropItemActive(false);
            
            Screen.SetPlaceActive(false);
            
            Screen.SetInteractActive(false);
        }
    }
}