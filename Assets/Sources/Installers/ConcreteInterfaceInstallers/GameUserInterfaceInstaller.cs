using Sources.UserInterface;
using Sources.UserInterface.ConcreteRouters;
using Sources.UserInterface.ElementRouters;
using Sources.UserInterface.Elements.Common;
using UnityEngine;

namespace Sources.Installers.ConcreteInterfaceInstallers
{
    public class GameUserInterfaceInstaller : BaseUserInterfaceInstaller<GameRouter>
    {
        protected override IElementRouter[] Routers { get; } = 
        {
            new CharacterControlRouter(), 
            new CarControlRouter(),
            new GasTankFillRouter(),
            new EngineRouter()
        };

        protected override void InstallAdditionalBindings()
        {
            Container.Bind<ElementEnterShower>().AsSingle();

            Container.Bind<WorldUiTargetFollower>().AsSingle();
        }
    }
}