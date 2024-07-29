using Sources.Core.ItemsPlace;
using Zenject;

namespace Sources.Installers
{
    public class ItemsPlaceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ItemsPlacer>().AsSingle();

            Container.BindInterfacesAndSelfTo<ItemsPlaceRouter>().AsSingle();
        }
    }
}