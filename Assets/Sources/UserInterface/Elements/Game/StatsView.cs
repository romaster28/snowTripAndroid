using System;
using System.Collections.Generic;
using DG.Tweening;
using Sources.Core.Stats;
using Sources.Core.Stats.ConcreteStats;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.UserInterface.Elements.Game
{
    [Serializable]
    public class StatsView
    {
        [SerializeField] private Slider _health;

        [SerializeField] private Slider _stamina;

        [SerializeField] private Slider _cold;

        private const float Duration = 1.5f;

        private Dictionary<Type, Slider> Registered => new()
        {
            { typeof(HealthStat), _health },
            { typeof(StaminaStat), _stamina },
            { typeof(ColdStat), _cold },
        };

        public void Update<T>(float amount01) where T : BaseStat => Registered[typeof(T)].value = amount01;

        public void Update(IReadOnlyBaseStat baseStat)
        {
            Slider target = Registered[baseStat.GetType()];

            target.DOKill();
            
            target.DOValue(baseStat.Amount01, Duration);
        }
    }
}