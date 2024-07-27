using Sources.Signals.Game;
using Sources.Signals.Game.Interface;
using Zenject;

namespace Sources.Installers.SignalInstallers
{
    public class GameSignalsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<CarDoorAimEnterSignal>();

            Container.DeclareSignal<CarDoorAimExitSignal>();

            Container.DeclareSignal<CharacterEnteredCarSignal>();

            Container.DeclareSignal<LeaveCarClickedSignal>();

            Container.DeclareSignal<CharacterLeftCarSignal>();
            
            DeclareInterfaceSignals();
        }

        private void DeclareInterfaceSignals()
        {
            Container.DeclareSignal<EnterCarClickedSignal>();
        }
    }
}