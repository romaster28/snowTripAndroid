using Sources.Core.Teleport;
using UnityEngine.SceneManagement;

namespace Sources.Core.Menu
{
    public class Teleportator : ITeleportator
    {
        public void Teleport(ITeleportTarget target)
        {
            SceneManager.LoadScene(target.SceneName);
        }
    }
}