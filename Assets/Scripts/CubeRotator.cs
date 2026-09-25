using System;
using UnityEngine;

public class CubeRotator : MonoBehaviour
{
    [Serializable]
    public enum RotationAxis
    { X, Y, Z };
    // ===== ===== ===== ===== ===== ===== ===== ===== ===== ===== 
    [SerializeField] private Transform _pivotObject;
    
    private RotationAxis _rotationAxis =  RotationAxis.Y;
    private bool _useCustomAxis = false;
    private Vector3 _customAxis = Vector3.up;
    private float _rotationSpeed;
    
    private Vector3 _axisVector = Vector3.up;
    // ===== ===== ===== ===== ===== ===== ===== ===== ===== ===== 
    
    private void Update()
    {
        _pivotObject.Rotate(_axisVector * _rotationSpeed * Time.deltaTime);
    }
    
    private void ApplyCurrentAxis()
    {
        if (_useCustomAxis)
        {
            _axisVector = _customAxis;
        }
        else
        {
            switch (_rotationAxis)
            {
                case RotationAxis.X: _axisVector = Vector3.right; break;
                case RotationAxis.Y: _axisVector = Vector3.up; break;
                case RotationAxis.Z: _axisVector = Vector3.forward; break;
            }
            
            _pivotObject.localRotation = Quaternion.identity; 
        }
    }
    
    // ===== ===== ===== ===== ===== ===== ===== ===== ===== ===== 
    
    public void SetSpeed(float speed)
    {
        _rotationSpeed = speed;
    }
    
    public void SetRotationAxis(RotationAxis axis)
    {
        _rotationAxis = axis;
        _useCustomAxis = false;
        ApplyCurrentAxis();
    }
    
    public void SetUseCustomAxis(bool use)
    {
        _useCustomAxis = use;
        ApplyCurrentAxis();
    }

    public void SetCustomAxis(Vector3 axis)
    {
        _customAxis = axis;
        if (_useCustomAxis) 
        {
            ApplyCurrentAxis();
        }
    }
}
