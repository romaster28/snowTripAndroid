using System;
using TMPro;
using UnityEngine;

namespace Sources.UserInterface.Elements.Common
{
    [Serializable]
    public class ValueView
    {
        [SerializeField] private TMP_Text _view;

        [SerializeField] private string _format;

        public void Update<T>(T value) => Update(value.ToString());

        public void Update<T>(T value1, T value2) => Update(value1.ToString(), value2.ToString());
        
        public void Update<T>(T value1, T value2, T value3) => Update(value1.ToString(), value2.ToString(), value3.ToString());

        private void Update(params string[] values) => _view.text = string.IsNullOrEmpty(_format) ? values[0] : string.Format(_format, values);
    }
}