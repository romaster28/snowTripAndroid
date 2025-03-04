using Sources.UserInterface;
using Sources.UserInterface.ConcreteRouters;

namespace Sources.Installers.ConcreteInterfaceInstallers
{
    public class LobbyUserInterfaceInstaller : BaseUserInterfaceInstaller<LobbyRouter>
    {
        protected override IElementRouter[] Routers => new IElementRouter[]
        {

        };
    }
}