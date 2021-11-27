using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int damageAmount;
    [SerializeField] private float lifeTime;

    private void Start()
    {
        StartCoroutine(destroy_c());
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.TryGetComponent(out Health health))
        {
            health.TakeDamage(damageAmount);
        }

        Destroy(gameObject);
    }

    private IEnumerator destroy_c()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}