using UnityEngine;

public class CubeControllerUI : MonoBehaviour
{
    // ===== ===== ===== ===== ===== ===== ===== ===== ===== ===== 
    [Header("References")]
    [SerializeField] private CubeRotator _rotator;
    [SerializeField] private CubeSpawner _spawner;
    
    private Vector3 _tempCustomAxis = Vector3.up;
    // ===== ===== ===== ===== ===== ===== ===== ===== ===== ===== 
    
    //Standard Axis
    public void SelectAxisX() => _rotator.SetRotationAxis(CubeRotator.RotationAxis.X);
    public void SelectAxisY() => _rotator.SetRotationAxis(CubeRotator.RotationAxis.Y);
    public void SelectAxisZ() => _rotator.SetRotationAxis(CubeRotator.RotationAxis.Z);

    //Custom Axis
    public void OnCustomAxisToggleChanged(bool useCustom)
    {
        _rotator.SetUseCustomAxis(useCustom);
    }

    public void OnInputXChanged(string text)
    {
        float.TryParse(text, out _tempCustomAxis.x);
        _rotator.SetCustomAxis(_tempCustomAxis);
    }

    public void OnInputYChanged(string text)
    {
        float.TryParse(text, out _tempCustomAxis.y);
        _rotator.SetCustomAxis(_tempCustomAxis);
    }

    public void OnInputZChanged(string text)
    {
        float.TryParse(text, out _tempCustomAxis.z);
        _rotator.SetCustomAxis(_tempCustomAxis);
    }

    //Sliders
    public void OnSpeedSliderChanged(float speed) => _rotator.SetSpeed(speed);
    public void OnRadiusSliderChanged(float radius) => _spawner.SetRadius(radius);
    
    //Cube count
    public void OnClickMinusButton() => _spawner.RemoveCube();
    public void OnClickPlusButton() => _spawner.AddCube();
}
