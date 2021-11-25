using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToSpawn;
    [SerializeField] private float spawnInterval;
    [SerializeField] private int targetSpawnAmount;
    private Camera _camera;
    private float _minX, _maxX, _minY, _maxY;
    private GameObject[] _spawnedAmount;

    private void Awake()
    {
        _camera = FindObjectOfType<Camera>();
        SetupValues();
    }

    private void Start()
    {
        StartCoroutine(Spawn_c());
    }

    private void SetupValues()
    {
        float camDistance = Vector3.Distance(transform.position, _camera.transform.position);

        Vector2 bottomCorner = _camera.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        Vector2 topCorner = _camera.ViewportToWorldPoint(new Vector3(1, 1, camDistance));

        _minX = bottomCorner.x;
        _maxX = topCorner.x;
        _minY = bottomCorner.y;
        _maxY = topCorner.y;
    }

    private IEnumerator Spawn_c()
    {
        while (enabled)
        {
            _spawnedAmount = GameObject.FindGameObjectsWithTag("Enemy");
            if (_spawnedAmount.Length < targetSpawnAmount)
            {
                Instantiate(objectsToSpawn[Random.Range(0, objectsToSpawn.Length)],
                    new Vector3(
                        Random.Range(_minX, _maxX),
                        Random.Range(_minY, _maxY)),
                    Quaternion.identity);
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}