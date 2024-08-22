using Sources.Core.Stats;
using Sources.UserInterface.ConcreteScreens.Game;
using Zenject;

namespace Sources.UserInterface.ElementRouters
{
    public class StatsRouter : IElementRouter
    {
        [Inject] private readonly StatsGetter _statsGetter;

        [Inject] private readonly ScreensFacade _screens;

        private CharacterControlScreen CharacterControlScreen => _screens.Get<CharacterControlScreen>();
        
        private void UpdateStat(IReadOnlyBaseStat updated)
        {
            CharacterControlScreen.StatsView.Update(updated);
        }

        public void Initialize()
        {
            foreach (IReadOnlyBaseStat stat in _statsGetter.GetAllStats())
            {
                stat.Changed += UpdateStat;
                
                UpdateStat(stat);
            }
        }
    }
}