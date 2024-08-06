using System.Collections.Generic;
using UnityEngine;

namespace Sources.Editor
{
    public static class EditorExtensions
    {
        #if UNITY_EDITOR
        
        /// <summary>
        /// Very complex, use only in editor
        /// </summary>
        /// <param name="aParent"></param>
        /// <returns></returns>
        public static List<GameObject> GetAllChildren(this Transform aParent)
        {
            List<GameObject> children = new List<GameObject>();

            Queue<Transform> queue = new Queue<Transform>();
            
            queue.Enqueue(aParent);
            
            while (queue.Count > 0)
            {
                var c = queue.Dequeue();

                children.Add(c.gameObject);

                foreach (Transform t in c)
                    queue.Enqueue(t);
            }

            return children;
        }
        
        #endif
    }
}