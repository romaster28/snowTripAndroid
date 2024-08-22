using System;

namespace Sources.Core.Stats
{
    public interface IReadOnlyBaseStat
    {
        public int Value { get; }

        public int StartValue { get; }

        public int MaxValue { get; }

        public bool IsFull { get; }
        
        public bool IsEmpty { get; }
        
        public float Amount01 => Value / (float)MaxValue;

        public event Action<IReadOnlyBaseStat> Changed;
    }
}