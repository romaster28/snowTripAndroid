using Sources.View.AimEnter;
using Zenject;

namespace Sources.Core.AimEnter
{
    public class AimEnterRouter : IInitializable
    {
        [Inject] private readonly TargetAimEnterVisitor _visitor;

        [Inject] private readonly TargetAimExitVisitor _exitVisitor;
        
        private readonly AimEnterListener _listener;

        public AimEnterRouter(AimEnterListener listener)
        {
            _listener = listener;
        }

        private void ListenerOnOnEnter(AimTarget target)
        {
            target.Accept(_visitor);
        }

        private void ListenerOnExit(AimTarget target)
        {
            target.Accept(_exitVisitor);
        }

        public void Initialize()
        {
            _listener.OnEnter += ListenerOnOnEnter;

            _listener.OnExit += ListenerOnExit;
        }
    }
}