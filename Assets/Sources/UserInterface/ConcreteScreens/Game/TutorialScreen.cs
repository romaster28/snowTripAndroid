using System;
using Sources.UserInterface.Elements.Game;
using UnityEngine;

namespace Sources.UserInterface.ConcreteScreens.Game
{
    public class TutorialScreen : BaseScreen
    {
        [SerializeField] private DialogView _dialogView;

        [SerializeField] private TutorialStepPlacedView _wheelsView;

        [SerializeField] private TutorialStepPlacedView _fuelGasView;
        
        public TutorialStepPlacedView WheelsView => _wheelsView;

        public TutorialStepPlacedView FuelGasView => _fuelGasView;
        
        public DialogView DialogView => _dialogView;
    }
}