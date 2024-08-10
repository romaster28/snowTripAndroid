using System;

namespace Sources.Core.Car.Fuel.ConcreteFuelTanks
{
    public class RCCFuelTank : IFuelTank
    {
        public float Capacity => Car.OtherAddonsManager.FuelTank.fuelTankCapacityDefault;

        public float Amount => Car.OtherAddonsManager.FuelTank.fuelTankCapacity;
        
        public event Action Changed;

        private RCCP_CarController Car => RCCP_SceneManager.Instance.allVehicles[0];

        public void Fill(float amount)
        {
            Car.OtherAddonsManager.FuelTank.Refill(amount);
            
            Changed?.Invoke();
        }
    }
}