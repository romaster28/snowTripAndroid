using UnityEngine;

namespace Sources.Core.Car.ConcreteCars
{
    public class RealisticControllerCar : ICar
    {
        public RealisticControllerCar(Camera insideCamera)
        {
            InsideCamera = insideCamera;
        }

        public Camera InsideCamera { get; }

        public bool Entered => RCCP_SceneManager.Instance.activePlayerVehicle != null;

        public void Enter()
        {
            RCCP_SceneManager.Instance.activePlayerVehicle = RCCP_SceneManager.Instance.allVehicles[0];
        }

        public void Exit()
        {
            RCCP_SceneManager.Instance.activePlayerVehicle = null;
        }
    }
}