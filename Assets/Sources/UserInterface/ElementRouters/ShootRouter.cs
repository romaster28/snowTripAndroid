using System.Collections;
using Sources.Core.Shoot;
using Sources.Misc;
using Sources.Signals.Game;
using Sources.UserInterface.ConcreteScreens.Game;
using UnityEngine;
using Zenject;

namespace Sources.UserInterface.ElementRouters
{
    public class ShootRouter : IElementRouter
    {
        [Inject] private readonly ScreensFacade _screens;

        [Inject] private readonly AsyncProcessor _asyncProcessor;

        [Inject] private readonly SignalBus _signalBus;
        
        private Coroutine _firing;
        
        private CharacterControlScreen ControlScreen => _screens.Get<CharacterControlScreen>();

        private void FireOnDown()
        {
            
        }

        private void FireOnUp()
        {
            _signalBus.Fire<FireClickedSignal>();
        }

        public void Initialize()
        {
            ControlScreen.Fire.OnDown += FireOnDown;
            
            ControlScreen.Fire.OnUp += FireOnUp;
        }
    }
}