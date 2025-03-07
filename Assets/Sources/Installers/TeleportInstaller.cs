using Sources.Core.Menu;
using Sources.Core.Teleport;
using Sources.Data.Menu;
using UnityEngine;
using Zenject;

namespace Sources.Installers
{
    public class TeleportInstaller : MonoInstaller
    {
        [SerializeField] private TeleportConfig _config;
        
        public override void InstallBindings()
        {
            Container.BindInstances(_config);

            Container.Bind<ITeleportator>().To<Teleportator>().AsSingle();
        }
    }
}