using UnityEngine;

namespace Weapons
{
    public class BulletSpawner : MonoBehaviour
    {
        //TODO: Add pooling
        //TODO: Add Zenject
        public Rigidbody2D Spawn(Rigidbody2D bulletPrefab, Vector3 position, Quaternion rotation)
        {
            return Instantiate(bulletPrefab, position, rotation);
        }
    }
}