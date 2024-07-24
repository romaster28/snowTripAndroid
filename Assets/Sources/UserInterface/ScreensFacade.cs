using System;
using System.Linq;
using UnityEngine;

namespace Sources.UserInterface
{
    [Serializable]
    public class ScreensFacade
    {
        [SerializeField] private BaseScreen[] _screens;
        
        public T Get<T>() where T : BaseScreen => _screens.First(x => x is T) as T;

        public void Open<T>() where T : BaseScreen => Get<T>().Open();
        
        public void Close<T>() where T : BaseScreen => Get<T>().Close();

        public void CloseAll()
        {
            foreach (BaseScreen screen in _screens) 
                screen.Close();
        }
    }
}