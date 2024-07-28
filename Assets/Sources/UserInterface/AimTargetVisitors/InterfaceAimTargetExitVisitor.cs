using Sources.Core.AimEnter;
using Sources.Core.AimEnter.Visitors;
using Sources.UserInterface.ConcreteScreens.Game;
using Sources.View.AimEnter.AimTargets;
using Zenject;

namespace Sources.UserInterface.AimTargetVisitors
{
    public class InterfaceAimTargetExitVisitor : AimTargetExitVisitor
    {
        [Inject] private readonly ScreensFacade _screens;
        
        public override void Visit(DoorCarDefaultAimTarget doorCarDefault)
        {
            _screens.Get<CharacterControlScreen>().SetEnterCarActive(false);
        }

        public override void Visit(PickableItem pickableItem)
        {
            _screens.Get<CharacterControlScreen>().SetTakeItemActive(false);
        }
    }
}