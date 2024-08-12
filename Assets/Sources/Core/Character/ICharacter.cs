using UnityEngine;

namespace Sources.Core.Character
{
    public interface ICharacter
    {
        void Hide();

        void ShowAtPosition(Vector3 position);

        Camera Camera { get; }
        
        Collider Collider { get; }
    }
}