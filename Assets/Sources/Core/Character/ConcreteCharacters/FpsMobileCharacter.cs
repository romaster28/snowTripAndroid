using UnityEngine;

namespace Sources.Core.Character.ConcreteCharacters
{
    public class FpsMobileCharacter : ICharacter
    {
        private readonly GameObject _character;

        public FpsMobileCharacter(GameObject character)
        {
            _character = character;
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