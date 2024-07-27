﻿using Sources.Signals.Game;
using Sources.View.AimEnter.AimTargets;
using Zenject;

namespace Sources.Core.AimEnter.Visitors
{
    public class DefaultTargetAimEnterVisitor : TargetAimEnterVisitor
    {
        [Inject] private readonly SignalBus _signalBus;
        
        public override void Visit(DoorCarAimTarget doorCar)
        {
            _signalBus.Fire<CarDoorAimEnterSignal>();
        }
    }
}