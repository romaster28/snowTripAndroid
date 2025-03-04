using System;
using System.Collections;
using System.Collections.Generic;
using Sources.Data.Place;
using Sources.Misc;
using Sources.View.Weapon;
using UnityEngine;
using Zenject;

namespace Sources.Core.Shoot
{
    public class BulletProcessor
    {
        [Inject] private readonly ShootConfig _config;

        [Inject] private readonly AsyncProcessor _asyncProcessor;

        private readonly Dictionary<BulletView, Coroutine> _movingCoroutines = new();

        public void StartProcess(BulletView bullet, Action<BulletView> destroy)
        {
            Coroutine moving = _asyncProcessor.StartCoroutine(MovingBullet(bullet));

            _movingCoroutines.Add(bullet, moving);

            _asyncProcessor.StartCoroutine(WaitingDestroy(bullet, destroy));
        }

        private void StopProcess(BulletView bullet)
        {
            _asyncProcessor.StopCoroutine(_movingCoroutines[bullet]);

            _movingCoroutines.Remove(bullet);
        }

        private IEnumerator WaitingDestroy(BulletView bullet, Action<BulletView> destroy)
        {
            yield return new WaitForSeconds(_config.LifeExpectancy);

            StopProcess(bullet);

            destroy.Invoke(bullet);
        }

        private IEnumerator MovingBullet(BulletView bullet)
        {
            var waitFixed = new WaitForFixedUpdate();

            while (true)
            {
                bullet.RigidBody.MovePosition(bullet.RigidBody.position +
                                              bullet.transform.forward *
                                              (_config.BulletSpeed * UnityEngine.Time.fixedDeltaTime));

                yield return waitFixed;
            }
        }
    }
}