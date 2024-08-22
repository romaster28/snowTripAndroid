using System;
using UnityEngine;

namespace Sources.Core.Stats
{
    public abstract class BaseStat : IReadOnlyBaseStat
    {
        private int _value;

        public int Value
        {
            get => _value;
            private set
            {
                value = Mathf.Clamp(value, 0, MaxValue);

                _value = value;
                
                Changed?.Invoke(this);
            }
        }

        public bool IsFull => Value >= MaxValue;

        public bool IsEmpty => Value <= 0;
        
        public abstract int StartValue { get; }

        public virtual int MaxValue => StartValue;

        public event Action<IReadOnlyBaseStat> Changed;

        protected BaseStat()
        {
            Value = StartValue;
        }

        public void Add(int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));
            
            Value += amount;
            
            
        }

        public bool TryTake(int amount)
        {
            if (Value < amount)
                return false;

            Value -= amount;

            return true;
        }
    }
}