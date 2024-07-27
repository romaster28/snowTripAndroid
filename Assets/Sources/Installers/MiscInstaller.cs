using Sources.Misc;
using Zenject;

namespace Sources.Installers
{
    public class MiscInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<AsyncProcessor>().FromNewComponentOnNewGameObject().AsSingle();
        }
    }
}