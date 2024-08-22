using UnityEngine;
using Zenject;

namespace Sources.Core.Temperature
{
    public class TemperatureHealListener : MonoBehaviour
    {
        [Inject] private readonly Cold _cold;
        
        public void EnterHeal()
        {
            _cold.DeActivate();
        }

        public void ExitHeal()
        {
            _cold.Activate();
        }
    }
}