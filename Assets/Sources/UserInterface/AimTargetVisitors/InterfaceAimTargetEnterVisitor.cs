using Sources.Core.AimEnter.Visitors;
using Sources.UserInterface.ConcreteScreens.Game;
using Sources.View.AimEnter.AimTargets;
using Zenject;

namespace Sources.UserInterface.AimTargetVisitors
{
    public class InterfaceAimTargetEnterVisitor : AimTargetEnterVisitor
    {
        [Inject] private readonly ScreensFacade _screens;
        
        public override void Visit(SeatAimTarget seatAimDefault)
        {
            _screens.Get<CharacterControlScreen>().SetEnterCarActive(true);
        }

        public override void Visit(Pickable pickable)
        {
            _screens.Get<CharacterControlScreen>().SetTakeItemActive(true);
        }

        public override void Visit(Door door)
        {
            _screens.Get<CharacterControlScreen>().SetInteractActive(true);
        }

        public override void Visit(GasTank gasTank)
        {
            
        }

        public override void Visit(BuildingItem buildingItem)
        {
            
        }
    }
}