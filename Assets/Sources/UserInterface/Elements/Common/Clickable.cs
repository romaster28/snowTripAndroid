using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Sources.UserInterface.Elements.Common
{
    public class Clickable : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public event Action OnDown;

        public event Action OnUp;
        
        public void OnPointerDown(PointerEventData eventData)
        {
            OnDown?.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            OnUp?.Invoke();
        }
    }
}