using Sources.Core.AimEnter;
using Sources.Core.AimEnter.Visitors;
using Sources.View.AimEnter;
using UnityEngine;
using Zenject;

namespace Sources.Installers
{
    public class AimEnterInstaller : MonoInstaller
    {
        [SerializeField] private AimEnterListener _listener;
        
        public override void InstallBindings()
        {
            Container.Bind<TargetAimEnterVisitor>().To<DefaultTargetAimEnterVisitor>().WhenInjectedInto<AimEnterRouter>();

            Container.BindInterfacesAndSelfTo<AimEnterRouter>().AsSingle().WithArguments(_listener);
        }
    }
}