using Sources.Core.Character;
using Sources.Core.Character.ConcreteCharacters;
using UnityEngine;
using Zenject;

namespace Sources.Installers
{
    public class CharacterInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _character;

        [SerializeField] private Camera _camera;

        public override void InstallBindings()
        {
            Container.Bind<ICharacter>().To<FpsMobileCharacter>().AsSingle().WithArguments(_character, _camera);
        }
    }
}