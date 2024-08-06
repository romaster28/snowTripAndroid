using System.Collections.Generic;
using Sources.Core.AimEnter;
using UnityEngine;

namespace Sources.View.AimEnter.ConcreteAimEnterListeners
{
    public class MultipleAimEnterListener : BaseAimEnterListener
    {
        [Min(1)] [SerializeField] private int _maximumInLine = 2;

        private List<IAimTarget> _cacheEnter;

        private List<IAimTarget> _entered;

        private RaycastHit[] _hits;

        public override IEnumerable<IAimTarget> GetEntered() => _entered;
        
        public override bool IsEntered(IAimTarget target) => _entered.Contains(target);
        
        public override void Check()
        {
            Vector3 origin = transform.position;

            var ray = new Ray(origin, transform.forward * _maxDistance);

            int castedCount = Physics.RaycastNonAlloc(ray, _hits, _maxDistance, _mask);

            _cacheEnter.Clear();
            
            for (int i = 0; i < castedCount; i++)
            {
                var hit = _hits[i];

                if (!hit.collider.TryGetComponent(out BaseAimTarget target))
                {
                    continue;
                }

                if (_entered.Contains(target))
                {
                    
                    
                    _cacheEnter.Add(target);
                    
                    continue;
                }

                _entered.Add(target);
                
                _cacheEnter.Add(target);
            }

            for (int i = 0; i < _entered.Count; i++)
            {
                BaseAimTarget target = (BaseAimTarget) _entered[i];

                if (_cacheEnter.Contains(target))
                {
                    SendEnter(target);
                    
                    continue;
                }

                _entered.Remove(target);
                    
                SendExit(target);
            }
        }

        private void Awake()
        {
            _hits = new RaycastHit[_maximumInLine];

            _entered = new List<IAimTarget>(_maximumInLine);

            _cacheEnter = new List<IAimTarget>(_maximumInLine);
        }
    }
}