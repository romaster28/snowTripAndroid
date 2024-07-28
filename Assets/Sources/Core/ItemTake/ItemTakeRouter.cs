using Sources.Core.AimEnter;
using Sources.Signals.Game;
using Sources.Signals.Game.Interface;
using Sources.View.AimEnter.AimTargets;
using Zenject;

namespace Sources.Core.ItemTake
{
    public class ItemTakeRouter : IInitializable
    {
        [Inject] private readonly SignalBus _signalBus;

        [Inject] private readonly IItemsTaker _taker;

        [Inject] private readonly IAimEnterListener _enterListener;

        public void Initialize()
        {
            _signalBus.Subscribe(delegate(TakeItemClickedSignal _)
            {
                if (_enterListener.NowEntered is PickableItem item)
                    _taker.Take(item.RigidBody);
            });
            
            _signalBus.Subscribe(delegate (DropItemClickedSignal _)
            {
                _taker.DropCurrent();
            });

            _taker.Taken += _signalBus.Fire<ItemTakenSignal>;

            _taker.Dropped += _signalBus.Fire<ItemDroppedSignal>;
        }
    }
}