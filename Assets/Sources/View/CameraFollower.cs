using System;
using UnityEngine;

namespace Sources.View
{
    public class CameraFollower : MonoBehaviour
    {
        [SerializeField] private Transform _target;

        [Min(0)] [SerializeField] private float _speed;

        [SerializeField] private Vector3 _offset;

        private void Awake()
        {
            transform.position = _target.position + _offset;
        }

        private void LateUpdate()
        {
            transform.position =
                Vector3.Lerp(transform.position, _target.position + _offset, _speed * Time.deltaTime);
        }
    }
}