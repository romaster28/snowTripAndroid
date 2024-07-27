using System;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.UserInterface.ConcreteScreens.Game
{
    public class CarControlScreen : BaseScreen
    {
        [SerializeField] private Button _leave;

        public event Action OnLeaveClicked;

        private void Start()
        {
            _leave.onClick.AddListener(delegate
            {
                OnLeaveClicked?.Invoke();
            });
        }
    }
}