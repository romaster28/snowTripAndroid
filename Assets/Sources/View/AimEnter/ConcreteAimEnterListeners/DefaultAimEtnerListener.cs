using System.Collections.Generic;
using Sources.Core.AimEnter;
using UnityEngine;

namespace Sources.View.AimEnter.ConcreteAimEnterListeners
{
    public class DefaultAimEtnerListener : BaseAimEnterListener
    {
        private BaseAimTarget _last;

        public override bool IsEntered(IAimTarget target) => _last == (BaseAimTarget) target;

        public override IEnumerable<IAimTarget> GetEntered() => new[] { _last };

        public override void Check()
        {
            Vector3 origin = transform.position;

            if (!Physics.Linecast(origin, origin + transform.forward * _maxDistance, out RaycastHit hit, _mask))
            {
                TryExit();
                
                return;
            }

            if (!hit.collider.TryGetComponent(out BaseAimTarget target))
            {
                TryExit();
                
                return;
            }

            if (_last == target)
                return;
            
            TryExit();

            _last = target;
            
            SendEnter(_last);
        }

        private void TryExit()
        {
            if (_last == null)
                return;

            SendExit(_last);
            
            _last = null;
        }
    }
}