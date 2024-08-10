using System.Collections;
using Sources.Core.Car.Fuel;
using Sources.Core.ItemTake;
using Sources.Data.Place;
using Sources.Misc;
using Sources.Signals.Game;
using Sources.UserInterface.ConcreteScreens.Game;
using Sources.UserInterface.Elements.Common;
using Sources.View.AimEnter.AimTargets;
using UnityEngine;
using Zenject;

namespace Sources.UserInterface.ElementRouters
{
    public class GasTankFillRouter : IElementRouter
    {
        [Inject] private readonly ScreensFacade _screens;

        [Inject] private readonly IFuelTank _fuelTank;

        [Inject] private readonly IItemsTaker _taker;

        [Inject] private readonly WorldUiTargetFollower _worldUiTargetFollower;

        [Inject] private readonly FillGasConfig _config;
        
        [Inject] private readonly SignalBus _signalBus;

        [Inject] private readonly AsyncProcessor _asyncProcessor;

        private Camera _camera;

        private GasTank _enteredGas;
        
        private Coroutine _aimProcessing;

        private Coroutine _filling;
        
        private CharacterControlScreen Screen => _screens.Get<CharacterControlScreen>();

        private void OnTargetEnter(AimTargetEnterSignal signal)
        {
            if (signal.Target is not GasTank gasTank)
                return;

            _enteredGas = gasTank;
            
            _aimProcessing = _asyncProcessor.StartCoroutine(ProcessingOnAimEnter());
            
            Screen.TankFillPanel.gameObject.SetActive(true);
            
            Screen.TankFillPanel.SetFillActive(_taker.Current is GasolineCanister);
        }
        
        private void OnTargetExit(AimTargetExitSignal signal)
        {
            if (signal.Target is not GasTank || _aimProcessing == null)
                return;
            
            _asyncProcessor.StopCoroutine(_aimProcessing);
            
            Screen.TankFillPanel.gameObject.SetActive(false);
        }

        private void UpdateViewInfo()
        {
            Screen.TankFillPanel.UpdateCapacity(_fuelTank.Amount, _fuelTank.Capacity);
        }

        private void StartFilling()
        {
            StopFilling();
            
            _filling = _asyncProcessor.StartCoroutine(Filling());
        }

        private void StopFilling()
        {
            if (_filling == null)
                return;
            
            _asyncProcessor.StopCoroutine(_filling);
        }

        public void Initialize()
        {
            Screen.TankFillPanel.gameObject.SetActive(false);

            UpdateViewInfo();

            _fuelTank.Changed += UpdateViewInfo;
            
            _signalBus.Subscribe<AimTargetEnterSignal>(OnTargetEnter);
            
            _signalBus.Subscribe<AimTargetExitSignal>(OnTargetExit);

            Screen.TankFillPanel.OnFillDown += StartFilling;

            Screen.TankFillPanel.OnFillUp += StopFilling;
        }

        private IEnumerator Filling()
        {
            var waitStepDelay = new WaitForSeconds(_config.StepDelay);
            
            while (true)
            {
                _fuelTank.Fill(_config.AmountPerStep);
                
                yield return waitStepDelay;
            }
        }

        private IEnumerator ProcessingOnAimEnter()
        {
            while (true)
            {
                _worldUiTargetFollower.FollowToActiveCamera(Screen.TankFillPanel.RectTransform, _enteredGas.transform);
                
                yield return null;
            }
        }
    }
}