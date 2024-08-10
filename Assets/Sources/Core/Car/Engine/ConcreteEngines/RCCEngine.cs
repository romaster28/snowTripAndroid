using System;

namespace Sources.Core.Car.Engine.ConcreteEngines
{
    public class RCCEngine : IEngine
    {
        private RCCP_CarController Car => RCCP_SceneManager.Instance.allVehicles[0];

        public bool IsRunning => Car.Engine.engineRunning;
        
        public event Action Changed;

        public void Start()
        {
            Car.StartEngine();
            
            Changed?.Invoke();
        }

        public void Stop()
        {
            Car.StopEngine();
            
            Changed?.Invoke();
        }
    }
}