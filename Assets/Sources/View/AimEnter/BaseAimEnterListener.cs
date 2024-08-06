using System;
using System.Collections;
using System.Collections.Generic;
using Sources.Core.AimEnter;
using UnityEngine;

namespace Sources.View.AimEnter
{
    public abstract class BaseAimEnterListener : MonoBehaviour, IAimEnterListener
    {
        [Min(0)] [SerializeField] protected float _maxDistance = 10;

        [Min(0)] [SerializeField] protected float _checkDelay = .2f;

        [SerializeField] protected LayerMask _mask;

        public abstract IEnumerable<IAimTarget> GetEntered();

        public event Action<IAimTarget> OnEnter;

        public event Action<IAimTarget> OnExit;

        public abstract void Check();

        public abstract bool IsEntered(IAimTarget target);

        protected void SendEnter(IAimTarget aimTarget)
        {
            OnEnter?.Invoke(aimTarget);
        }

        protected void SendExit(IAimTarget aimTarget)
        {
            OnExit?.Invoke(aimTarget);
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
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;

            Gizmos.DrawLine(transform.position, transform.position + transform.forward * _maxDistance);
        }
    }
}