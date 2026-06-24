using UnityEngine;

public class NormalBulletBehavior : MonoBehaviour, IBulletHitBehavior
{
    [SerializeField] private int pierceCount = 2;

    public void OnHit(Bullet bullet, Collider2D collision, float damage)
    {
        if (collision.TryGetComponent<IDamageable>(out var dmg))
        {
            dmg.TakeDamage(damage);
        }

        pierceCount--;

        if (pierceCount <= 0)
        {
            Destroy(bullet.gameObject);
        }
    }
}
