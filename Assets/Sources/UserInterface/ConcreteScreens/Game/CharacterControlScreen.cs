using System;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.UserInterface.ConcreteScreens.Game
{
    public class CharacterControlScreen : BaseScreen
    {
        [SerializeField] private Button _enterCar;

        public event Action OnEnterCarClicked;

        private void Start()
        {
            _enterCar.onClick.AddListener(delegate
            {
                OnEnterCarClicked?.Invoke();
            });
        }
    }
}