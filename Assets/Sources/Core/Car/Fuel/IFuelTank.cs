using System;

namespace Sources.Core.Car.Fuel
{
    public interface IFuelTank
    {
        void Fill(float amount);
        
        float Capacity { get; }
        
        float Amount { get; }

        float Amount01 => Capacity / Amount;

        event Action Changed;
    }
}