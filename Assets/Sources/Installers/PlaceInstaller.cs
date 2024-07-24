using Sources.Core.Car;
using Sources.Core.Car.ConcreteCars;
using Zenject;

namespace Sources.Installers
{
    public class PlaceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ICar>().To<RealisticControllerCar>().AsSingle();
        }
    }
}