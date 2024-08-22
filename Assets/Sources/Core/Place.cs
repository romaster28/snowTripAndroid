using UnityEngine.SceneManagement;
using Zenject;

namespace Sources.Core
{
    public class Place : IInitializable
    {
        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void GoMenu()
        {
            
        }

        public void Initialize()
        {
            
        }
    }
}