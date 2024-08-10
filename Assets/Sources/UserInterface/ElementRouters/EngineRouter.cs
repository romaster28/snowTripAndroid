using Sources.Core.Car.Engine;
using Sources.UserInterface.ConcreteScreens.Game;
using Zenject;

namespace Sources.UserInterface.ElementRouters
{
    public class EngineRouter : IElementRouter
    {
        [Inject] private readonly ScreensFacade _screens;

        [Inject] private readonly IEngine _engine;

        private CarControlScreen Screen => _screens.Get<CarControlScreen>();

        private void UpdateView()
        {
            Screen.SetStartEngineActive(!_engine.IsRunning);
            
            Screen.SetStopEngineActive(_engine.IsRunning);
        }
        
        public void Initialize()
        {
            UpdateView();

            Screen.OnStartEngineClicked += _engine.Start;

            Screen.OnStopEngineClicked += _engine.Stop;

            _engine.Changed += UpdateView;
        }
    }
}