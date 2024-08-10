using Sources.Core.Car;
using Sources.Core.Character;
using UnityEngine;
using Zenject;

namespace Sources.Core
{
    public class ActiveCamera
    {
        [Inject] private readonly ICar _car;

        [Inject] private readonly ICharacter _character;

        public Camera Get() => _car.Entered ? _car.InsideCamera : _character.Camera;
    }
}