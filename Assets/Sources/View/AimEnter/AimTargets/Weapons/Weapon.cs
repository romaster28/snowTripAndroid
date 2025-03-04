using UnityEngine;

namespace Sources.View.AimEnter.AimTargets.Weapons
{
    public class Weapon : Pickable
    {
        [SerializeField] private Transform _view;

        public Transform View => _view;
    }
}