using System;
using UnityEngine;

namespace Sources.View.Weapon
{
    [RequireComponent(typeof(Rigidbody))]
    public class BulletView : MonoBehaviour
    {
        public Rigidbody RigidBody { get; private set; }

        private void Awake()
        {
            RigidBody = GetComponent<Rigidbody>();
        }
    }
}