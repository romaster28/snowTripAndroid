using Sources.UserInterface;
using Sources.UserInterface.ScreenRouters;
using UnityEngine;
using Zenject;

namespace Sources.Installers
{
    public abstract class BaseUserInterfaceInstaller<TRouter> : MonoInstaller where TRouter : BaseRouter
    {
        [SerializeField] private ScreensFacade _screens;
        
        protected abstract IScreenRouter[] Routers { get; }

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<TRouter>().AsSingle();

            Container.Bind<ScreensFacade>().FromInstance(_screens).WhenInjectedInto<TRouter>();

            Container.Bind<IScreenRouter[]>().FromInstance(Routers).WhenInjectedInto<TRouter>();

            InstallAdditionalBindings();
            
            foreach (IScreenRouter router in Routers)
            {
                Container.Bind<ScreensFacade>().FromInstance(_screens).WhenInjectedIntoInstance(router);
                
                Container.Inject(router);
            }
        }

        protected virtual void InstallAdditionalBindings()
        {
            
        }
    }
}