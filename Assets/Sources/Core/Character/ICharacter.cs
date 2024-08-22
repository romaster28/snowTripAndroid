using UnityEngine;

namespace Sources.Core.Character
{
    public interface ICharacter
    {
        void Hide();

        void ShowAtPosition(Vector3 position);

        void SetSprintActive(bool isActive);
        
        bool IsMoving { get; }
        
        Camera Camera { get; }
        
        Collider Collider { get; }
    }
}