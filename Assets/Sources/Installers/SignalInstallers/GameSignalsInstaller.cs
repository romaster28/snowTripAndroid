using Sources.Signals.Game;
using Zenject;

namespace Sources.Installers.SignalInstallers
{
    public class GameSignalsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<CarAimEnterSignal>();
        }
    }
}