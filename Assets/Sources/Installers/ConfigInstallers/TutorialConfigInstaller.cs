using Sources.Data;
using Sources.Data.Place;
using UnityEngine;
using Zenject;

namespace Sources.Installers.ConfigInstallers
{
    [CreateAssetMenu(fileName = "TutorialConfigInstaller", menuName = "Installers/TutorialConfigInstaller")]
    public class TutorialConfigInstaller : ScriptableObjectInstaller<TutorialConfigInstaller>
    {
        [SerializeField] private DialogsConfig _dialogs;
        
        public override void InstallBindings()
        {
            Container.BindInstances(_dialogs);
        }
    }
}