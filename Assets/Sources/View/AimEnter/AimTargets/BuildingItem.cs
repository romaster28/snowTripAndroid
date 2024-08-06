using Sources.Core.AimEnter.Visitors;
using Sources.Data;
using UnityEngine;
using UnityEngine.Events;

namespace Sources.View.AimEnter.AimTargets
{
    public class BuildingItem : BaseAimTarget
    {
        [SerializeField] private UnityEvent _built;

        [SerializeField] private GameObject _preview;

        [SerializeField] private PickableKey _targetPickable;
        
        [SerializeField] private Pickable _singleTarget;

        public UnityEvent Built => _built;

        public PickableKey TargetPickable => _targetPickable;

        public Pickable SingleTarget => _singleTarget;

        public void SetPreviewActive(bool isActive) => _preview.SetActive(isActive);
        
        public override void Accept(AimTargetEnterVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override void Accept(AimTargetExitVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}