using UnityEngine;

public class ExplosivePiercingBullet : MonoBehaviour,IBulletHitBehavior
{
    [SerializeField] private float radius = 2f;
    [SerializeField] private GameObject explosionVFX;
    [SerializeField] private int pierceCount = 3;

    private bool hasHitThisFrame;

    public void OnHit(Bullet bullet, Collider2D collision, float damage)
    {
        if (hasHitThisFrame) return;

        hasHitThisFrame = true;

        Vector2 pos = bullet.transform.position;

        Explode(pos, damage);

        pierceCount--;

        if (pierceCount <= 0)
        {
            Destroy(bullet.gameObject);
        }

        // reset per physics frame (belangrijk bij meerdere hits)
        bullet.StartCoroutine(ResetHitFlag());
    }

    private void Explode(Vector2 pos, float damage)
    {
        if (explosionVFX != null)
        {
            GameObject explosion = Instantiate(explosionVFX, pos, Quaternion.identity);
            explosion.transform.localScale = Vector3.one * radius * 2f;
        }

        Collider2D[] hits = Physics2D.OverlapCircleAll(pos, radius);

        foreach (var hit in hits)
        {
            if (hit.TryGetComponent<IDamageable>(out var dmg))
            {
                dmg.TakeDamage(damage);
            }
        }
    }

    private System.Collections.IEnumerator ResetHitFlag()
    {
        yield return null;
        hasHitThisFrame = false;
    }
}
