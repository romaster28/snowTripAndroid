using UnityEngine;

namespace Sources.View.DoorOpeners
{
    public abstract class BaseDoorOpener : MonoBehaviour
    {
        public abstract bool IsOpened { get; }

        public void Interact()
        {
            if (IsOpened)
                DoClose();
            else
                DoOpen();
        }
        
        protected abstract void DoOpen();

        protected abstract void DoClose();
    }
}