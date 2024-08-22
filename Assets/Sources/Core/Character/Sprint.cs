using System.Collections;
using Sources.Core.Stats;
using Sources.Core.Stats.ConcreteStats;
using Sources.Data.Place;
using Sources.Misc;
using UnityEngine;
using Zenject;

namespace Sources.Core.Character
{
    public class Sprint
    {
        [Inject] private readonly AsyncProcessor _asyncProcessor;

        [Inject] private readonly SprintConfig _config;

        [Inject] private readonly StatsGetter _stats;

        [Inject] private readonly ICharacter _character;

        private Coroutine _active;

        private Coroutine _heal;

        public bool IsActive => _active != null;
        
        public void Activate()
        {
            if (IsActive)
                return;

            _active = _asyncProcessor.StartCoroutine(ActiveSprint());
            
            if (_heal != null)
                _asyncProcessor.StopCoroutine(_heal);
            
            _character.SetSprintActive(true);
        }

        public void DeActivate()
        {
            if (!IsActive)
                return;
            
            _asyncProcessor.StopCoroutine(_active);

            _active = null;

            _heal = _asyncProcessor.StartCoroutine(HealSprint());
            
            _character.SetSprintActive(false);
        }

        private IEnumerator ActiveSprint()
        {
            var waitTake = new WaitForSeconds(_config.TakeDelay);
            
            while (true)
            {
                yield return new WaitUntil(() => _character.IsMoving);
                
                _stats.TryTake<StaminaStat>(_config.TakeAmount);
                
                yield return waitTake;
            }
        }

        private IEnumerator HealSprint()
        {
            var waitHeal = new WaitForSeconds(_config.HealDelay);

            while (!_stats.Get<StaminaStat>().IsFull)
            {
                _stats.Add<StaminaStat>(_config.HealAmount);
                
                yield return waitHeal;
            }
        }
    }
}