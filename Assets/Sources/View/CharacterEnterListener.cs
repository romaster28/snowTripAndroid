using System;
using Sources.Core.Character;
using UnityEngine;

namespace Sources.View
{
    public class CharacterEnterListener : MonoBehaviour, ICharacterEnterListener
    {
        public event Action<GameObject> TriggerEntered;
        
        public event Action<GameObject> ColliderEntered;

        private void OnTriggerEnter(Collider other)
        {
            TriggerEntered?.Invoke(other.gameObject);
        }

        private void OnCollisionEnter(Collision other)
        {
            ColliderEntered?.Invoke(other.gameObject);
        }
    }
}