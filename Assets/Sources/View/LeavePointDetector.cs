using System;
using UnityEngine;

namespace Sources.View
{
    public class LeavePointDetector : MonoBehaviour
    {
        [Min(0)] [SerializeField] private float _width;

        [Min(0)] [SerializeField] private float _length;

        [SerializeField] private LayerMask _obstacle;
        
        private readonly Vector3[] _allPos = new Vector3[4];
        
        public Vector3 GetFirstFreePosition()
        {
            UpdatePoses();

            for (int i = 0; i < _allPos.Length; i++)
            {
                if (!Physics.Raycast(_allPos[i] - Vector3.down * 5, Vector3.up, _obstacle))
                    return _allPos[i];
            }

            return _allPos[3];
        }

        private void UpdatePoses()
        {
            Vector3 originalPos = transform.position;
            
            _allPos[0] = originalPos + -transform.right * _width;

            _allPos[1] = originalPos + transform.forward * _length;

            _allPos[2] = originalPos + transform.right * _width;

            _allPos[3] = originalPos - transform.forward * _length;
        }

        private void OnDrawGizmosSelected()
        {
            float radius = .2f;

            Vector3 originalPosition = transform.position;
            
            Gizmos.color = Color.blue;
            
            Gizmos.DrawSphere(originalPosition + transform.right * _width, radius);
            
            Gizmos.DrawSphere(originalPosition + -transform.right * _width, radius);
            
            Gizmos.color = Color.red;
            
            Gizmos.DrawSphere(originalPosition + transform.forward * _length, radius);
            
            Gizmos.DrawSphere(originalPosition + -transform.forward * _length, radius);
        }
    }
}