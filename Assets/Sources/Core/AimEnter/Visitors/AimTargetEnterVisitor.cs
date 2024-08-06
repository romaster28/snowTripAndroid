using Sources.View.AimEnter.AimTargets;

namespace Sources.Core.AimEnter.Visitors
{
    public abstract class AimTargetEnterVisitor
    {
        public abstract void Visit(SeatAimTarget seatAimDefault);

        public abstract void Visit(Pickable pickable);

        public abstract void Visit(BuildingItem buildingItem);

        public abstract void Visit(Door door);
    }
}