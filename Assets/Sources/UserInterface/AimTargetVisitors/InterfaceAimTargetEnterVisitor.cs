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
        
        public override void Visit(DoorCarDefaultAimTarget doorCarDefault)
        {
            _screens.Get<CharacterControlScreen>().SetEnterCarActive(true);
        }

        public override void Visit(PickableItem pickableItem)
        {
            _screens.Get<CharacterControlScreen>().SetTakeItemActive(true);
        }
    }
}