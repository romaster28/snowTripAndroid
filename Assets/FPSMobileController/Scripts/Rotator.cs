using System;
using System.Collections;
using System.Collections.Generic;
using Rewired;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [Min(0)] [SerializeField] private float _speed = 3;

    [SerializeField] private Transform _horizontal;

    [SerializeField] private float _verticalRange;

    private float _currentAngle;

    private Quaternion _relativeTo;
    
    private void OnRotationReceivedX(InputActionEventData data) 
    {
        _horizontal.transform.Rotate(Vector3.up, _speed * data.GetAxis() * Time.deltaTime);
    }
    
    private void OnRotationReceivedY(InputActionEventData data) 
    {
        _currentAngle = Mathf.Clamp(_currentAngle + _speed * -data.GetAxis() * Time.deltaTime, -_verticalRange, _verticalRange);

        Quaternion fromInitial = Quaternion.AngleAxis(_currentAngle, Vector3.right);

        transform.localRotation = _relativeTo * fromInitial;
    }

    private void Start()
    {
        _relativeTo = transform.localRotation;
    }

    private void OnEnable()
    {
        Player player = ReInput.players.GetPlayer(0);

        player.AddInputEventDelegate(OnRotationReceivedX, UpdateLoopType.Update, InputActionEventType.AxisActive, "RotateHorizontal");
        player.AddInputEventDelegate(OnRotationReceivedY, UpdateLoopType.Update, InputActionEventType.AxisActive, "RotateVertical");
    }
}