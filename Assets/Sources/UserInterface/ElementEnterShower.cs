using System;
using System.Collections;
using Sources.Data.Place;
using Sources.Misc;
using UnityEngine;
using Zenject;

namespace Sources.UserInterface
{
    public class ElementEnterShower
    {
        [Inject] private readonly PlaceInterfaceConfig _config;

        [Inject] private readonly AsyncProcessor _asyncProcessor;

        private Coroutine _waitingHide;

        private Action _lastHide;
        
        public void ShowElement(Action hide)
        {
            if (_waitingHide != null)
            {
                _asyncProcessor.StopCoroutine(_waitingHide);
                
                _lastHide?.Invoke();
            }

            _lastHide = hide;
            
            _waitingHide = _asyncProcessor.StartCoroutine(WaitingHide());
        }

        private IEnumerator WaitingHide()
        {
            yield return new WaitForSeconds(_config.DisappearInteractButtonsDuration);
            
            _lastHide.Invoke();

            _lastHide = null;
        }
    }
}