using UnityEngine;

namespace Sources.Core.Car
{
    public interface ICar
    {
        void Enter();

        void Exit();

        bool Entered { get; }

        Camera InsideCamera { get; }
    }
}