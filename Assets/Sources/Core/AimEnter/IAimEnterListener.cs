using System;

namespace Sources.Core.AimEnter
{
    public interface IAimEnterListener
    {
        public IAimTarget NowEntered { get; }

        event Action<IAimTarget> OnEnter;
        
        event Action<IAimTarget> OnExit;
    }
}