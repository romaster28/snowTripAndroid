using Sources.Core;
using UnityEngine;
using Zenject;

namespace Sources.UserInterface.Elements.Common
{
    public class WorldUiTargetFollower
    {
        [Inject] private readonly ActiveCamera _activeCamera;

        public void FollowToActiveCamera(RectTransform follower, Transform worldTarget) =>
            follower.position = _activeCamera.Get().WorldToScreenPoint(worldTarget.position);
    }
}