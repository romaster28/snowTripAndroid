using Sources.Core.AimEnter;
using Sources.Core.AimEnter.Visitors;
using Sources.Core.ItemsPlace.AimTargetVisitors;
using Sources.UserInterface.AimTargetVisitors;
using Sources.View.AimEnter;
using UnityEngine;
using Zenject;

namespace Sources.Installers
{
    public class AimEnterInstaller : MonoInstaller
    {
        [SerializeField] private BaseAimEnterListener _listener;

        public override void InstallBindings()
        {
            var enterVisitors = new AimTargetEnterVisitor[]
            {
                new InterfaceAimTargetEnterVisitor(),
                new ItemPlaceAimTargetEnterVisitor()
            };

            var exitVisitors = new AimTargetExitVisitor[]
            {
                new InterfaceAimTargetExitVisitor(),
                new ItemPlaceAimTargetExitVisitor()
            };

            Container.Bind<AimTargetEnterVisitor[]>().FromInstance(enterVisitors).WhenInjectedInto<AimEnterRouter>();

            Container.Bind<AimTargetExitVisitor[]>().FromInstance(exitVisitors).WhenInjectedInto<AimEnterRouter>();

            Container.Bind<IAimEnterListener>().FromInstance(_listener).AsSingle();

            Container.BindInterfacesAndSelfTo<AimEnterRouter>().AsSingle();

            foreach (AimTargetEnterVisitor enterVisitor in enterVisitors)
                Container.Inject(enterVisitor);

            foreach (AimTargetExitVisitor exitVisitor in exitVisitors)
                Container.Inject(exitVisitor);
        }
    }
}