using System;
using UnityEngine;

namespace Sources.Data.Menu
{
    [Serializable]
    public class TeleportConfig
    {
        [SerializeField] private float _duration;

        public float Duration => _duration;
    }
}