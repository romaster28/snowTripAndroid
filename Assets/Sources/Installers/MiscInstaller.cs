using Sources.Core.Time;
using Sources.Core.Time.ConcreteTimeChangers;
using Sources.Misc;
using Zenject;

namespace Sources.Installers
{
    public class MiscInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<AsyncProcessor>().FromNewComponentOnNewGameObject().AsSingle();

            Container.Bind<ITimeChanger>().To<DefaultTimeChanger>().AsSingle();

            Container.BindInterfacesAndSelfTo<TimeStopper>().AsSingle();
        }
    }
}