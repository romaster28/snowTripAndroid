using Sources.View.AimEnter.AimTargets;
using Sources.View.AimEnter.AimTargets.Weapons;

namespace Sources.Core.AimEnter.Visitors
{
    public abstract class AimTargetEnterVisitor
    {
        public abstract void Visit(SeatAimTarget seatAimDefault);

        public abstract void Visit(Pickable pickable);

        public abstract void Visit(BuildingItem buildingItem);

        public abstract void Visit(Door door);

        public abstract void Visit(GasTank gasTank);

        public abstract void Visit(Weapon weapon);
    }
}