using System;
using System.Collections;
using UnityEngine;

namespace Sources.View.AimEnter
{
    public class AimEnterListener : MonoBehaviour
    {
        [Min(0)] [SerializeField] private float _maxDistance = 10;

        [Min(0)] [SerializeField] private float _checkDelay = .2f;

        [SerializeField] private LayerMask _mask;

        public event Action<AimTarget> OnEnter; 

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;

            Gizmos.DrawLine(transform.position, transform.position + transform.forward * _maxDistance);
        }

        private void Check()
        {
            Vector3 origin = transform.position;

            if (!Physics.Linecast(origin, origin + transform.forward * _maxDistance, out RaycastHit hit, _mask)) 
                return;

            if (hit.collider.TryGetComponent(out AimTarget target)) 
                OnEnter?.Invoke(target);
        }

        private void Start()
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