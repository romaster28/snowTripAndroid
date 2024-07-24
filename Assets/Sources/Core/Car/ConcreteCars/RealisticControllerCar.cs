namespace Sources.Core.Car.ConcreteCars
{
    public class RealisticControllerCar : ICar
    {
        public void Activate()
        {
            RCCP_SceneManager.Instance.activePlayerVehicle = RCCP_SceneManager.Instance.allVehicles[0];
        }

        public void DeActivate()
        {
            RCCP_SceneManager.Instance.activePlayerVehicle = null;
        }
    }
}