using System.Collections.Generic;
using UnityEngine;

namespace Sources.Data
{
    [CreateAssetMenu(fileName = "New Dialog Data", menuName = "Game/Dialog", order = 0)]
    public class DialogData : ScriptableObject
    {
        [SerializeField] private string[] _lines;

        public IEnumerable<string> Lines => _lines;
    }
}