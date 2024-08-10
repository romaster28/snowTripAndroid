using System;
using UnityEngine;

namespace Sources.Data.Place
{
    [Serializable]
    public class FillGasConfig
    {
        [Min(0)] [SerializeField] private float _amountPerStep = 1;

        [Min(0)] [SerializeField] private float _stepDelay = .1f;

        public float AmountPerStep => _amountPerStep;

        public float StepDelay => _stepDelay;
    }
}