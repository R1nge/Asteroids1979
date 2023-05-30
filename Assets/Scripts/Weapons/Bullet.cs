using System.Collections;
using UnityEngine;

namespace Weapons
{
    public abstract class Bullet : MonoBehaviour
    {
        [SerializeField] protected int damageAmount;
        [SerializeField] protected float lifeTime;

        private void Start() => StartCoroutine(Destroy_c());

        public virtual void OnTriggerEnter2D(Collider2D other) => gameObject.SetActive(false);

        private IEnumerator Destroy_c()
        {
            yield return new WaitForSeconds(lifeTime);
            gameObject.SetActive(false);
        }
    }
}