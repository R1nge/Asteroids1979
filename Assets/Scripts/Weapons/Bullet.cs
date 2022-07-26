using System.Collections;
using UnityEngine;

namespace Weapons
{
    public abstract class Bullet : MonoBehaviour
    {
        [SerializeField] protected int damageAmount;
        [SerializeField] protected float lifeTime;

        private void Start() => StartCoroutine(destroy_c());

        public virtual void OnTriggerEnter2D(Collider2D other) => gameObject.SetActive(false);

        private IEnumerator destroy_c()
        {
            yield return new WaitForSeconds(lifeTime);
            gameObject.SetActive(false);
        }
    }
}