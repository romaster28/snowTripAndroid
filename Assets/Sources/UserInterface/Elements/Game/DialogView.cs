using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace Sources.UserInterface.Elements.Game
{
    [Serializable]
    public class DialogView
    {
        [SerializeField] private GameObject _panel;
        
        [SerializeField] private TMP_Text _view;

        [SerializeField] private float _characterAddDelay = .1f;

        [SerializeField] private float _delayMessage = .3f;

        public void Show(MonoBehaviour coroutineStarter, string message) => coroutineStarter.StartCoroutine(Showing(message));

        public void Show(MonoBehaviour coroutineStarter, IEnumerable<string> messages) => coroutineStarter.StartCoroutine(MultipleShowing(messages));

        private IEnumerator MultipleShowing(IEnumerable<string> messages) => messages.Select(Showing).GetEnumerator();

        private IEnumerator Showing(string message)
        {
            _panel.SetActive(true);
            
            var waitDelayChar = new WaitForSeconds(_characterAddDelay); 
            
            _view.text = string.Empty;
            
            foreach (var charMessage in message)
            {
                _view.text += charMessage;

                yield return waitDelayChar;
            }

            yield return new WaitForSeconds(_delayMessage);
            
            _view.text = string.Empty;
            
            _panel.SetActive(false);
        }
    }
}