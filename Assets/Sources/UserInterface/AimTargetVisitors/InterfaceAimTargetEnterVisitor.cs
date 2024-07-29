using Sources.Core.AimEnter;
using Sources.Core.AimEnter.Visitors;
using Sources.UserInterface.ConcreteScreens.Game;
using Sources.View.AimEnter.AimTargets;
using UnityEngine;
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

        public override void Visit(BuildingItem buildingItem)
        {
            
        }
    }
}