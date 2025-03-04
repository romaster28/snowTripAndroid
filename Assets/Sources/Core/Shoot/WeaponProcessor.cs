using System.Collections;
using System.Threading.Tasks;
using Sources.Core.Character;
using Sources.Misc;
using Sources.View.AimEnter.AimTargets.Weapons;
using UnityEngine;
using Zenject;

namespace Sources.Core.Shoot
{
    public class WeaponProcessor
    {
        [Inject] private readonly ICharacter _character;

        [Inject] private readonly AsyncProcessor _asyncProcessor;

        [Inject] private readonly Shooter _shooter;

        private Coroutine _applyingRotation;
        
        private Quaternion _cacheLocal;

        private const float ApplyingRotationTime = 1;
        
        public void OnWeaponTaken(Weapon weapon)
        {
            _cacheLocal = weapon.View.localRotation;

            _applyingRotation = _asyncProcessor.StartCoroutine(ApplyingTargetRotation(weapon));
        }

        public void OnWeaponDropped(Weapon weapon)
        {
            if (_applyingRotation != null)
                _asyncProcessor.StopCoroutine(_applyingRotation);
            
            weapon.View.localRotation = _cacheLocal;
        }
        
        public void OnWeaponFireClicked()
        {
            _shooter.Shoot();
        }

        private IEnumerator ApplyingTargetRotation(Weapon weapon)
        {
            float currentTime = 0;

            while (currentTime < ApplyingRotationTime)
            {
                currentTime += UnityEngine.Time.deltaTime;
                
                weapon.View.rotation = _character.Camera.transform.rotation;
                
                yield return null;
            }
        }
    }
}