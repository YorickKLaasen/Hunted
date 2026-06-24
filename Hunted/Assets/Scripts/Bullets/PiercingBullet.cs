using UnityEngine;

public class PiercingBulletBehavior : MonoBehaviour, IBulletHitBehavior
{
    [SerializeField] private int pierceCount = 3;

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
