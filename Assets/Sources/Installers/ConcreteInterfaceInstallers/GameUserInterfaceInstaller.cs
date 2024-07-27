using Sources.UserInterface;
using Sources.UserInterface.ConcreteRouters;
using Sources.UserInterface.ScreenRouters;
using UnityEngine;

namespace Sources.Installers.ConcreteInterfaceInstallers
{
    public class GameUserInterfaceInstaller : BaseUserInterfaceInstaller<GameRouter>
    {
        protected override IScreenRouter[] Routers { get; } = 
        {
            new CharacterControlRouter(), 
            new CarControlRouter() 
        };

        protected override void InstallAdditionalBindings()
        {
            Container.Bind<ElementEnterShower>().AsSingle();
        }
    }
}