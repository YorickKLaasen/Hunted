using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private EnemyController enemyController;
    [SerializeField] private float health = 100f;

    private void Start()
    {
        if (enemyController == null)
            enemyController = GetComponent<EnemyController>();

        ResetHealth();
    }

    public void ResetHealth()
    {
        if (enemyController != null && enemyController.enemyStats != null)
        {
            health = enemyController.enemyStats.enemyHealth;
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        DamageTextPool.Instance.ShowDamage(damage, transform.position + Vector3.up);

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        PlayerXP.Instance?.GainXP(enemyController.enemyStats.xpYield);
        EnemyObjectPool.Instance.ReturnToPool(enemyController);
    }

}
