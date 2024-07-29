using Sources.Signals.Game.Interface;
using Zenject;

namespace Sources.Core.ItemsPlace
{
    public class ItemsPlaceRouter : IInitializable
    {
        [Inject] private readonly ItemsPlacer _itemsPlacer;

        [Inject] private readonly SignalBus _signalBus;
        
        public void Initialize()
        {
            _signalBus.Subscribe(delegate(PlaceClickedSignal signal)
            {
                _itemsPlacer.PlaceReadyItem();
            });
        }
    }
}