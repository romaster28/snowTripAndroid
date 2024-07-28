using System;
using UnityEngine;

namespace Sources.Core.ItemTake
{
    public interface IItemsTaker
    {
        void Take(Rigidbody rigidBody);

        void DropCurrent();

        event Action Taken;

        event Action Dropped;
    }
}