using System.Collections;
using UnityEngine;

namespace Weapons
{
    public abstract class Bullet : MonoBehaviour
    {
        [SerializeField] protected int damageAmount;
        [SerializeField] protected float lifeTime;

        private void Start() => StartCoroutine(destroy_c());

        public virtual void OnTriggerEnter2D(Collider2D other)
        {
            Destroy(gameObject);
        }

        private IEnumerator destroy_c()
        {
            yield return new WaitForSeconds(lifeTime);
            Destroy(gameObject);
        }
    }
}