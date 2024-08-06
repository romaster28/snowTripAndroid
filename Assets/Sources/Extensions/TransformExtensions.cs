using System;
using System.Collections.Generic;
using Sources.Data;
using UnityEngine;

namespace Sources.Extensions
{
    public static class TransformExtensions
    {
        public static void SetLocalRotationAngle(this Transform transform, Axis axis, float angle)
        {
            Vector3 rotation = transform.localRotation.eulerAngles;

            switch (axis)
            {
                case Axis.X:
                    rotation.x = angle;
                    break;
                case Axis.Y:
                    rotation.y = angle;
                    break;
                case Axis.Z:
                    rotation.z = angle;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(axis), axis, null);
            }

            transform.localRotation = Quaternion.Euler(rotation);
        }
    }
}