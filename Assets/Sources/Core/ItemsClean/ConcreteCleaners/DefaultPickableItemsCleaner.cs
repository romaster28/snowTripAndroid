using Sources.View.AimEnter.AimTargets;
using UnityEngine;

namespace Sources.Core.ItemsClean.ConcreteCleaners
{
    public class DefaultPickableItemsCleaner : IPickableItemsCleaner
    {
        public void Clean(Pickable pickable)
        {
            Object.Destroy(pickable.gameObject);
        }
    }
}