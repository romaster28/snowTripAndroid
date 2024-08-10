using System.Linq;
using Sources.UserInterface;
using UnityEngine;
using Zenject;

namespace Sources.Installers
{
    public abstract class BaseUserInterfaceInstaller<TRouter> : MonoInstaller where TRouter : BaseRouter
    {
        [SerializeField] private ScreensFacade _screens;
        
        protected abstract IElementRouter[] Routers { get; }

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<TRouter>().AsSingle();

            Container.Bind<ScreensFacade>().FromInstance(_screens).AsSingle();

            Container.Bind<IElementRouter[]>().FromInstance(Routers).WhenInjectedInto<TRouter>();

            InstallAdditionalBindings();
            
            foreach (IElementRouter router in Routers)
            {
                Container.QueueForInject(router);
            }
        }

        protected virtual void InstallAdditionalBindings()
        {
            
        }
    }
}