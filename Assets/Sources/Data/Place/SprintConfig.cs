using System;
using UnityEngine;

namespace Sources.Data.Place
{
    [Serializable]
    public class SprintConfig
    {
        [Min(0)] [SerializeField] private int _takeAmount = 1;

        [Min(0)] [SerializeField] private float _takeDelay = .2f;

        [Min(0)] [SerializeField] private int _healAmount = 1;

        [Min(0)] [SerializeField] private float _healDelay = .5f;

        public int TakeAmount => _takeAmount;

        public float TakeDelay => _takeDelay;

        public int HealAmount => _healAmount;

        public float HealDelay => _healDelay;
    }
}