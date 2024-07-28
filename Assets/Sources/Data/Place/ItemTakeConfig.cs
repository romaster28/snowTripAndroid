using System;
using UnityEngine;

namespace Sources.Data.Place
{
    [Serializable]
    public class ItemTakeConfig
    {
        [Min(0)] [SerializeField] private float _force = 600;

        [Min(0)] [SerializeField] private float _damping = 6;

        public float Force => _force;

        public float Damping => _damping;
    }
}