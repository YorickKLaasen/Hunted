using UnityEngine;

public class FireBullet : MonoBehaviour, IBulletHitBehavior
{
    [SerializeField] private int pierceCount = 2;
    private void Start()
    {
        Transform trail = transform.Find("FireTrail");

        if (trail != null)
        {
            trail.gameObject.SetActive(true);
        }
    }

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
