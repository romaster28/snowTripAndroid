using System;
using UnityEngine;

namespace Sources.Data.Place
{
    [Serializable]
    public class DialogsConfig
    {
        [SerializeField] private DialogData _start;

        [SerializeField] private DialogData _lose;

        [SerializeField] private DialogData _win;

        public DialogData Start => _start;

        public DialogData Lose => _lose;

        public DialogData Win => _win;
    }
}