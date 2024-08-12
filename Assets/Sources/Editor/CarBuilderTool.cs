using Sources.View.AimEnter.AimTargets;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sources.Editor
{
    public class CarBuilderTool : EditorWindow
    {
        [MenuItem("Tools/Build Selected car")]
        private static void BuildSelectedCar()
        {
            if (!Application.isPlaying)
                return;

            var allRootObjects = SceneManager.GetActiveScene().GetRootGameObjects();

            foreach (GameObject rootObject in allRootObjects)
            {
                var allChildren = rootObject.transform.GetAllChildren();

                foreach (GameObject children in allChildren)
                {
                    if (children.TryGetComponent<BuildingItem>(out var item))
                    {
                        item.GameObject().SetActive(false);
                    
                        item.Built?.Invoke();
                    }
                }
            }
        }
    }
}