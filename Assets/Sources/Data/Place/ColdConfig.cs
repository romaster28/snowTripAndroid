using System;
using UnityEngine;

namespace Sources.Data.Place
{
    [Serializable]
    public class ColdConfig
    {
        [Min(0)] [SerializeField] private int _addValue;

        [Min(0)] [SerializeField] private float _addDelay = .5f;

        [Min(0)] [SerializeField] private int _healValue = 1;

        [Min(0)] [SerializeField] private float _healDelay = .5f;

        public int AddValue => _addValue;

        public float AddDelay => _addDelay;

        public int HealValue => _healValue;

        public float HealDelay => _healDelay;
    }
}