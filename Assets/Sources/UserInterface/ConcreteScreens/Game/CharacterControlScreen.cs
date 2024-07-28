using System;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.UserInterface.ConcreteScreens.Game
{
    public class CharacterControlScreen : BaseScreen
    {
        [SerializeField] private Button _enterCar;

        [SerializeField] private Button _takeItem;

        [SerializeField] private Button _dropItem;
        
        public event Action OnEnterCarClicked;

        public event Action OnTakeItemClicked;

        public event Action OnDropItemClicked;

        public void SetEnterCarActive(bool isActive) => _enterCar.gameObject.SetActive(isActive);

        public void SetTakeItemActive(bool isActive) => _takeItem.gameObject.SetActive(isActive);

        public void SetDropItemActive(bool isActive) => _dropItem.gameObject.SetActive(isActive);

        private void Start()
        {
            _enterCar.onClick.AddListener(delegate
            {
                OnEnterCarClicked?.Invoke();
            });
            
            _takeItem.onClick.AddListener(delegate
            {
                OnTakeItemClicked?.Invoke();
            });
            
            _dropItem.onClick.AddListener(delegate
            {
                OnDropItemClicked?.Invoke();
            });
        }
    }
}