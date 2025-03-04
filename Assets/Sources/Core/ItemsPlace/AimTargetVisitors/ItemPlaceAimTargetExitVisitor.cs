using Sources.Core.AimEnter.Visitors;
using Sources.View.AimEnter.AimTargets;
using Sources.View.AimEnter.AimTargets.Weapons;
using Zenject;

namespace Sources.Core.ItemsPlace.AimTargetVisitors
{
    public class ItemPlaceAimTargetExitVisitor : AimTargetExitVisitor
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
            _itemsPlacer.ReleaseReadyItem();
        }

        public override void Visit(Door door)
        {
            
        }

        public override void Visit(GasTank gasTank)
        {
            
        }

        public override void Visit(Weapon weapon)
        {
            
        }
    }
}