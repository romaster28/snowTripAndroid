using Zenject;

namespace Sources.UserInterface
{
    public abstract class BaseRouter : IInitializable
    {
        [Inject] protected readonly ScreensFacade Screens;
        
        public void Initialize()
        {
            Screens.CloseAll();
            
            OnInitialized();
        }

        protected virtual void OnInitialized()
        {
            
        }
    }
}