using System;
using UnityEngine;

namespace Sources.Core.Character
{
    public interface ICharacterEnterListener
    {
        event Action<GameObject> TriggerEntered;

        event Action<GameObject> ColliderEntered;
    }
}