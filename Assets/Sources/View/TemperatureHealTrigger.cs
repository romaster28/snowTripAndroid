using Sources.Core.Temperature;
using UnityEngine;

namespace Sources.View
{
    public class TemperatureHealTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out TemperatureHealListener temperatureHealListener))
                temperatureHealListener.EnterHeal();
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out TemperatureHealListener temperatureHealListener))
                temperatureHealListener.ExitHeal();
        }
    }
}