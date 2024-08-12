using System;
using Rewired;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [Min(0)] [SerializeField] private float _speed = 3;

    [SerializeField] private float _verticalRange;

    private float _currentAngle;

    private Quaternion _relativeTo;

    private Vector2 _input;

    private void OnRotationReceivedX(InputActionEventData data)
    {
        _input.x = data.GetAxis();
    }

    private void OnRotationReceivedY(InputActionEventData data)
    {
        _input.y = data.GetAxis();
    }

    private void Start()
    {
        _relativeTo = transform.localRotation;
    }

    private void Update()
    {
        transform.eulerAngles += new Vector3 (-_input.y * _speed * Time.deltaTime, _input.x * _speed * Time.deltaTime, 0);

        
        
        float relRange = (_verticalRange + _verticalRange) / 2f;

        // calculate offset
        float offset = _verticalRange - relRange;

        // convert to a relative value
        Vector3 angles = transform.eulerAngles;
        
        float x = ((angles.x + 540) % 360) - 180 - offset;

        // if outside range
        if (Mathf.Abs(x) > relRange)
        {
            angles.x = relRange * Mathf.Sign(x) + offset;
            
            transform.eulerAngles = angles;
        }
    }

    private void OnEnable()
    {
        Player player = ReInput.players.GetPlayer(0);

        player.AddInputEventDelegate(OnRotationReceivedX, UpdateLoopType.Update, InputActionEventType.AxisActiveOrJustInactive,
            "RotateHorizontal");

        player.AddInputEventDelegate(OnRotationReceivedY, UpdateLoopType.Update, InputActionEventType.AxisActiveOrJustInactive,
            "RotateVertical");
    }
}