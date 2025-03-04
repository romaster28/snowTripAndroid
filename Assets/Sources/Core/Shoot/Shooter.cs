using System;
using System.Collections;
using Sources.Data.Place;
using Sources.Misc;
using Sources.View.Weapon;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;
using Object = UnityEngine.Object;

namespace Sources.Core.Shoot
{
    public class Shooter
    {
        [Inject] private readonly ShootConfig _config;

        [Inject] private readonly BulletProcessor _bulletProcessor;
        
        private readonly Transform _head;

        private readonly Transform _bulletsParent;

        private readonly ObjectPool<BulletView> _bulletsPool;

        public Shooter(Transform head, Transform bulletsParent)
        {
            _head = head ? head : throw new ArgumentNullException(nameof(head));
            _bulletsParent = bulletsParent ? bulletsParent : throw new ArgumentNullException(nameof(bulletsParent));
            _bulletsPool = new ObjectPool<BulletView>(CreateFunc);
        }

        public void Shoot()
        {
            BulletView bullet = _bulletsPool.Get();

            bullet.transform.position = _head.transform.position;

            bullet.transform.rotation = _head.transform.rotation;
            
            _bulletProcessor.StartProcess(bullet, _bulletsPool.Release);
        }

        private BulletView CreateFunc() => Object.Instantiate(_config.BulletPrefab, _bulletsParent);
    }
}