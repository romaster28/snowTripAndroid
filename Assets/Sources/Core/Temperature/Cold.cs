using System.Collections;
using Sources.Core.Stats;
using Sources.Core.Stats.ConcreteStats;
using Sources.Data.Place;
using Sources.Misc;
using UnityEngine;
using Zenject;

namespace Sources.Core.Temperature
{
    public class Cold : IInitializable
    {
        [Inject] private readonly ColdConfig _config;

        [Inject] private readonly StatsGetter _stats;

        [Inject] private readonly AsyncProcessor _asyncProcessor;
        
        private Coroutine _freezing;

        private Coroutine _healing;
        
        public void Activate()
        {
            _freezing = _asyncProcessor.StartCoroutine(Freezing());
            
            if (_healing != null)
                _asyncProcessor.StopCoroutine(_healing);
        }

        public void DeActivate()
        {
            if (_freezing != null)
                _asyncProcessor.StopCoroutine(_freezing);

            _healing = _asyncProcessor.StartCoroutine(Healing());
        }

        private IEnumerator Freezing()
        {
            var waitFreezeStep = new WaitForSeconds(_config.AddDelay);
            
            while (!_stats.Get<ColdStat>().IsFull)
            {
                _stats.Add<ColdStat>(_config.AddValue);
                
                yield return waitFreezeStep;
            }
        }

        private IEnumerator Healing()
        {
            var waitHeal = new WaitForSeconds(_config.HealDelay);

            while (!_stats.Get<ColdStat>().IsEmpty)
            {
                if (!_stats.TryTake<ColdStat>(_config.HealValue))
                    _stats.TryTake<ColdStat>(_stats.Get<ColdStat>().Value);

                yield return waitHeal;
            }
        }

        public void Initialize()
        {
            Activate();
        }
    }
}