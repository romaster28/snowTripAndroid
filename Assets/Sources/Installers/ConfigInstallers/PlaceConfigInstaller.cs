using Sources.Data.Place;
using UnityEngine;
using Zenject;

namespace Sources.Installers.ConfigInstallers
{
    [CreateAssetMenu(fileName = "New Place Config Installer", menuName = "Game/Configs/Place", order = 0)]
    public class PlaceConfigInstaller : ScriptableObjectInstaller<PlaceConfigInstaller>
    {
        [SerializeField] private PlaceInterfaceConfig _interface;

        [SerializeField] private ItemTakeConfig _itemTake;

        [SerializeField] private FillGasConfig _fillGas;

        [SerializeField] private SprintConfig _sprint;

        [SerializeField] private ColdConfig _cold;
        
        public override void InstallBindings()
        {
            Container.BindInstances(_interface, _itemTake, _fillGas, _sprint, _cold);
        }
    }
}