using Sources.Core.AimEnter.Visitors;
using Sources.Signals.Game;
using Sources.View.AimEnter;
using Zenject;

namespace Sources.Core.AimEnter
{
    public class AimEnterRouter : IInitializable
    {
        [Inject] private readonly AimTargetEnterVisitor[] _enterVisitors;

        [Inject] private readonly AimTargetExitVisitor[] _exitVisitors;

        [Inject] private readonly IAimEnterListener _listener;

        private void ListenerOnEnter(IAimTarget target)
        {
            foreach (AimTargetEnterVisitor enterVisitor in _enterVisitors) 
                target.Accept(enterVisitor);
        }

        private void ListenerOnExit(IAimTarget target)
        {
            foreach (AimTargetExitVisitor exitVisitor in _exitVisitors) 
                target.Accept(exitVisitor);
        }

        public void Initialize()
        {
            _listener.OnEnter += ListenerOnEnter;

            _listener.OnExit += ListenerOnExit;
        }
    }
}