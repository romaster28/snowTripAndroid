using System;
using System.Collections;
using Sources.Core.AimEnter;
using UnityEngine;

namespace Sources.View.AimEnter
{
    public class DefaultAimEtnerListener : MonoBehaviour, IAimEnterListener
    {
        [Min(0)] [SerializeField] private float _maxDistance = 10;

        [Min(0)] [SerializeField] private float _checkDelay = .2f;

        [SerializeField] private LayerMask _mask;

        private DefaultAimTarget _last;
        
        public event Action<IAimTarget> OnEnter;

        public event Action<IAimTarget> OnExit;

        public IAimTarget NowEntered => _last;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;

            Gizmos.DrawLine(transform.position, transform.position + transform.forward * _maxDistance);
        }

        private void Check()
        {
            Vector3 origin = transform.position;

            if (!Physics.Linecast(origin, origin + transform.forward * _maxDistance, out RaycastHit hit, _mask))
            {
                TryExit();
                
                return;
            }

            if (!hit.collider.TryGetComponent(out DefaultAimTarget target))
            {
                TryExit();
                
                return;
            }

            if (_last == target)
                return;

            _last = target;
            
            OnEnter?.Invoke(target);
        }

        private void TryExit()
        {
            if (_last == null)
                return;

            OnExit?.Invoke(_last);
            
            _last = null;
        }

        private void OnEnable()
        {
            StartCoroutine(Checking());
        }

        private IEnumerator Checking()
        {
            var wait = new WaitForSeconds(_checkDelay);
            
            while (true)
            {
                Check();
                
                yield return wait;
            }
        }
    }
}