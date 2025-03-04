using Sources.Core.Shoot;
using UnityEngine;
using Zenject;

namespace Sources.Installers
{
    public class ShootInstaller : MonoInstaller
    {
        [SerializeField] private Transform _head;

        [SerializeField] private Transform _bulletsParent;
        
        public override void InstallBindings()
        {
            Container.Bind<BulletProcessor>().AsSingle();
            
            Container.Bind<Shooter>().AsSingle().WithArguments(_head, _bulletsParent);

            Container.Bind<WeaponProcessor>().WhenInjectedInto<ShootRouter>();
            
            Container.BindInterfacesAndSelfTo<ShootRouter>().AsSingle();
        }
    }
}