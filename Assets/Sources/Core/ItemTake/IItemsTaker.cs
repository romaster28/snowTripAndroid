using System;
using Sources.View.AimEnter.AimTargets;
using UnityEngine;

namespace Sources.Core.ItemTake
{
    public interface IItemsTaker
    {
        Pickable Current { get; }
        
        void Take(Pickable rigidBody);

        void DropCurrent();

        event Action Taken;

        event Action Dropped;
    }
}