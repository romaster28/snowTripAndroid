using Sources.Core.Stats;
using Sources.Core.Stats.ConcreteStats;
using Zenject;

namespace Sources.Installers
{
    public class StatsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<BaseStat[]>().FromInstance(new BaseStat[]
            {
                new HealthStat(),
                new StaminaStat(),
                new ColdStat()
            }).WhenInjectedInto<StatsGetter>();

            Container.Bind<StatsGetter>().AsSingle();
        }
    }
}