using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{
    public class BulletFactory : MonoBehaviour
    {
        [SerializeField] private GameObject playerBullet;
        [SerializeField] private GameObject enemyBullet;
        [SerializeField] private int amountToPool;
        private readonly List<GameObject> _playerBulletsPool = new();
        private readonly List<GameObject> _enemyBulletsPool = new();

        private void Start()
        {
            for (int i = 0; i < amountToPool; i++)
            {
                var tmp = Instantiate(playerBullet);
                tmp.SetActive(false);
                _playerBulletsPool.Add(tmp);
            }

            for (int i = 0; i < amountToPool; i++)
            {
                var tmp = Instantiate(enemyBullet);
                tmp.SetActive(false);
                _enemyBulletsPool.Add(tmp);
            }
        }

        public GameObject GetPlayerBullet()
        {
            for (int i = 0; i < _playerBulletsPool.Count; i++)
            {
                if (!_playerBulletsPool[i].activeInHierarchy)
                {
                    _playerBulletsPool[i].SetActive(true);
                    return _playerBulletsPool[i];
                }
            }

            return null;
        }

        public GameObject GetEnemyBullet()
        {
            for (int i = 0; i < _enemyBulletsPool.Count; i++)
            {
                if (!_enemyBulletsPool[i].activeInHierarchy)
                {
                    _enemyBulletsPool[i].SetActive(true);
                    return _enemyBulletsPool[i];
                }
            }

            return null;
        }
    }
}