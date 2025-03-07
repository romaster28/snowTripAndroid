using Sources.Core.Menu;
using Zenject;

namespace Sources.Installers
{
    public class MenuInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind(typeof(IInitializable), typeof(MenuRouter)).To<MenuRouter>().AsSingle();
        }
    }
}