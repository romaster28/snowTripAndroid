using Sources.Core.Car;
using Sources.Core.Car.ConcreteCars;
using Sources.View;
using UnityEngine;
using Zenject;

namespace Sources.Installers
{
    public class PlaceInstaller : MonoInstaller
    {
        [SerializeField] private LeavePointDetector _leavePointDetector;
        
        public override void InstallBindings()
        {
            Container.Bind<ICar>().To<RealisticControllerCar>().AsSingle();

            Container.BindInterfacesAndSelfTo<CarRouter>().AsSingle().WithArguments(_leavePointDetector);
        }
    }
}