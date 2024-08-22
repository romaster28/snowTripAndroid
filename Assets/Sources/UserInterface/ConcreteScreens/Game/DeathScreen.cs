using System;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.UserInterface.ConcreteScreens.Game
{
    public class DeathScreen : BaseScreen
    {
        [SerializeField] private Button _menu;

        [SerializeField] private Button _restart;

        public event Action OnMenuClicked;

        public event Action OnRestartClicked;

        private void Start()
        {
            _menu.onClick.AddListener(delegate
            {
                OnMenuClicked?.Invoke();
            });
            
            _restart.onClick.AddListener(delegate
            {
                OnRestartClicked?.Invoke();
            });
        }
    }
}