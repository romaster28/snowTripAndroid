using Sources.Core.Car.ConcreteCars;
using Sources.Core.Character;
using Sources.Signals.Game;
using Sources.Signals.Game.Interface;
using Sources.View;
using Zenject;

namespace Sources.Core.Car
{
    public class CarRouter : IInitializable
    {
        [Inject] private readonly SignalBus _signalBus;

        [Inject] private readonly ICar _car;

        [Inject] private readonly ICharacter _character;

        private LeavePointDetector _leavePointDetector;

        public CarRouter(LeavePointDetector leavePointDetector)
        {
            _leavePointDetector = leavePointDetector;
        }

        private void OnEnterCarClicked()
        {
            _car.Activate();
            
            _character.Hide();
            
            _signalBus.Fire<CharacterEnteredCarSignal>();
        }

        private void OnLeaveCarClicked()
        {
            _car.DeActivate();
            
            _character.ShowAtPosition(_leavePointDetector.GetFirstFreePosition());
            
            _signalBus.Fire<CharacterLeftCarSignal>();
        }
        
        public void Initialize()
        {
            _signalBus.Subscribe<EnterCarClickedSignal>(OnEnterCarClicked);
            
            _signalBus.Subscribe<LeaveCarClickedSignal>(OnLeaveCarClicked);
        }
    }
}