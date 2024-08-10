using System;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.UserInterface.ConcreteScreens.Game
{
    public class CarControlScreen : BaseScreen
    {
        [SerializeField] private Button _leave;

        [SerializeField] private Button _startEngine;

        [SerializeField] private Button _stopEngine;
        
        public event Action OnLeaveClicked;

        public event Action OnStartEngineClicked;

        public event Action OnStopEngineClicked;

        public void SetStartEngineActive(bool isActive) => _startEngine.gameObject.SetActive(isActive);

        public void SetStopEngineActive(bool isActive) => _stopEngine.gameObject.SetActive(isActive);

        private void Start()
        {
            _leave.onClick.AddListener(delegate
            {
                OnLeaveClicked?.Invoke();
            });
            
            _startEngine.onClick.AddListener(delegate
            {
                OnStartEngineClicked?.Invoke();
            });
            
            _stopEngine.onClick.AddListener(delegate
            {
                OnStopEngineClicked?.Invoke();
            });
        }
    }
}