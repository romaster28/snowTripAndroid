using Zenject;

namespace Sources.UserInterface
{
    public abstract class BaseRouter : IInitializable
    {
        [Inject] protected readonly ScreensFacade Screens;

        [Inject] private readonly IElementRouter[] _screenRouters;
        
        protected abstract bool CloseAllScreensOnStart { get; }
        
        public void Initialize()
        {
            foreach (IElementRouter screenRouter in _screenRouters) 
                screenRouter.Initialize();

            Screens.CloseAll();
            
            OnInitialized();
        }

        protected virtual void OnInitialized()
        {
            
        }
    }
}