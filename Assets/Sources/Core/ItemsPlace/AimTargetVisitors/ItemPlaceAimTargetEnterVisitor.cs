using Sources.Core.AimEnter.Visitors;
using Sources.Core.ItemTake;
using Sources.View.AimEnter.AimTargets;
using UnityEngine;
using Zenject;

namespace Sources.Core.ItemsPlace.AimTargetVisitors
{
    public class ItemPlaceAimTargetEnterVisitor : AimTargetEnterVisitor
    {
        [Inject] private readonly ItemsPlacer _itemsPlacer;
        
        public override void Visit(SeatAimTarget seatAimDefault)
        {
            
        }

        public override void Visit(Pickable pickable)
        {
            
        }

        public override void Visit(BuildingItem buildingItem)
        {
            _itemsPlacer.GetReadyItem(buildingItem);
        }

        public override void Visit(Door door)
        {
            
        }

        public override void Visit(GasTank gasTank)
        {
            
        }
    }
}