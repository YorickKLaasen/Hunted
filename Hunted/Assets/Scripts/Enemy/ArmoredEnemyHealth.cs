using TMPro;
using UnityEngine;

public class ArmoredEnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private EnemyController enemyController;
    [SerializeField] private float health = 100f;
    [SerializeField] private int hitShieldCount;

    [SerializeField] private TextMeshPro shieldCountText;
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
            hitShieldCount = enemyController.enemyStats.enemyHitShield;
            shieldCountText.gameObject.SetActive(true);
            shieldCountText.text = hitShieldCount.ToString();
        }
    }
    public void TakeDamage(float damage)
    {
        hitShieldCount--;
        shieldCountText.text = hitShieldCount.ToString();
        if (hitShieldCount <= 0)
        {
            shieldCountText.gameObject.SetActive(false);
            health -= damage;
            DamageTextPool.Instance.ShowDamage(damage, transform.position + Vector3.up);
        }

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
