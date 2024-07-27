using Zenject;

namespace Sources.UserInterface
{
    public abstract class BaseRouter : IInitializable
    {
        [Inject] protected readonly ScreensFacade Screens;

        [Inject] private readonly IScreenRouter[] _screenRouters;
        
        protected abstract bool CloseAllScreensOnStart { get; }
        
        public void Initialize()
        {
            foreach (IScreenRouter screenRouter in _screenRouters) 
                screenRouter.Initialize();

            Screens.CloseAll();
            
            OnInitialized();
        }

        protected virtual void OnInitialized()
        {
            
        }
    }
}