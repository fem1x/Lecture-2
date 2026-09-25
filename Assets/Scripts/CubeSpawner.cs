using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    // ===== ===== ===== ===== ===== ===== ===== ===== ===== ===== 
    [SerializeField] private int _initialCubeCount = 5;
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private Transform _pivotObject;

    private float _radius = 4f;
    private Dictionary<GameObject, TrailRenderer> _cubesTrailsDict = new();
    // ===== ===== ===== ===== ===== ===== ===== ===== ===== ===== 
    
    private void Awake() => SpawnStartingCubes();

    private void SpawnStartingCubes()
    {
        for (int i = 0; i < _initialCubeCount; i++)
            AddCube();
    }
    
    private void AdjuctAllCubesOffset()
    {
        for (int i = 0; i < _cubesTrailsDict.Count; i++)
        {
            Vector3 position = GetOffsetDir(i) *  _radius;

            var currentElement = _cubesTrailsDict.ElementAt(i);
            currentElement.Key.transform.position = position;
            currentElement.Value.Clear();
        }
    }

    // ===== ===== ===== ===== ===== ===== ===== ===== ===== ===== 
    
    public void AddCube()
    {
        GameObject cube = Instantiate(_cubePrefab,  _pivotObject);
        TrailRenderer trail = cube.GetComponent<TrailRenderer>();
        _cubesTrailsDict.Add(cube, trail);
        
        AdjuctAllCubesOffset();
    }
    
    public void RemoveCube()
    {
        GameObject firstCube = _cubesTrailsDict.First().Key;
        _cubesTrailsDict.Remove(firstCube);
        Destroy(firstCube);

        AdjuctAllCubesOffset();
    }

    public void SetRadius(float radius)
    {
        _radius = radius; 
        //AdjuctAllCubesOffset();
        foreach (var (cube, trail) in _cubesTrailsDict)
            cube.transform.position = cube.transform.position.normalized *  _radius;
    }
    
    // ===== ===== ===== ===== ===== ===== ===== ===== ===== ===== 
    
    private Vector3 GetOffsetDir(int cubeCount)
    {
        float angle = GetCurrentAngle(cubeCount);
        
        float xPos = Mathf.Cos(angle);
        float zPos = Mathf.Sin(angle);
        return new Vector3(xPos, 0f, zPos);
    }
    
    private float GetCurrentAngle(int cubeCount)
    {
        float anglePerCube = (2 * Mathf.PI) / _cubesTrailsDict.Count;
        return anglePerCube * cubeCount;
    }
}
