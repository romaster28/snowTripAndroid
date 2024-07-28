using Sources.Core.ItemTake;
using Sources.View.ItemTakers;
using UnityEngine;
using Zenject;

namespace Sources.Installers
{
    public class ItemTakeInstaller : MonoInstaller
    {
        [SerializeField] private DefaultItemsTaker _itemsTaker;
        
        public override void InstallBindings()
        {
            Container.Bind<IItemsTaker>().FromInstance(_itemsTaker).AsSingle();

            Container.BindInterfacesAndSelfTo<ItemTakeRouter>().AsSingle();
        }
    }
}