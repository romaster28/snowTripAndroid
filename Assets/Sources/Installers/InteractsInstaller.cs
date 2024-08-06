using Sources.Core.Interact;
using Zenject;

namespace Sources.Installers
{
    public class InteractsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<InteractsRouter>().AsSingle();
        }
    }
}