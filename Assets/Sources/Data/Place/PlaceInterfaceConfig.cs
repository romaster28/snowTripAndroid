using System;
using UnityEngine;

namespace Sources.Data.Place
{
    [Serializable]
    public class PlaceInterfaceConfig
    {
        [SerializeField] private float _disappearInteractButtonsDuration = 3;

        public float DisappearInteractButtonsDuration => _disappearInteractButtonsDuration;
    }
}