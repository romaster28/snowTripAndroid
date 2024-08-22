using System;
using TMPro;
using UnityEngine;

namespace Sources.UserInterface.Elements.Common.GenericsValueView
{
    [Serializable]
    public abstract class BaseValueView
    {
        [SerializeField] protected TMP_Text _view;

        [SerializeField] protected string _format;
    }
    
    [Serializable]
    public class ValueView<T> : BaseValueView
    {
        public void Update(T value) => _view.text = string.Format(_format, value.ToString());
    }

    public class ValueView<T1, T2> : BaseValueView
    {
        public void Update(T1 firstValue, T2 secondValue) =>
            _view.text = string.Format(_format, firstValue.ToString(), secondValue.ToString());
    }
}