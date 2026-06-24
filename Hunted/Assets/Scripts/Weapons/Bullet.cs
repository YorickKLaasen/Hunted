using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifeTime = 3f;

    private float damage;
    private IBulletHitBehavior behavior;

    private Rigidbody2D rb;
    //DamageInfo damageInfo;
    public void Initialize(float damage)
    {
        this.damage = damage;

        behavior = GetComponent<IBulletHitBehavior>();
        if (behavior == null)
        {
            behavior = new NormalBulletBehavior();
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.right * speed;

        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        behavior.OnHit(this, collision, damage);
    }
}
