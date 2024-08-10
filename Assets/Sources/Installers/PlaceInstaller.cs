using Sources.Core;
using Sources.Core.Car;
using Sources.Core.Car.ConcreteCars;
using Sources.Core.Car.Engine;
using Sources.Core.Car.Engine.ConcreteEngines;
using Sources.Core.Car.Fuel;
using Sources.Core.Car.Fuel.ConcreteFuelTanks;
using Sources.View;
using UnityEngine;
using Zenject;

namespace Sources.Installers
{
    public class PlaceInstaller : MonoInstaller
    {
        [SerializeField] private LeavePointDetector _leavePointDetector;

        [SerializeField] private Camera _insideCarCamera;
        
        public override void InstallBindings()
        {
            Container.Bind<ICar>().To<RealisticControllerCar>().AsSingle().WithArguments(_insideCarCamera);

            Container.Bind<IFuelTank>().To<RCCFuelTank>().AsSingle();

            Container.Bind<IEngine>().To<RCCEngine>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<CarRouter>().AsSingle().WithArguments(_leavePointDetector);

            Container.Bind<ActiveCamera>().AsSingle();
        }
    }
}