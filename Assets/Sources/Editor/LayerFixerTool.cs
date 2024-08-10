using System.Linq;
using Sources.View.AimEnter.AimTargets;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sources.Editor
{
    public class LayerFixerTool : EditorWindow
    {
        [MenuItem("Tools/Fix layers car elements")]
        private static void FixLayers()
        {
            var allRootObjects = SceneManager.GetActiveScene().GetRootGameObjects();

            foreach (GameObject rootObject in allRootObjects)
            {
                var allChildren = rootObject.transform.GetAllChildren();

                foreach (GameObject children in allChildren)
                {
                    string layerName = LayerMask.LayerToName(children.layer);

                    if (children.GetComponent<BuildingItem>())
                        layerName = "BuildingArea";

                    if (children.GetComponent<SeatAimTarget>())
                        layerName = "Seat";

                    if (children.GetComponent<Door>())
                        layerName = "Interactable";

                    if (children.GetComponent<GasTank>())
                        layerName = "AimTarget";
                    
                    children.layer = LayerMask.NameToLayer(layerName);
                }
            }
        }
    }
}