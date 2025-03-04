using System;
using Sources.View.Weapon;
using UnityEngine;

namespace Sources.Data.Place
{
    [Serializable]
    public class ShootConfig
    {
        [Min(0)] [SerializeField] private float _bulletSpeed = 3;

        [SerializeField] private float _lifeExpectancy = 4;
        
        [SerializeField] private BulletView _bulletPrefab;

        public float BulletSpeed => _bulletSpeed;

        public BulletView BulletPrefab => _bulletPrefab;

        public float LifeExpectancy => _lifeExpectancy;
    }
}