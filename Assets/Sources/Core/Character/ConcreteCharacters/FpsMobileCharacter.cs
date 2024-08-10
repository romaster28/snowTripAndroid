using System;
using UnityEngine;

namespace Sources.Core.Character.ConcreteCharacters
{
    public class FpsMobileCharacter : ICharacter
    {
        private readonly GameObject _character;

        public Camera Camera { get; }

        public FpsMobileCharacter(GameObject character, Camera camera)
        {
            _character = character;
            Camera = camera ? camera : throw new ArgumentNullException(nameof(camera));
        }

        public void Hide()
        {
            _character.gameObject.SetActive(false);
        }

        public void ShowAtPosition(Vector3 position)
        {
            _character.SetActive(true);

            _character.transform.position = position;
        }
    }
}