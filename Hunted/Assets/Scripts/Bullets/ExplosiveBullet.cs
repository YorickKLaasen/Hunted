using UnityEngine;

public class ExplosiveBulletBehavior : MonoBehaviour, IBulletHitBehavior
{
    [SerializeField] private float radius = 2f;
    [SerializeField] private GameObject explosionVFX;
    private bool hasExploded;

    public void OnHit(Bullet bullet, Collider2D collision, float damage)
    {
        if (hasExploded) return;

        hasExploded = true;

        Vector2 pos = bullet.transform.position;

        GameObject explosion = Instantiate(
            explosionVFX,
            pos,
            Quaternion.identity);

        explosion.transform.localScale = Vector3.one * radius * 2f;

        Collider2D[] hits = Physics2D.OverlapCircleAll(pos, radius);

        foreach (var hit in hits)
        {
            if (hit.TryGetComponent<IDamageable>(out var dmg))
            {
                dmg.TakeDamage(damage);
            }
        }

        Destroy(bullet.gameObject);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 1, 0, 0.75F);
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
