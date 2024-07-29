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

        [SerializeField] private Button _place;
        
        public event Action OnEnterCarClicked;

        public event Action OnTakeItemClicked;

        public event Action OnDropItemClicked;

        public event Action OnPlaceClicked;

        public void SetEnterCarActive(bool isActive) => _enterCar.gameObject.SetActive(isActive);

        public void SetTakeItemActive(bool isActive) => _takeItem.gameObject.SetActive(isActive);

        public void SetDropItemActive(bool isActive) => _dropItem.gameObject.SetActive(isActive);

        public void SetPlaceActive(bool isActive) => _place.gameObject.SetActive(isActive);

        private void Start()
        {
            _place.onClick.AddListener(delegate
            {
                OnPlaceClicked?.Invoke();
            });
            
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