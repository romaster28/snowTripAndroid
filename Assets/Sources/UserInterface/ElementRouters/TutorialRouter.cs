using System.Collections.Generic;
using Sources.Core.Car.Fuel;
using Sources.Core.ItemsPlace;
using Sources.Data;
using Sources.Data.Place;
using Sources.Misc;
using Sources.UserInterface.ConcreteScreens.Game;
using Zenject;

namespace Sources.UserInterface.ElementRouters
{
    public class TutorialRouter : IElementRouter
    {
        [Inject] private readonly ScreensFacade _screens;

        [Inject] private readonly DialogsConfig _dialogs;

        [Inject] private readonly AsyncProcessor _asyncProcessor;

        [Inject] private readonly IFuelTank _fuelTank;

        [Inject] private readonly ItemsPlacer _placer;

        private TutorialScreen Screen => _screens.Get<TutorialScreen>();

        private Dictionary<PickableKey, int> _placed = new Dictionary<PickableKey, int>()
        {
            { PickableKey.Wheel, 0}
        };

        private void OnPlaced(PickableKey key)
        {
            _placed[key]++;
            
            UpdateProgress();
        }

        private void UpdateProgress()
        {
            Screen.FuelGasView.UpdateProgress((int)_fuelTank.Amount, (int)_fuelTank.Capacity);
            
            Screen.WheelsView.UpdateProgress(_placed[PickableKey.Wheel], 4);
        }

        public void Initialize()
        {
            Screen.DialogView.Show(_asyncProcessor, _dialogs.Start.Lines);

            _placer.Placed += OnPlaced;
            
            _fuelTank.Changed += UpdateProgress;

            UpdateProgress();
        }
    }
}