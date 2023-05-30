using Core;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Enemy
{
    public class EnemyFactory : MonoBehaviour
    {
        [SerializeField] private GameObject[] objectsToSpawn;
        [SerializeField] private int targetSpawnAmount;
        private Camera _camera;
        private float _height, _width;
        private int _spawnedAmount;
        private GameManager _gameManager;
        private IObjectResolver _objectResolver;

        [Inject]
        private void Construct(IObjectResolver objectResolver, GameManager gameManager)
        {
            _objectResolver = objectResolver;
            _gameManager = gameManager;
        }

        private void Start()
        {
            _gameManager.OnGameStartedEvent += OnGameStart;
            EnemyBase.OnEnemyDied += OnEnemyDied;
            _camera = Camera.main;
            _height = _camera.orthographicSize + 1;
            _width = _camera.orthographicSize * _camera.aspect + 1;
        }

        private void OnEnemyDied(int amount)
        {
            _spawnedAmount -= 1;
            _spawnedAmount += amount;
            Spawn();
        }

        private void OnGameStart()
        {
            for (_spawnedAmount = 0; _spawnedAmount < targetSpawnAmount;)
                Spawn();
        }

        private void Spawn()
        {
            if (_spawnedAmount >= targetSpawnAmount) return;
            _objectResolver.Instantiate(objectsToSpawn[Random.Range(0, objectsToSpawn.Length)],
                new(
                    _camera.transform.position.x + Random.Range(-_width, _width),
                    transform.position.y + _height + Random.Range(10, 30),
                    0),
                Quaternion.identity);
            _spawnedAmount++;
        }

        private void OnDestroy()
        {
            _gameManager.OnGameStartedEvent -= OnGameStart;
            EnemyBase.OnEnemyDied -= OnEnemyDied;
        }
    }
}