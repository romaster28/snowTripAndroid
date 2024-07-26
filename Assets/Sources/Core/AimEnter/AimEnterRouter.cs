using Sources.View.AimEnter;
using Zenject;

namespace Sources.Core.AimEnter
{
    public class AimEnterRouter : IInitializable
    {
        [Inject] private readonly TargetAimEnterVisitor _visitor;

        private readonly AimEnterListener _listener;

        public AimEnterRouter(AimEnterListener listener)
        {
            _listener = listener;
        }

        private void ListenerOnOnEnter(AimTarget target)
        {
            target.Accept(_visitor);
        }

        public void Initialize()
        {
            _listener.OnEnter += ListenerOnOnEnter;
        }
    }
}