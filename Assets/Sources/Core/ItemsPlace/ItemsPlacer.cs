using Sources.Core.ItemsClean;
using Sources.Core.ItemTake;
using Sources.Signals.Game;
using Sources.View.AimEnter.AimTargets;
using UnityEngine;
using Zenject;

namespace Sources.Core.ItemsPlace
{
    public class ItemsPlacer
    {
        [Inject] private readonly SignalBus _signalBus;
        
        [Inject] private readonly IItemsTaker _itemsTaker;

        [Inject] private readonly IPickableItemsCleaner _cleaner;
        
        private BuildingItem _ready;

        public void GetReadyItem(BuildingItem item)
        {
            if (_itemsTaker.Current == null || _itemsTaker.Current is not Pickable pickable)
                return;

            if (pickable.Key != item.TargetPickable && pickable != item.SingleTarget)
                return;
            
            item.SetPreviewActive(true);

            _ready = item;
            
            _signalBus.Fire<ReadyToPlaceSignal>();
        }

        public void ReleaseReadyItem()
        {
            if (_ready == null)
                return;
            
            _ready.SetPreviewActive(false);
            
            _ready = null;
            
            _signalBus.Fire<ReleaseToPlaceSignal>();
        }

        public void PlaceReadyItem()
        {
            if (_ready == null)
                return;

            Pickable current = _itemsTaker.Current;
            
            _itemsTaker.DropCurrent();
            
            _cleaner.Clean(current);

            BuildingItem ready = _ready;
            
            _ready.Built?.Invoke();
            
            ReleaseReadyItem();
            
            Object.Destroy(ready.gameObject);
        }
    }
}