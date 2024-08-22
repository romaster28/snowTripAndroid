using System;
using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace Sources.Core.Stats
{
    public class StatsGetter
    {
        [Inject] private BaseStat[] _stats;

        public IEnumerable<IReadOnlyBaseStat> GetAllStats() => _stats;
        
        public T Get<T>() where T : BaseStat => _stats.First(x => x is T) as T;
        
        public void Add<T>(int amount) where T : BaseStat
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount));
            
            Get<T>().Add(amount);
        }

        public bool TryTake<T>(int amount) where T : BaseStat => Get<T>().TryTake(amount);

        public void AddListenerChanged<T>(Action<IReadOnlyBaseStat> changed) where T : BaseStat => Get<T>().Changed += changed;

        public void RemoveListenerChanged<T>(Action<IReadOnlyBaseStat> changed) where T : BaseStat => Get<T>().Changed -= changed;
    }
}