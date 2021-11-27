using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToSpawn;
    [SerializeField] private float spawnInterval;
    [SerializeField] private int targetSpawnAmount;
    [SerializeField] private float minX, maxX, minY, maxY;
    private Camera _camera;
    private GameObject[] _spawnedAmount;

    private void Awake()
    {
        _camera = FindObjectOfType<Camera>();
    }

    private void Start()
    {
        StartCoroutine(Spawn_c());
    }

    private IEnumerator Spawn_c()
    {
        while (enabled)
        {
            _spawnedAmount = GameObject.FindGameObjectsWithTag("Enemy");
            if (_spawnedAmount.Length < targetSpawnAmount)
            {
                Instantiate(objectsToSpawn[Random.Range(0, objectsToSpawn.Length)],
                    _camera.ViewportToWorldPoint(new Vector3(Random.Range(0, 1), Random.Range(0, 1)) +
                                                 new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 10)),
                    Quaternion.identity);

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
