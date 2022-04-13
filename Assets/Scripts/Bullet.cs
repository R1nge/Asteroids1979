using System.Collections;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] protected int damageAmount;
    [SerializeField] protected float lifeTime;

    private void Start() => StartCoroutine(destroy_c());

    protected abstract void OnCollision(GameObject go);

    private void OnTriggerEnter2D(Collider2D other)
    {
        OnCollision(other.gameObject);
        Destroy(gameObject);
    }

    private IEnumerator destroy_c()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}