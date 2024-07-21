using UnityEngine;

public static class TransformExtensions
{
    public static void ClampRotationY(this Transform transform, float range)
    {
        Vector3 euler = transform.rotation.eulerAngles;

        euler.y = Mathf.Clamp(euler.y, -range, range);
        
        transform.rotation = Quaternion.Euler(euler);
    }
    
    public static void ClampRotationX(this Transform transform, float range)
    {
        Vector3 euler = transform.rotation.eulerAngles;

        euler.x = Mathf.Clamp(euler.x, -range, range);
        
        transform.rotation = Quaternion.Euler(euler);
    }
}