using Sources.Data.Place;
using UnityEngine;
using Zenject;

namespace Sources.Installers
{
    [CreateAssetMenu(fileName = "New Place Config Installer", menuName = "Game/Configs/Place", order = 0)]
    public class PlaceConfigInstaller : ScriptableObjectInstaller<PlaceConfigInstaller>
    {
        [SerializeField] private PlaceInterfaceConfig _interface;
        
        public override void InstallBindings()
        {
            Container.BindInstances(_interface);
        }
    }
}