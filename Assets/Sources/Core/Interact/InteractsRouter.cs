using Sources.Core.AimEnter;
using Sources.Signals.Game.Interface;
using Sources.View.AimEnter.AimTargets;
using Zenject;

namespace Sources.Core.Interact
{
    public class InteractsRouter : IInitializable
    {
        [Inject] private readonly SignalBus _signalBus;

        [Inject] private readonly IAimEnterListener _listener;
        
        public void Initialize()
        {
            _signalBus.Subscribe(delegate(InteractClickedSignal _)
            {
                foreach (IAimTarget target in _listener.GetEntered())
                {
                    if (target is not Door door) 
                        continue;
                    
                    door.Opener.Interact();
                        
                    break;
                }
            });
        }
    }
}