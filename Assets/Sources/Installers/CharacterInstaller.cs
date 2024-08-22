using FPSMobileController.Scripts;
using Sources.Core.Character;
using Sources.Core.Character.ConcreteCharacters;
using Sources.Core.Die;
using Sources.Core.Temperature;
using UnityEngine;
using Zenject;

namespace Sources.Installers
{
    public class CharacterInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _character;

        [SerializeField] private Camera _camera;

        [SerializeField] private Collider _collider;

        [SerializeField] private Mover _mover;

        public override void InstallBindings()
        {
            Container.Bind<ICharacter>().To<FpsMobileCharacter>().AsSingle()
                .WithArguments(_character, _camera, _collider, _mover);

            Container.Bind<Sprint>().AsSingle();

            Container.BindInterfacesAndSelfTo<Cold>().AsSingle();

            Container.BindInterfacesAndSelfTo<DieSender>().AsSingle();

            Container.Bind<Death>().WhenInjectedInto<DieSender>();
        }
    }
}