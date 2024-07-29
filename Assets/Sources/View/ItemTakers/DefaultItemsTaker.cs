using System;
using System.Collections;
using Sources.Core.ItemTake;
using Sources.Data.Place;
using Sources.View.AimEnter.AimTargets;
using UnityEngine;
using Zenject;

namespace Sources.View.ItemTakers
{
    public class DefaultItemsTaker : MonoBehaviour, IItemsTaker
    {
        [SerializeField] private Vector2 _offset;

        [Min(0)] [SerializeField] private float _distance = 5;

        [Inject] private readonly ItemTakeConfig _config;

        private ConfigurableJoint _attachment;

        private Rigidbody _attachmentRigidBody;

        private Coroutine _moving;

        public Pickable Current { get; private set; }
        
        private Vector3 PointerPosition => transform.position + transform.forward * _distance + transform.TransformDirection(_offset);

        public event Action Taken;

        public event Action Dropped;

        public void Take(Pickable pickable)
        {
            if (Current != null)
                DropCurrent();
            
            Current = pickable;
            
            Take(pickable.RigidBody);
        }

        private void Take(Rigidbody item)
        {
            AttachJoint(item);

            _moving = StartCoroutine(MovingAttachmentToPosition());

            Taken?.Invoke();
        }

        public void DropCurrent()
        {
            if (Current == null)
                throw new InvalidOperationException("No taken item yet");

            DeAttachJoint();

            Current = null;

            StopCoroutine(_moving);

            Dropped?.Invoke();
        }

        private void AttachJoint(Rigidbody item)
        {
            _attachment.connectedBody = item;

            _attachment.configuredInWorldSpace = true;

            _attachment.xDrive = CreateJointDrive(_config.Force, _config.Damping);

            _attachment.yDrive = CreateJointDrive(_config.Force, _config.Damping);

            _attachment.zDrive = CreateJointDrive(_config.Force, _config.Damping);

            _attachment.slerpDrive = CreateJointDrive(_config.Force, _config.Damping);

            _attachment.rotationDriveMode = RotationDriveMode.Slerp;

            item.interpolation = RigidbodyInterpolation.Interpolate;

            item.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        }

        private void DeAttachJoint()
        {
            _attachment.connectedBody = null;
        }

        private JointDrive CreateJointDrive(float force, float damping)
        {
            JointDrive drive = new JointDrive
            {
                positionSpring = force,
                positionDamper = damping,
                maximumForce = Mathf.Infinity
            };
            return drive;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;

            Gizmos.DrawSphere(PointerPosition, .2f);
        }

        private void Start()
        {
            var rigidBody = new GameObject("Take Item Attachment").AddComponent<Rigidbody>();

            _attachment = rigidBody.gameObject.AddComponent<ConfigurableJoint>();

            rigidBody.interpolation = RigidbodyInterpolation.Interpolate;

            rigidBody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;

            rigidBody.isKinematic = true;

            rigidBody.position = PointerPosition;

            _attachment.autoConfigureConnectedAnchor = false;

            _attachmentRigidBody = rigidBody;
        }

        private IEnumerator MovingAttachmentToPosition()
        {
            while (true)
            {
                _attachmentRigidBody.position = PointerPosition;

                _attachmentRigidBody.rotation = transform.rotation;

                yield return new WaitForFixedUpdate();
                ;
            }
        }
    }
}