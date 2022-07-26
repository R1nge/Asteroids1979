using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{
    public class BulletSpawner : MonoBehaviour
    {
        public static BulletSpawner Instance;
        public List<GameObject> playerBullets;
        public List<GameObject> enemyBullets;
        public GameObject playerBullet;
        public GameObject enemyBullet;
        public int amountToPool;

        private void Awake() => Instance = this;

        private void Start()
        {
            playerBullets = new List<GameObject>(amountToPool);
            for (int i = 0; i < amountToPool; i++)
            {
                var tmp = Instantiate(playerBullet);
                tmp.SetActive(false);
                playerBullets.Add(tmp);
            }

            for (int i = 0; i < amountToPool; i++)
            {
                var tmp = Instantiate(enemyBullet);
                tmp.SetActive(false);
                enemyBullets.Add(tmp);
            }
        }

        public GameObject GetPlayerBullet()
        {
            for (int i = 0; i < playerBullets.Count; i++)
            {
                if (!playerBullets[i].activeInHierarchy)
                {
                    playerBullets[i].SetActive(true);
                    return playerBullets[i];
                }
            }

            return null;
        }

        public GameObject GetEnemyBullet()
        {
            for (int i = 0; i < enemyBullets.Count; i++)
            {
                if (!enemyBullets[i].activeInHierarchy)
                {
                    enemyBullets[i].SetActive(true);
                    return enemyBullets[i];
                }
            }

            return null;
        }
    }
}