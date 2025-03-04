using Sources.Core.ItemTake;
using Sources.Signals.Game;
using Sources.View.AimEnter.AimTargets;
using Sources.View.AimEnter.AimTargets.Weapons;
using Zenject;

namespace Sources.Core.Shoot
{
    public class ShootRouter : IInitializable
    {
        [Inject] private readonly WeaponProcessor _weaponProcessor;

        [Inject] private readonly IItemsTaker _itemsTaker;

        [Inject] private readonly SignalBus _signalBus;
        
        public void Initialize()
        {
            _signalBus.Subscribe(delegate(FireClickedSignal _)
            {
                _weaponProcessor.OnWeaponFireClicked();
            });
            
            _itemsTaker.Taken += delegate(Pickable pickable)
            {
                if (pickable is not Weapon weapon)
                    return;
                
                _weaponProcessor.OnWeaponTaken(weapon);
            };
            
            _itemsTaker.Dropped += delegate(Pickable pickable)
            {
                if (pickable is not Weapon weapon)
                    return;
                
                _weaponProcessor.OnWeaponDropped(weapon);
            };
        }
    }
}