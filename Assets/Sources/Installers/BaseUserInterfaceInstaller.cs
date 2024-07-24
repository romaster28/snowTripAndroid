using Sources.UserInterface;
using UnityEngine;
using Zenject;

namespace Sources.Installers
{
    public abstract class BaseUserInterfaceInstaller<TRouter> : MonoInstaller where TRouter : BaseRouter
    {
        [SerializeField] private ScreensFacade _screens;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<TRouter>().AsSingle();

            Container.Bind<ScreensFacade>().FromInstance(_screens).WhenInjectedInto<TRouter>();
        }
    }
}