using UnityEngine;

public interface IBulletHitBehavior
{
    void OnHit(Bullet bullet, Collider2D collision, float damage);
}
