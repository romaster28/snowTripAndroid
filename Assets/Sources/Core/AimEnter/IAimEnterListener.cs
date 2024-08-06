using System;
using System.Collections.Generic;

namespace Sources.Core.AimEnter
{
    public interface IAimEnterListener
    {
        public bool IsEntered(IAimTarget target);

        public IEnumerable<IAimTarget> GetEntered();

        event Action<IAimTarget> OnEnter;
        
        event Action<IAimTarget> OnExit;
    }
}