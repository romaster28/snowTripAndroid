using Sources.Core.Stats;
using Sources.Core.Stats.ConcreteStats;
using Zenject;

namespace Sources.Core.Die
{
    public class DieSender : IInitializable
    {
        [Inject] private readonly StatsGetter _stats;

        [Inject] private readonly Death _death;
        
        private void ColdChanged(IReadOnlyBaseStat cold)
        {
            if (!cold.IsFull)
                return;
            
            _death.Die();
        }

        public void Initialize()
        {
            _stats.AddListenerChanged<ColdStat>(ColdChanged);
        }
    }
}