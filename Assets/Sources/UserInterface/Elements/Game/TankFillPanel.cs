using System;
using Sources.UserInterface.Elements.Common;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.UserInterface.Elements.Game
{
    [RequireComponent(typeof(RectTransform))]
    public class TankFillPanel : MonoBehaviour
    {
        [SerializeField] private ValueView _current;

        [SerializeField] private Image _fillView;
        
        [SerializeField] private Clickable _fill;

        public RectTransform RectTransform { get; private set; }
        
        public event Action OnFillDown;

        public event Action OnFillUp;

        public void SetFillActive(bool isActive) => _fill.gameObject.SetActive(isActive);
        
        public void UpdateCapacity(float current, float full)
        {
            float fillAmount = current / full;

            _fillView.fillAmount = fillAmount;
            
            _current.Update(current, full);
        }

        private void Awake()
        {
            RectTransform = GetComponent<RectTransform>();
        }

        private void Start()
        {
            _fill.OnDown += delegate
            {
                OnFillDown?.Invoke();
            };
            
            _fill.OnUp += delegate
            {
                OnFillUp?.Invoke();
            };
        }
    }
}