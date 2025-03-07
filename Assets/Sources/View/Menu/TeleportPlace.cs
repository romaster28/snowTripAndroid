using Sources.Core.Menu;
using UnityEngine;

namespace Sources.View.Menu
{
    public class TeleportPlace : MonoBehaviour, ITeleportTarget
    {
        [SerializeField] private string _sceneName;
        
        public string SceneName => _sceneName;
    }
}