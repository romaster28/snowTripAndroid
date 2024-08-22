using System;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.UserInterface.Elements.Common
{
    [Serializable]
    public class AmountSlideView
    {
        [SerializeField] private Image _fill;

        public void Update(int current, int total)
        {
            Update(current / (float)total);
        }

        public void Update(float amount01)
        {
            _fill.fillAmount = amount01;
        }
    }
}