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

            Container.DeclareSignal<CharacterEnteredCarSignal>();

            Container.DeclareSignal<LeaveCarClickedSignal>();

            Container.DeclareSignal<CharacterLeftCarSignal>();

            Container.DeclareSignal<TakeItemClickedSignal>();

            Container.DeclareSignal<DropItemClickedSignal>();

            Container.DeclareSignal<ItemTakenSignal>();

            Container.DeclareSignal<ItemDroppedSignal>();

            DeclareInterfaceSignals();
        }

        private void DeclareInterfaceSignals()
        {
            Container.DeclareSignal<EnterCarClickedSignal>();
        }
    }
}