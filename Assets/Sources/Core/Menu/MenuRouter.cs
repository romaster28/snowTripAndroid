using System;
using Sources.Core.Character;
using Sources.Core.Teleport;
using Sources.View.Menu;
using UnityEngine;
using Zenject;

namespace Sources.Core.Menu
{
    public class MenuRouter : IInitializable
    {
        private readonly ITeleportator _teleportator;

        private readonly ICharacterEnterListener _enterListener;

        public MenuRouter(ITeleportator teleportator, ICharacterEnterListener enterListener)
        {
            _teleportator = teleportator ?? throw new ArgumentNullException(nameof(teleportator));
            _enterListener = enterListener ?? throw new ArgumentNullException(nameof(enterListener));
        }

        private void EnterListenerOnTriggerEntered(GameObject other)
        {
            if (!other.TryGetComponent(out TeleportPlace teleport))
                return;
            
            _teleportator.Teleport(teleport);
        }

        public void Initialize()
        {
            _enterListener.TriggerEntered += EnterListenerOnTriggerEntered;
        }
    }
}